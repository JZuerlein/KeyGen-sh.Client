using KeyGen_sh.Client.Models;
using NSec.Cryptography;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var ed25519 = SignatureAlgorithm.Ed25519;
            var signatureBytes = Convert.FromBase64String(encodedSignature);
            var signingDataBytes = Encoding.UTF8.GetBytes($"license/{encryptedData}");
            var publicKeyBytes = Convert.FromHexString(_publicKey);
            var key = NSec.Cryptography.PublicKey.Import(ed25519, publicKeyBytes, KeyBlobFormat.RawPublicKey);

            return ed25519.Verify(key, signingDataBytes, signatureBytes);
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
            var licenseKeyBytes = Encoding.UTF8.GetBytes(licenseKey);
            var sha256 = new Sha256();

            return sha256.Hash(licenseKeyBytes);
        }
    }
}
