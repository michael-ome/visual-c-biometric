using System;
using System.Windows.Forms;
using DPUruNet;

namespace UareUSampleCSharp
{
    public partial class Identification : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private Fmd rightIndex;
        private Fmd rightThumb;
        private Fmd anyFinger;
        private int count;

        public Identification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Identification_Load(object sender, System.EventArgs e)
        {
            txtIdentify.Text = string.Empty;
            rightIndex = null;
            rightThumb = null;
            anyFinger = null;
            count = 0;

            SendMessage(Action.SendMessage, "Place your right index finger on the reader.");

            if (!_sender.OpenReader())
            {
                this.Close();
            }

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        private void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                SendMessage(Action.SendMessage, "A finger was captured.");

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                if (count == 0)
                {
                    rightIndex = resultConversion.Data;
                    count += 1;
                    SendMessage(Action.SendMessage, "Now place your right thumb on the reader.");
                }
                else if (count == 1)
                {
                    rightThumb = resultConversion.Data;
                    count += 1;
                    SendMessage(Action.SendMessage, "Now place any finger on the reader.");
                }
                else if (count == 2)
                {
                    anyFinger = resultConversion.Data;
                    Fmd[] fmds = new Fmd[2];
                    fmds[0] = rightIndex;
                    fmds[1] = rightThumb;

                    // See the SDK documentation for an explanation on threshold scores.
                    int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                    IdentifyResult identifyResult = Comparison.Identify(anyFinger, 0, fmds, thresholdScore, 2);
                    if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        _sender.Reset = true;
                        throw new Exception(identifyResult.ResultCode.ToString());
                    }

                    SendMessage(Action.SendMessage, "Identification resulted in the following number of matches: " + identifyResult.Indexes.Length.ToString());
                    SendMessage(Action.SendMessage, "Place your right index finger on the reader.");
                    count = 0;
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);                
            }
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void btnBack_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void Identification_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }

        #region SendMessage
        private enum Action
        {
            SendMessage
        }
        private delegate void SendMessageCallback(Action action, string payload);
        private void SendMessage(Action action, string payload)
        {
            try
            {
                if (this.txtIdentify.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            txtIdentify.Text += payload + "\r\n\r\n";
                            txtIdentify.SelectionStart = txtIdentify.TextLength;
                            txtIdentify.ScrollToCaret();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}