using ProcessMemory;
using SRTPluginProviderED.Structs.GameStructs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static SRTPluginProviderED.Structs.GameStructs.GamePlayer;

namespace SRTPluginProviderED
{
    internal class GameMemoryEDScanner : IDisposable
    {
        // Variables
        private ProcessMemoryHandler memoryAccess;
        private GameMemoryED gameMemoryValues;
        public bool HasScanned;
        public bool ProcessRunning => memoryAccess != null && memoryAccess.ProcessRunning;
        public int ProcessExitCode => (memoryAccess != null) ? memoryAccess.ProcessExitCode : 0;

        // Pointer Address Variables
        private int pointerAddressBossStatus;
        private int pointerAddressRegionID;

        // Pointer Classes
        private IntPtr BaseAddress { get; set; }
        private MultilevelPointer PointerBossStatus { get; set; }
        private MultilevelPointer PointerRegionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        internal GameMemoryEDScanner(Process process, GameVersion gv)
        {
            gameMemoryValues = new GameMemoryED();
            if (process != null)
                Initialize(process, gv);
        }

        internal void Initialize(Process process, GameVersion gv)
        {
            if (process == null)
                return;
            SelectPointerAddresses(GameHashes.DetectVersion(process.MainModule.FileName));

            int pid = GetProcessId(process).Value;
            memoryAccess = new ProcessMemoryHandler(pid);

            if (ProcessRunning)
            {
                BaseAddress = NativeWrappers.GetProcessBaseAddress(pid, PInvoke.ListModules.LIST_MODULES_64BIT); // Bypass .NET's managed solution for getting this and attempt to get this info ourselves via PInvoke since some users are getting 299 PARTIAL COPY when they seemingly shouldn'
                if (gv == GameVersion.STEAM_July2024)
                {
                    gameMemoryValues._gameInfo = "Current Patch";
                    PointerBossStatus = new MultilevelPointer(memoryAccess, IntPtr.Add(BaseAddress, pointerAddressBossStatus), 0x28);
                    PointerRegionID = new MultilevelPointer(memoryAccess, IntPtr.Add(BaseAddress, pointerAddressRegionID));
                }
                else
                {
                    gameMemoryValues._gameInfo = "Unknown Release May Not Work. Contact Developers";
                }
            }
        }

        private void SelectPointerAddresses(GameVersion version)
        {
            if (version == GameVersion.STEAM_July2024)
            {
                pointerAddressBossStatus = 0x03D68468;
                pointerAddressRegionID = 0x03D691F8;
                gameMemoryValues._gameInfo = "Current Patch";
            }
            else
            {
                gameMemoryValues._gameInfo = "Unknown Release May Not Work. Contact Developers";
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void UpdatePointers()
        {
            PointerBossStatus.UpdatePointers();
            PointerRegionID.UpdatePointers();
        }
        

        internal IGameMemoryED Refresh(GameVersion gv)
        {
            if (gv == GameVersion.STEAM_July2024)
            {
                //gameMemoryValues._bellBearingHunter = PointerBossStatus.DerefByte(0xA0E25);
                //gameMemoryValues._blackKnifeAssassin = PointerBossStatus.DerefByte(0x16AC1A);

                //gameMemoryValues._bosses = PointerBossStatus.Deref<GamePlayer>(0x0);


                //Console.WriteLine($"Name: {name}, Offset: {offset:X}");
                //gameMemoryValues._bosses = PointerBossStatus.Deref<GamePlayer>(offset);
                foreach (KeyValuePair<string, int> bossOffset in bossStatusOffsets)
                {
                    gameMemoryValues.BossStatus[bossOffset.Key] = PointerBossStatus.DerefInt(bossOffset.Value);
                }

                gameMemoryValues._regionID = PointerRegionID.DerefInt(0xE4);
                //Console.WriteLine(gameMemoryValues._boss.ToString());
                //Console.WriteLine(gameMemoryValues._boss.ToString());
            }
            else
            {
                Console.WriteLine("No Version was recognized");
            }
            HasScanned = true;
            return gameMemoryValues;
        }


        private int? GetProcessId(Process process) => process?.Id;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (memoryAccess != null)
                        memoryAccess.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~REmake1Memory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
#endregion
    }
}
