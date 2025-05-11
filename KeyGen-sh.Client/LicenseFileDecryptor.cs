using KeyGenClient.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyGenClient
{
    public class LicenseFileDecryptor
    {
        private readonly string _publicKey = string.Empty;

        public LicenseFileDecryptor(string publicKey)
        {
            _publicKey = publicKey;
        }

        public LicenseFileResponse? Decrypt(string certificate, string licenseKey)
        {
            var encodedPayload = Regex.Replace(certificate, "(^-----BEGIN LICENSE FILE-----\\n|\\n|-----END LICENSE FILE-----\\n$)", "");
            var payloadBytes = Convert.FromBase64String(encodedPayload);
            var payload = Encoding.UTF8.GetString(payloadBytes);

            var license = JsonSerializer.Deserialize<LicenseFile>(payload);

            var decryptionSecret = GetDecryptionSecret(licenseKey);

            if (license!.alg == "aes-256-gcm+ed25519" &&
                VerifySignatureWith_ed25519(license.sig, license.enc))
            {
                var plainText = DecryptWith_ed25519(license.enc, decryptionSecret);
                JsonSerializerOptions options = new() { Converters = { new LicenseFileIncludeBaseConverter() } };
                return JsonSerializer.Deserialize<LicenseFileResponse>(plainText, options);
            }

            return null;
        }

        public bool VerifySignatureWith_ed25519(string encodedSignature, string encryptedData)
        {

            byte[] signatureBytes = Convert.FromBase64String(encodedSignature);
            byte[] signingDataBytes = Encoding.UTF8.GetBytes($"license/{encryptedData}");
            byte[] publicKeyBytes = Convert.FromHexString(_publicKey);

            // Load the public key
            var publicKey = new Ed25519PublicKeyParameters(publicKeyBytes, 0);

            // Initialize the signer for verification
            var verifier = new Ed25519Signer();
            verifier.Init(false, publicKey);
            verifier.BlockUpdate(signingDataBytes, 0, signingDataBytes.Length);

            // Verify the signature
            return verifier.VerifySignature(signatureBytes);
        }

        public string DecryptWith_ed25519(string encryptedData, byte[] decryptionSecret)
        {
            var encodedCipherText = encryptedData.Split(".", 3)[0];
            var encodedIv = encryptedData.Split(".", 3)[1];
            var encodedTag = encryptedData.Split(".", 3)[2];
            var cipherText = Convert.FromBase64String(encodedCipherText);
            var iv = Convert.FromBase64String(encodedIv);
            var tag = Convert.FromBase64String(encodedTag);

            var cipherParams = new AeadParameters(new KeyParameter(decryptionSecret), 128, iv);
            var aesEngine = new AesEngine();
            var cipher = new GcmBlockCipher(aesEngine);

            cipher.Init(false, cipherParams);

            var input = cipherText.Concat(tag).ToArray();
            var output = new byte[cipher.GetOutputSize(input.Length)];

            var len = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            cipher.DoFinal(output, len);

            return Encoding.UTF8.GetString(output);
        }

        public byte[] GetDecryptionSecret(string licenseKey)
        {
            byte[] licenseKeyBytes = Encoding.UTF8.GetBytes(licenseKey);
            byte[] hash;

            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(licenseKeyBytes);
            }

            return hash;
        }
    }
}
