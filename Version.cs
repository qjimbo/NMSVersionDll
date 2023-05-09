using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace RetroShaderFixGUI
{
    public enum NMSPlatform
    {
        GOG,
        Steam,
        SteamUnpacked
    }
    public enum NMSUpdate
    {
        Release,
        Foundation,
        PathFinder,
        AtlasRises
    }
    public class VersionInfo
    {
        public VersionInfo(string NMSEXESHA1, string VERSION, NMSPlatform PLATFORM, NMSUpdate UPDATE)
        {
            this.NMSEXESHA1 = NMSEXESHA1;
            this.VERSION = VERSION;
            this.PLATFORM = PLATFORM;
            this.UPDATE = UPDATE;
        }
        public string NMSEXESHA1 { get; set; }
        public string VERSION { get; set; }
        public NMSPlatform PLATFORM { get; set; }
        public NMSUpdate UPDATE { get; set; }
    }
    public class Version
    {
        // SHA 1 Hashes of each NMS.EXE
        private static List<VersionInfo> Data = new List<VersionInfo>() {
            // GOG
            new VersionInfo("0398e7c40bb56066de6169f2291ac91c1b56638e","1.09.1", NMSPlatform.GOG, NMSUpdate.Release),
            new VersionInfo("d360b7ce2ee20410d5d7f48d7ae333adca31a9fa","1.13", NMSPlatform.GOG, NMSUpdate.Foundation),
            new VersionInfo("5f52cfb37e5ddb8b148d0f72b658b5a7387cdb79","1.24", NMSPlatform.GOG, NMSUpdate.PathFinder),
            new VersionInfo("d8369453eac22136748aaf70ab0042597fc3c12c","1.381", NMSPlatform.GOG, NMSUpdate.AtlasRises),

            // STEAM
            new VersionInfo("d900725d39f79f7627d55d8616d9d21d438945a6","1.03", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("e4470a664e9cbc0c5ab16756c243370608307e18","1.04", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("9f5d9a45565e5d79595c7ad4aa686333353c1a9e","1.05", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("405995e6fe0035a205e9c1af579bbe2e948fe9d0","1.06", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("3a844e69b7b7d2d75cf881b8690911d6a08c5bcb","1.07", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("2e9fef1f090cc0209793bab5310c2373f48ffdd9","1.09", NMSPlatform.Steam, NMSUpdate.Release),
            new VersionInfo("2680f5483af7e4cdbd1679d5c41e190ae06cab89","1.09.1", NMSPlatform.Steam, NMSUpdate.Release),

            new VersionInfo("cd9bbc0a90def5689372e7423685eee6cdeb8fff","1.10", NMSPlatform.Steam, NMSUpdate.Foundation),            
            new VersionInfo("6499165cc8e71b52789e35f88e420a36ec471a32","1.12", NMSPlatform.Steam, NMSUpdate.Foundation),
            new VersionInfo("d433c512f3f28fdfb55f6a4a41b720cc7b020533","1.13", NMSPlatform.Steam, NMSUpdate.Foundation),

            new VersionInfo("e87a81114a7a8b427fe0ae65292fdc40aa25a5bc","1.20", NMSPlatform.Steam, NMSUpdate.PathFinder),
            new VersionInfo("04254a667b232c0695544e1398497bea7f09c47c","1.22", NMSPlatform.Steam, NMSUpdate.PathFinder),
            new VersionInfo("34f05e27ae7fc94aedd6d19d124a34cfc3df6486","1.23", NMSPlatform.Steam, NMSUpdate.PathFinder),
            new VersionInfo("6c24c15741370e2e55f832af9609edea4d2ea053","1.24", NMSPlatform.Steam, NMSUpdate.PathFinder),

            new VersionInfo("716da607530c972febd81062f745290e77eb5ae9","1.30", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("a0ed5fd32199a9ab10246291030c216753333ae4","1.31", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("2310f922d90e4d479e75b35fa910b40e04e7534c","1.32", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("607d0790b253cac2acc4defa0dc148f83d485a16","1.33", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("901ed4d0dc29c5e9f2693dbe0d6d3125ac97e20f","1.34", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("aca0971d7fb562bd9f680172e7a43af167c6de25","1.35", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("4b11b4f6e537220325012bf901cd2283e8685096","1.37", NMSPlatform.Steam, NMSUpdate.AtlasRises),
            new VersionInfo("17120ba1006bc12f18fca3c93dfcc3881a0ba0af","1.38", NMSPlatform.Steam, NMSUpdate.AtlasRises),

            // STEAM UNPACKED
            new VersionInfo("040edeb5242e2117005ea8b0c0b41e733a7a8c2b","1.20", NMSPlatform.SteamUnpacked, NMSUpdate.PathFinder),
            new VersionInfo("3a807521c0bb4473032a03ada4d8f13ab5f50b0a","1.22", NMSPlatform.SteamUnpacked, NMSUpdate.PathFinder),
            new VersionInfo("d8f7f3594d835063c6e4b24314ca28a114452779","1.23", NMSPlatform.SteamUnpacked, NMSUpdate.PathFinder),
            new VersionInfo("ab95596baf4b06f376c6a2c58ea9407fa51c354c","1.24", NMSPlatform.SteamUnpacked, NMSUpdate.PathFinder),

            new VersionInfo("5f032af02800ffa28108ac49c05dc52bb06fb278","1.30", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("abdb62853ae5c15e160875e6bd0fb34cf3b1a892","1.31", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("21428688bd032f56f56a8c166267c4524fe2835e","1.32", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("3d5f41f975dd6e10dd359bcececefe7b9873be56","1.33", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("4d2191c13078eccfd8eac22ef91ce1e79e14b9de","1.34", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("8f96364c4ff829faba9cbb4ce2d20bd93a3f2b44","1.35", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("3b47e298d09ba0966e6ada3d45832a29b2d00511","1.37", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises),
            new VersionInfo("c0be5a4341200d20653a0b5976a26b3c771b8819","1.38", NMSPlatform.SteamUnpacked, NMSUpdate.AtlasRises)
        };

        public static VersionInfo GetVersionInfo(string pathToNMSEXE)
        {
            string hash = CalculateFileHash(pathToNMSEXE);
            var info = Data.FirstOrDefault(m => m.NMSEXESHA1 == hash);
            return info;
        }

        public static string CalculateFileHash(string filePath)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }
    }
}
