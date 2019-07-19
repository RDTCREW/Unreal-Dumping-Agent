﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrPlus.Windows.Api;
using ClrPlus.Windows.Api.Structures;

namespace Unreal_Dumping_Agent.UtilsHelper
{
    public static class Utils
    {
        public const string Version = "1.0.0";
        public const string Title = "Welcome Agent";

        #region Structs
        public struct MemoryRegion
        {
            public IntPtr Address;
            public long RegionSize;
        }
        #endregion

        #region Variables

        #endregion

        #region Tool
        public static bool ProgramIs64()
        {
#if x64
            return true;
#else
            return true;
#endif
        }
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return true;
#endif
        }
        public static void ConsoleText(string category, string message, ConsoleColor textColor)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{category,-10}] ");
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region Process
        public static bool Is64Bit(this Process process)
        {
            // PROCESS_QUERY_INFORMATION 
            var processHandle = Kernel32.OpenProcess(0x0400, false, process.Id);
            bool ret = Kernel32.IsWow64Process(processHandle, out bool retVal) && retVal;
            processHandle.Close();
            return !ret;
        }
        #endregion
    }
}
