using SRTPluginBase;
using System;

namespace SRTPluginProviderED
{
    internal class PluginInfo : IPluginInfo
    {
        public string Name => "Game Memory Provider (Elden Ring)";

        public string Description => "A game memory provider plugin for Elden Ring (Microsoft Store).";

        public string Author => "Mysterion352";

        public Uri MoreInfoURL => new Uri("https://github.com/Mysterion06");

        public int VersionMajor => assemblyVersion.Major;

        public int VersionMinor => assemblyVersion.Minor;

        public int VersionBuild => assemblyVersion.Build;

        public int VersionRevision => assemblyVersion.Revision;

        private Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
    }
}
