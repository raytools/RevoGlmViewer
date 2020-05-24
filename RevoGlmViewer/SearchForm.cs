using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RevoGlmViewer
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();

            handle = Memory.GetProcessHandle("pcsx2");
            if (handle == 0)
            {
                MessageBox.Show("PCSX2 not detected. Start PCSX2 and the game first, or launch RevoGlmViewer as admin if it's already running.");
                Close();
            }

            step = 0;
            InitStep();
        }

        private const int BaseAddr = 0x20000000;

        private int handle;
        private int step;
        private byte searchFor;

        private List<int> savedMem;

        public int FoundAddr { get; private set; } = 0;

        private void buttonNext_Click(object sender, EventArgs e)
        {
            MemSearch(searchFor);

            if (savedMem.Count == 1)
            {
                FoundAddr = savedMem[0];
                MessageBox.Show($"Found DsgVar_3 address: 0x{FoundAddr:X}");
                Close();
            }
            else if (savedMem.Count == 0)
            {
                MessageBox.Show($"Cannot find DsgVar_3 address - try again.");
                Close();
            }

            step++;
            InitStep();
        }

        private void InitStep()
        {
            switch (step)
            {
                case 0:
                    title.Text = "Walking";
                    description.Text = "Pause the game while walking or running and press Next.";
                    searchFor = 2;
                    break;

                case 1:
                    title.Text = "Standing";
                    description.Text = "Pause the game while standing and press Next.";
                    searchFor = 0;
                    break;

                case 2:
                    title.Text = "Jumping";
                    description.Text = "Pause the game while jumping (Rayman has to be midair and moving upwards) and press Next.";
                    searchFor = 11;
                    break;

                case 3:
                    title.Text = "Falling";
                    description.Text = "Pause the game while falling (Rayman has to be midair and moving downwards) and press Next.";
                    searchFor = 13;
                    break;

                default:
                    step = 0;
                    InitStep();
                    break;
            }
        }

        private void MemSearch(byte value)
        {
            int handle = Memory.GetProcessHandle("pcsx2");
            if (handle == 0)
            {
                MessageBox.Show("PCSX2 not detected. Start PCSX2 and the game first, or launch RevoGlmViewer as admin if it's already running.");
                return;
            }

            int _ = 0;
            byte[] buffer;
            List<int> found = new List<int>();

            if (savedMem == null)
            {
                buffer = new byte[0x4000000];
                Memory.ReadProcessMemory(handle, BaseAddr, buffer, buffer.Length, ref _);

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == value)
                    {
                        found.Add(BaseAddr + i);
                    }
                }
            }
            else
            {
                buffer = new byte[1];

                foreach (int i in savedMem)
                {
                    Memory.ReadProcessMemory(handle, i, buffer, 1, ref _);
                    if (buffer[0] == value)
                    {
                        found.Add(i);
                    }
                }
            }

            savedMem = found;
            addrCount.Text = savedMem.Count.ToString();
        }
    }
}
