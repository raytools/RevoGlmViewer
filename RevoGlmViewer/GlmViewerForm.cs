using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace RevoGlmViewer
{
    public partial class GlmViewerForm : Form
    {
        public GlmViewerForm()
        {
            InitializeComponent();
        }

        private int BaseAddr;

        private CancellationTokenSource tokenSource;

        private void checkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLock.Checked)
            {
                if (!GlmEnabled()) checkLock.Checked = false;
            }
            else
            {
                GlmDisabled();
            }
        }

        private bool GlmEnabled()
        {
            string input = textAddr.Text.ToUpper();
            if (input.StartsWith("0X")) input = input.Substring(2);

            if (int.TryParse(input, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out BaseAddr))
            {
                groupGlm.Enabled = true;
                textAddr.Text = input;
                textAddr.Enabled = false;

                tokenSource = new CancellationTokenSource();
                ReadGlmLoop(tokenSource.Token);

                return true;
            }

            return false;
        }

        private void GlmDisabled()
        {
            groupGlm.Enabled = false;
            textAddr.Enabled = true;

            tokenSource?.Cancel();
        }

        private void ReadGlmLoop(CancellationToken token)
        {
            int handle = Memory.GetProcessHandle("pcsx2");
            if (handle == 0)
            {
                MessageBox.Show("PCSX2 not detected. Start PCSX2 and the game first, or launch RevoGlmViewer as admin if it's already running.");
                checkLock.Checked = false;
                return;
            }

            Thread thread = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    int _ = 0;
                    byte[] buffer = new byte[12];
                    Memory.ReadProcessMemory(handle, BaseAddr - 0x13e, buffer, buffer.Length, ref _);

                    glmX.Text = BitConverter.ToSingle(buffer, 0).ToString(CultureInfo.InvariantCulture);
                    glmY.Text = BitConverter.ToSingle(buffer, 4).ToString(CultureInfo.InvariantCulture);
                    glmZ.Text = BitConverter.ToSingle(buffer, 8).ToString(CultureInfo.InvariantCulture);

                    Thread.Sleep(500);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource?.Dispose();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.ShowDialog();

            if (search.FoundAddr != 0)
            {
                textAddr.Text = search.FoundAddr.ToString("X");
            }
        }
    }
}
