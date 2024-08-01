using System;
using System.Collections.Generic;
using SRTPluginProviderED.Structs;
using SRTPluginProviderED.Structs.GameStructs;

namespace SRTPluginProviderED
{
    public interface IGameMemoryED
    {
        string GameName { get; }
        string VersionInfo { get; }
        string GameInfo { get; }
               /* 
        byte BellBearingHunter { get; }
        byte BlackKnifeAssassin { get; }

        byte BellBearing { get; }
        byte BloodHoundKnight { get; }
        byte AlabasterLord { get; }*/

        int RegionID { get; set; }

        Dictionary<string, int> BossStatus { get; set; }
    }
}
