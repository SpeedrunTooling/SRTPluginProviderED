using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SRTPluginProviderED
{
    /// <summary>
    /// SHA256 hashes for the RE3/BIO3 REmake game executables.
    /// 
    /// Resident Evil 3 (WW): https://steamdb.info/app/952060/ / https://steamdb.info/depot/952062/
    /// Biohazard 3 (CERO Z): https://steamdb.info/app/1100830/ / https://steamdb.info/depot/1100831/
    /// </summary>
    /// 

    public enum GameVersion : int
    {
        STEAM_July2024,
        UNKNOWN
    }

    public static class GameHashes
    {
        private static readonly byte[] eldenRingSteam2024July = new byte[32] { 0xB1, 0xB8, 0xBA, 0x8C, 0x8B, 0x5C, 0x68, 0x91, 0x88, 0xCA, 0x51, 0x1C, 0xDF, 0x12, 0xF4, 0x2B, 0x20, 0x78, 0x7C, 0x14, 0xA3, 0xC0, 0x6B, 0xA7, 0xCF, 0x81, 0x6D, 0x42, 0x37, 0x0C, 0x0A, 0x3C };
        public static GameVersion DetectVersion(string filePath)
        {
            byte[] checksum;
            using (SHA256 hashFunc = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                checksum = hashFunc.ComputeHash(fs);

            if (checksum.SequenceEqual(eldenRingSteam2024July))
                return GameVersion.STEAM_July2024;
            else
                return GameVersion.UNKNOWN;
        }
    }
}