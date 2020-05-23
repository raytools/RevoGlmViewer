using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace RevoGlmViewer
{
    public static class Memory
    {
        public const int PROCESS_WM_READ = 0x0010;
        public const int PROCESS_VM_WRITE = 0x0020;
        public const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        public static int GetPointerPath(int processHandle, int baseAddress, params int[] offsets)
        {
            int currentAddress = baseAddress;
            int bytesReadOrWritten = 0;

            byte[] buffer = new byte[4];
            ReadProcessMemory(processHandle, currentAddress, buffer, buffer.Length, ref bytesReadOrWritten);
            currentAddress = BitConverter.ToInt32(buffer, 0);

            foreach (int offset in offsets)
            {
                if (offset == offsets.Last())
                {
                    currentAddress += offset;
                }
                else
                {
                    ReadProcessMemory(processHandle, currentAddress + offset, buffer, buffer.Length, ref bytesReadOrWritten);
                    currentAddress = BitConverter.ToInt32(buffer, 0);
                }
            }

            return currentAddress;
        }

        public static int GetProcessHandle(string name)
        {
            Process process = Process.GetProcessesByName(name).FirstOrDefault();
            if (process == null) return 0;

            IntPtr handle = Memory.OpenProcess(Memory.PROCESS_WM_READ | Memory.PROCESS_VM_WRITE | Memory.PROCESS_VM_OPERATION, false, process.Id);
            process.Dispose();

            return (int)handle;
        }
    }
}