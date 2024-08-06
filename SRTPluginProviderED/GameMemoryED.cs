using System;
using System.Globalization;
using System.Collections.Generic;
using SRTPluginProviderED.Structs;
using System.Diagnostics;
using System.Reflection;
using SRTPluginProviderED.Structs.GameStructs;

namespace SRTPluginProviderED
{
    public class GameMemoryED : IGameMemoryED
    {
        public string GameName => "ED";
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;


        // GameInfo
        public string GameInfo { get => _gameInfo; set => _gameInfo = value; }
        internal string _gameInfo;

        public int RegionID { get => _regionID; set => _regionID = value; }
        internal int _regionID;

        public Dictionary<string, int> BossStatus { get => _bossStatus; set => _bossStatus = value; }
        internal Dictionary<string, int> _bossStatus = new Dictionary<string, int>();

    }
}
