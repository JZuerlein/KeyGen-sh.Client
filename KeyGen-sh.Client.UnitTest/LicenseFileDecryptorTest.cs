﻿
using System.Text.Json;
using KeyGenClient.Models;

namespace KeyGenClient.UnitTest
{
    public class LicenseFileDecryptorTest
    {
        string licenseFile = $"-----BEGIN LICENSE FILE-----\neyJlbmMiOiJ3WUtqeXBkQ3pmTEFtUUYvMXpvZVV3bEUrRTFmekJVYXFoZkxi\nVnZmOEdjVU1obXY4MytJNDR2SlZmR2xabkhPaVFmc1NFT2RITGJuK2dPRUYr\nbGJLdVlEQ3ZGZjl2QUpCejl6UTVKU280eFJmMm55THRBWllHMFFEbzBjVWo5\nRlI3TVlKVXRwbmdsQ2N6cDBzU292N3RmT1ZwZUwyd2kxUEM1SWpRYmVHWlJz\nR0NFSFFycS9XWTRRNGVtRnhTdWx0dElkVG91elVOVVpGUnZNSHNKU00vNmYw\nRlFlRkVvMHZ3cW81YnpaZGE5TnM3NkxwbmFYbWlkK1IwZlhYOE9ERnlUZzRN\nOGlVcFM0V1V5b0VvWXBrUEVtazlCR2lwWVVtWGoraldkQUpYemluWko1UUkr\neUV6dk05VnF4WC95YTRXbWtIOUUyZUNUMSt6aDd0ME1oYjUzVzZDeWNwbGlG\nd1hEdmRISjVKVTdxZlkyZEJhcXBlcXRYeEhSL2xDaFk1SFdSTzIzZ1ZsbWpG\ndnZPYnlhZFh0aVBVR2hnUjg2NS9ZNVNHQ3pIWCtDNFNjdXlpQllNNXQ2K2g2\nYVNReVl6K1VnRzUwalFQUHc4UFcwQkhhWFNneTBsM2FpUjNENSt2dzd1WnVQ\nVnBBdW5vMmdKeGdCdUpxbUhTUFkwSjVNVDNScTlJWExnd1lra2hCZnNFOEtt\nU3NGc2dVWFMvMTZEbXIrS3RqK1RuTkp5NjQ2TTFpWWI0c0JQNFVuWDZGV0dr\nSUhBN2NSMlhPeWN4QXY5ZHM4ZWFQVXlrVGNHQkdmZ3FlQlRZWm1LWVppRGFU\nTCtrWWtoMHRNcTB5Rk1GQXVwQkdDVk5ldUsxVFV1ZjRaaVJBdWxVQlZBbzVr\nKzE0L1djUno3VkcwTW5NMkhIbTdEYnBnSExZdUw2b3d1SXAzOTRpM1lpYWNG\nVGlUOTBZTnJ0Vm9oYnpMR0Y0UldIQW84RXBjdE8xZ1NnVWpNWktHNDFNckdS\nc0QvYk5qSE0zRVFnRkc3RHljR2cyY1hJcjJZSG1UY0VtdGpHVkNLWlcrUGNs\nemRpZWhjSDBxWnZ6K1J0NmM1NUdENjBYMmVEajBra2wrVHJQSHNHTXBETmVC\nQnc3dWtONGZDZG5aYVhBSmpUTGtqbi9lajVNZGptdlFOUW1tY0QzMmo1RlFR\nc0ZJK2t5OVVQcERKSkk3RnRXdE9ySCtnTlFmM3dEREw3M2FSSzFNN3B1Vm5x\nOGxXZHJSbDdGbUx3SU9wQXZPRVloQ3I3bXk5SzQ1elNoT2orcWhlUEFVdTNF\nSC9xTkJMZDY5UHN6WTBraExNR0p1SENRZlhBVEd1bzRhU3pXUjl2aEo2TDA0\nY0YxMzdCdVZDMFNQMzB1ejRiWnFHRVAyeTk4R1NRdllnRks2V3lIUGJqTUx1\nczNnNGdpbGxUZkduMHB5b0svT0xSdlp6VWVFWGpVYnJ6OG5mUjFFTUJwWmxu\nSlZVQUtNakpaL21zbWM1N21SVXJVdmNTenp5L2p4c24yWnNUSzFzUHAyaFpx\neEMzUlZ1MGsvb3pBb0tFc3VQam9NS1RzWDZGUVo3blJSNlluRGFBdzEzMHF6\nKzRwNzBhRU9hOUg2WTdDTnNYZ3NOcmxZOWtQQzVHd3NWMmlKekcwUGxOekdX\nTDU1L2huWEVFOVUyaW1LSkR6N0l1T0hzMlBBdmdnTC9iQnY0TFMvaERZNUlv\nK2xaRkJuZ2FCM2xoVU1JZnh6MzlqdkpQQ0lxNERHbFN5VXBpRHJHeUJWK2p5\nRXZIWXZyL0dZVjBIdmJKYmRUSFRXbi9aOUxoaXJaR0FJMTBVWS9tTkVHT2NU\nUG9FbWZlNzZxZ09tYy80Uk1wQmRZUG5EVVFCQjhGRHZlM2JDbDk5bFhrYnRH\nd3hFeTFVU0k3WFRaQ0JqamxLRnplZzBwS2xkYUgyZUxCWU5DZHlzaHl6Um9X\nNTZIZnpGYUtlUnVNajArcitwR0F3dXIra0J5a2p1a3k4U09OcElMTGc2cVRO\nWVU5Uk1KU0UzbVBRMnNTaDdxOVhBaW5USDlXOU5jS2hPWTB5R2RmUHQzcnND\ndzhiZ2hwSC9DRnNLcVNxUThzdmUzbTk0Mml6YlRmbG5BZ2xqdFR4a3ZWekNO\nUW1OMmlQWG80clpHVVNjRkdHYjZSYnUrVTBEa3NLN2laUkRvUVZlNTZreHI3\nSEt4VDk3alB3ZmQrdFZDNExsYzdlQW5OaEY5S3cvR0lDY1NpYTV1c0d6WFM0\nT254YS9zNW9INjZJd2JONHh3ZEQyNkdETHRGUnlWVHdnQWRESFJNTXRQYUtU\nQ2tjM2U0aWNwQzIzZ1ViWi9HMHFSWHRFQnlEMmp5eFdBM1NRVVhOVlpBZ0Zh\nN3Nza216RnZnZGpVOGNEejlZaHhqNUJxTTFOMGs1KzlMdnllNkIxY0Y1eVFE\nZVFzT2pMNEdnaDlUaVVVNEhOTGFpTXRQUGw1cHpoQzNZVVl2V3FhemRTMjVW\nZ1IyWXNEYzg4MzkxMURkdzZlMHJKQ1d2ZkJqTG5DMXVmeDgvS3lvOGdtL0w0\nOW5jTGpzZGszc0EwTE9icFdVemxZT0JHUGJZdEJCdGV3MUFMRjErQ2hGSzdI\nV1cxM3JXNXBUVGZ0YXhHTTFhRWM2MkR4R215ak5kZGF3Ri9MUDJMWDlaVzB0\nL2dGS1JlTDRzVHhkMTBZYVQzdUtjaEhaczZ2ZGY2bWo3SUhuVWNacVRpbjZ0\naUlIR0tmOUd1Ym8zc3AzQnJZL1B0UHUrRTBIWjZ0cTBJQWxucGdONWtBZERY\nakplNUdYMlhPS3orbFJNRXJWM1MvNlRuSit2L1pmVG1GSnA2Q0JSc2p4WFBJ\ndFFCUW5KS1V5eWxHY3R2TjlJaTY5MnZ0eVVVMm5qZEN3TUU0bzZkU3VZd2pY\nZTFjUUVEcDRuWkdKN01XRHNXN3YxUWFlR2o1OHpUSDhYS3ZhR3dIK3I5NGcy\nMDVkTUJLRWc3SENEdE9FYm8zTGIwTFpxWi8rT29PNXZRaHNIV2JoUGZHQnkw\nTktOSnlXOGhZeTA3ZCtIMjRKdUNkMWd0RWdSUVc1Q2c3WXUyRUhlSnYvNVB3\ncmZWejdWSzZmbUpjayt6VjJpNWdQOVVuU1R2VHZiM3Zyb2RHeThscFFERGsv\ncTJaeTZzVUFWM09TTG4vR1pkbGV3ZS9FVTIxY2ErYVh3NHMrYk8yVmZOR2Nv\nbG9ERzM1TUhOK0UxN05jckJoN0lFeFZBVDNVVnhkZ3ZreW1MTzFlQ1ZXYm9o\nS1lhVGxSY0VaYXc1WjU2Ymhsb2JDVitORERvZXZWTkMyS2tnZW5YcitwTkZo\nOWtZd3Q5dVhLaWlpSDhjNU44MHdMVVJpT1labFhpcmtzRUx0LzM5REVjaGpn\nakttYkJQSm9rWEM0UUVaaDErWGpkdjl5MURnanM0WHhESDRSR2QyQ1lNOG9u\nQkhNRUN1aU12NHZic1RjbU5yMVRGTzV4c0pKdDFUUzRwdWszbDRrUjh5dDFj\neWNBcGdFREZzbGVjYkxkZjlzbU5ncGtFYnNjMzVLTE9IV1c1c3JVNis0WUx5\na2JIVlRlZjRVMSs5b3JJZEJRbk5OR1JSaHZqYTNMcGlKTVBQVlFPTjZDMTBn\nU0pyMk9BYlZWaER3Q0E0MWhnUVdGYms4T1hZaW5Tc0h0bmpoR0s3T0N2em1z\nY1kvdzdWaXMwOEkvL3pNeUVFWDFNaGo3K3RrVWl4Q1hDZEZZbDk1YWpsMnFa\nYTNGMk1Iejk5UGlZQVl5emc1QXJYMDhzRzRQTDBHYytFcTZUQkNJOTFSaVNQ\nTVVzVy9WN2I5ek9pQmo4L05hRnFha2tNZE9wTVNYNHAxdks3VDNOVUd3ZCtM\nUURmY0kxenJ6Z3VhL2J5NkJUd3A3M2pOZkcvS0JqYlRnN3dqVVJ1d1FwQmY5\nMUc0VHY5WjVYQzJ2L24xV2hYaVBWWDZCQXJKSjk4YWVuOGNjaStEMzVXcFJH\nOVBHYnk1OHkwTlVMUmcxUXgzcmRnZDVETGh0UzNHdjl1TW5SWFptWTlBZ1ow\nQUF0S29tenNMdE4wWWFxMzVMNk83bFQ4UjhSNDlETW1jc2x1RmRPcWxadVp4\nZkRBa0doUjJDa0Y1b0J1dW1KWVVIT0ZMbmduaHlvZkpRUjNLOXpVZGdBdjRJ\nd2F5bUFsTTBpZnN6eVhLMnVnLzI3Sm5tN0lLUXF0MDhPUXFMSkd0OXNBZlFL\nWWxJRDFZS2l4MmlWN2g0WVZIV1pSOVpGN2I5VHR0MThiR0wzdmxFUUN1dkNs\nOUlSQkNSQ2l1UG9nUmd6NWRUaE1SbjdCMGxvRUVKSCtEdDBBTmtyNS92SWww\nTUNuc05IYllCTnNhSCs1N0NyNDhuTTBVdUtOSDZnakFGOTFuNDlaMGZUeWlt\nMWJoQkpsdzl3dlBoSjFzQjVZRGZaRHF1SWc1Z1hrN3J4eUVzNTQ4Qk9Fakd1\ncEJYU0huL3hFSE9XZE9vWU5iMC9MeFRHaHhSbHJGSGludWRyYXVWdFphQXds\nVzM3cm1TRysrTmNSamZzR05YbnhaSGxqMzJqWlVnUnI3SWZqbW9TUWpJU244\nMnhiRGVEK0NEdkE4L0ZLbGJjU0xLWG1abUkvMnB3VUpFWFpCOC9wNzhlK09K\nUHBvVmFsMk1PeUZLRXhBU1orb0tQNG56c3hXa0pDZzV5N21YN1ZmM21LRjNX\nZkVBNWIyVFhGTTY5VXVlUE1WckNMNmRPK1VKSDZmSUg5SnZVZmRFd0o5MFlD\nYVIwUENXNktHa1R6dXFsSWFRV2gxdHp2WTMwcVQ5eHJyUnp5QXcwQWVrWEN3\ndnlLZ1dob05ManViNkRTVnNsSDBoemRkSXNkY3I2YkgvUGNuN3Y0M1J5KzFz\ndEs2TXlUY3dHd2hRTmdZSGc5b1N3T0FsT2hKVU1USWJ3YUg4a1dpL3h2WlZG\nNElMbllvQXpBR2drZ0hjaFIwNGtFTVVHU09LVmcyNWFPaUttbHVsRHh6UHQ3\nVUcxV2hBOE5RSDhMdlpOWGFYeFlXUHBFbjBmVzBWV3VVY0RFQ0IzUTVRb2Va\nQVZFYmtGdmZVbU9ZK0tRNHVRRjl3ZDZYaktVd3FwVGY3SG1Ub1R2K3FkWGQ5\nYktvQ0lsZjZWKzNLcHhoVjBKeklHWUorNjRBZENLSkpVVytvMCtXOTJ2M2FW\ncVUyZDFIVGhZSmtMeU5mTE9CeG1LbHN2anZuaW9xeHp3V2NGa2RKeEwzVVh3\nK1IrYzlkNXZRMHBlV0RXbnBadytVOEx5aG5nN21TaW12UHliZ2tKRnA1bFlM\nS3hEOGpFZ1FXREgzYzRCZWxiTFVDZitQUUdadDlVaVlRVkZTeDgvWk1idnRm\naWQ1S1dsaUh5ZS9sYnNYOFdVWjYvc3dzN3VlN0puNEtsZzF5a1lyZisyWnMy\nZmV6c3U4VHZTVkxnUTR2TTFDUE5oOHg5UHBaSjFzek9QeE9ia1ppeCtUVlpa\na3l3WXR2U2E4TWtJcWlJb01QT0dvaXN4UkVTY29RTjlnYzY1aEk3Um9vVzF3\naC9DSUZTNXpXR25CQ0FsV3pEdi9XTHExZGVxdlJKbU1ZMWEra21QejFRSWJ0\nUE4xOGdNTTNIV1VQUEVLWlYxS1RjMU45TDREeXJnc050bnBrSGhYWG1FYW56\nU21qak1ENS9jSmpjRWlkU2doT05hN1RDeGl3d2M4eEc5Z0F1VkFwNHJiWlZD\nQkhlUks5eGFjQ3c5b0pGVDNZVnZqb3pxQjU3a3dWcm83alpDdTlkTUJ3MDFt\nNElieU9QYnhNZ0I0Q21XSmtBenBKYXJEN2trUnhSanN4ZEdoUWpEMStnVFhz\nTXpmOTdUM2dmYjBxRUlxSHozb3hGK3dpd0NZc0ZIWGV5eE5DKzY2RG9qRjk1\ndnlndFp3SUwzdFBhL0NyRGZNRTMyOG53dEJVY2o2UkFYZXJsSDZWL08yTlhY\nVWhoNlljdjA2Unh2RUlQK296THY5citvbE9rYlZRc04vOWQ4cldBcXlFS1NZ\nWkFnR2RNamNNcWRxYzQyMjEvNXlnbnF4UGRiYjl1alFURTM3L3ZYeTVvZklz\nb0hIdkVscUFXelE5TUEyY3hDZGE5aFpEM2I2dGRpakJRcjNZYjMrcG9HUnAx\ncEc3MVA4ZURVVUM4VEdoazBBS21hZTg4SGg3ZzdBdUt0TERKcVc1SzYwVTdj\nOGZ2Tmx1Z2dKdmovNGtxODcxYnFUMWdVY0tVbkdrSHFNd2RkT1lYRVRBam1q\nSnpXOW82U1NYRU9xck1SdURpOUhSNGJoSFZ6MXJiMGN6blRuSjBldlZ5ZDdR\nWEJ2SlAycHRsL3RTWmNaalY4QlQ3cTlQZ2NwdVdJNG5WNURZeURZYTB0ZW11\nOTJYUXJpMFdldVQzbS9WN1R4VUVpclhnVzlRaUxGdlBqYnZmbytaRWIybVMz\nRHo1d3JYelN1TTRNcmR6N0g1VHowNTYzWlNoVzdwQ25Pd2hTYy9zOERiSzFB\nSTBzVitPbktiWDhKQStscHl1Sng3WklxYksraENzd2JxYS9vRGh4U1BjSG9r\nM2IxU0U0dG00MC96Y0pRbVljOXU1RlpLV3JEdEhLYldFMUVjb0lMQU4vU056\nZWhyM1RIV2FELzRnRkROOFhSeWd3eTN5SHU5QkZwK0Z0ZXI2TWxZdmpKa0Y1\ndXU0YjBIMmtrVktUNkh0T3cxTUdxaDlLcndaUHNzekZaa2llc2RRL1VLSWNZ\nTkJ6OVg1bUIzU2ZSZUlTUmllK04vQ3lQUjd5ZXBEeURNVml6bUlCbGU1bnRU\nTGsrWWRnZ055R3pSWUdiQ0NyVTBEOFF2VUU5V2laUEQ2WjlydWZKOXY4NWRL\ndTVrTXF4K1BzMWZmbzdDODlBVysvVllRNnVCdWdtK21iNDdLN2FmcmYvd01l\naUZuVG1OeU8zSHRSd1hjVFc0Qy9xMlpmT1hHWlVKZTVzSFVHWFVzREdabmlm\nT2Z5M3NsMGFMajZlZThJMWhnZG5MeFovRm1IdTJxT2p1RCtzeXBwc1VGNEd1\nTjFBYXAxTGFtT2JtM0hTZ1krSmdDb1pzd3Q4N0o3RDV4bHUzV1lLandIQm8r\nWE9wSVB5Z0F3aVRTVkZIY29PbFJUNnlHd3AzOWk1T3N1eGlaQkZwQ3E1UnMw\nQTJDbXF0dGwwRi9QV29FY08rTS81OCtFU2QvREF4THhHQk5xTlppL3NnZXR2\nQ0wrYSsrM0QwNXZMdndqRUlzZlBoYjRxd09uOUxHSmg2L2tUNXZjYkorU2VJ\nSTNhSDlWaFFnTEsxMU1PTlFSbitSWnF1K3dwZ0U2T1Rub0F0MkV3Vk9PMkk5\ndmdkSnh6dTBsOVFyVFN0bSswT21DUzkrWXpmNFJBVmVTZkZJVDRoeUZJQjNR\nMWszM2pvVm1MeExvUDZSTjlZZzNmQXQzS3ZtZk84WmhITm5VWDFxWHd4WS9k\na0d0Rm1lbVgwZjZ0ZzRPNVZGMmljd2ZIcGhDSUlNc0xqUWd1dlNqSlhhZ2pm\nL1BtQ25KeWtJS2NsNmxYaUwxR3ZsUHNPeDBmNEJXZ2l2bWwxMjdZTlh3a0xq\nL0x5VjJqaWhHemEydm50NXlFKzRmSGdMdnZwb1B5dlBUeGIvdFk4UnRMQ3M0\naDRSb3pKRWZjYVF3R2xmUkhoSlRSUTFzVUdjOWlaaEtBNWFiSjNaS05ZLzR0\nU1kxcEVkS2hsNU1JOHpnK2d0eHllUWlWU0w1OTAyYWtDMUdPaHNzRVE4Mjcw\nMkJwcmpEQnZ3b01yaUprRWVlQTlFRnAxUUsySU9yQ3F4cURpZnJsdWloazJl\nZUVhUFFCaTJsdHg2WHhBdTc5NCtwODJpL0VOaWpLYzJ5OENBU09IWE5zZm10\nc3ZvclhOVVljUnRZTFBxRUx1OFZNUWJSQlpxbUZOdmJRdGd1VGZMYUpWMzRx\nV1NKcEJvdVo5WU0zNEhLNGZvZTdtZHlpSnZkOVhpelFQajB1aDNjN3lFVTFV\nKzNaSU9qOGxZU1QydTE1Vkgxdm9nOTB1bVBXdy9JMzN3UFN1YU9iekNUQjVa\nOWZmakViZ3pDYWZRWEs3dVNtWjMrWW4zUzg5UFBsUzNuWFBDYXNxSFJ2cm5S\nZUZXcDdKeFM4TzlvMFp1eVBlZFg3ZDNoYjNIVUFIazdWMzBWTVpNckE1eWFZ\nM3hGSXFsSzhyVjNBRE5vdUZPSXZiSkZnYWtDV08rcnJuYkIyeG9DZVpKZVo0\ndUpFc1Vya1JuamROeEkwMWd3SjFINWtzTktJcUNtQmJVbmVJeEsxSXVNYlRB\ncWpyTUZPdEZwMlNSOE96NVFFdEFOZjNNRXVyOEdQdWtNKzhISC9FNEl5UWhT\nSldWNlVYeDJ3bkgvcXBvYjBlbFU5a3I3THc9PS5PZnBnMzdQTUhtQmYyVTZU\nLlNHOEN0WHBhYXRyeGtRdzkxWDJrTHc9PSIsInNpZyI6InNnK1BENVA0WTNu\na1BWUXpuNFplOUNJUTR3MUMvc0liMnpKVm05Uk9JVVByNE0rMmJONG9jdklU\nYXJ5TVpmYTBSK1BIaTZKK1hPb1VrNjd6WklkS0NBPT0iLCJhbGciOiJhZXMt\nMjU2LWdjbStlZDI1NTE5In0=\n-----END LICENSE FILE-----\n";
        string publicKey = $"e8601e48b69383ba520245fd07971e983d06d22c4257cfd82304601479cee788";
        string licenseKey = $"AFCC0A-B8C07F-F77E6C-93FB02-9FC515-V3";

        [Fact]
        public void DecryptLicenseFile()
        {
            //Arrange
            var sut = new LicenseFileDecryptor(publicKey);

            //Act
            var license = sut.Decrypt(licenseFile, licenseKey);

            //Assert
            Assert.NotNull(license);
            Assert.Equal("6b845231-0ec4-4128-aec9-12f103c7cfd4", license.data.id);

            var actualProduct = (KeyGenClient.Models.Product)license.included.First(_ => _.GetType() == typeof(KeyGenClient.Models.Product));
            Assert.Equal("C# Example", actualProduct.attributes.name);
            Assert.Equal("LICENSED", actualProduct.attributes.distributionStrategy);

            var actualEntitlement = (KeyGenClient.Models.Entitlement)license.included.First(_ => _.GetType() == typeof(KeyGenClient.Models.Entitlement));
            Assert.Equal("Demo Entitlement", actualEntitlement.attributes.name);
            Assert.Equal("DEMO_ENTITLEMENT", actualEntitlement.attributes.code);

        }
    }
}
