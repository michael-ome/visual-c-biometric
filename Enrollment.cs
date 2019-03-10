using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using DPUruNet;
//using UareUSampleCSharp;
//using finalyearproject.cs;
//using System.Reflection;
//using System.ComponentModel;

namespace UareUSampleCSharp
    {
        public partial class Enrollment : Form
        {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

            List <Fmd> preenrollmentFmds;
            int count;

            public Enrollment()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Initialize the form.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Enrollment_Load(object sender, System.EventArgs e)
            {
                txtEnroll.Text = string.Empty;
                preenrollmentFmds = new List<Fmd>();
                count = 0;

                SendMessage(Action.SendMessage, "Place a finger on the reader.");

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

                    count++;

                    DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                    SendMessage(Action.SendMessage, "A finger was captured.  \r\nCount:  " + (count));

                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        _sender.Reset = true;
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }

                    preenrollmentFmds.Add(resultConversion.Data);

                    if (count >= 4)
                    {
                        DataResult<Fmd> resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                        if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            SendMessage(Action.SendMessage, "An enrollment FMD was successfully created.");
                            SendMessage(Action.SendMessage, "Place a finger on the reader.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                        else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                        {
                            SendMessage(Action.SendMessage, "Enrollment was unsuccessful.  Please try again.");
                            SendMessage(Action.SendMessage, "Place a finger on the reader.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                    }

                    SendMessage(Action.SendMessage, "Now place the same finger on the reader.");
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
            private void Enrollment_Closed(object sender, System.EventArgs e)
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
                    if (this.txtEnroll.InvokeRequired)
                    {
                        SendMessageCallback d = new SendMessageCallback(SendMessage);
                        this.Invoke(d, new object[] { action, payload });
                    }
                    else
                    {
                        switch (action)
                        {
                            case Action.SendMessage:
                                txtEnroll.Text += payload + "\r\n\r\n";
                                txtEnroll.SelectionStart = txtEnroll.TextLength;
                                txtEnroll.ScrollToCaret();
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        #endregion

        private void txtEnroll_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Form_Main
    {
        /// <summary>
        /// Holds fmds enrolled by the enrollment GUI.
        /// </summary>
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();

        /// <summary>
        /// Reset the UI causing the user to reselect a reader.
        /// </summary>
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        public Form_Main()
        {
            InitializeComponent();
        }

        // When set by child forms, shows s/n and enables buttons.
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
                SendMessage(Action.UpdateReaderState, value);
            }
        }
        private Reader currentReader;

        #region Click Event Handlers
        private ReaderSelection _readerSelection;
        private void btnReaderSelect_Click(System.Object sender, System.EventArgs e)
        {
            if (_readerSelection == null)
            {
                _readerSelection = new ReaderSelection();
                _readerSelection.Sender = this;
            }

            _readerSelection.ShowDialog();

            _readerSelection.Dispose();
            _readerSelection = null;
        }

        private Capture _capture;
        private void btnCapture_Click(System.Object sender, System.EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new Capture();
                _capture._sender = this;
            }

            _capture.ShowDialog();

            _capture.Dispose();
            _capture = null;
        }

        private Verification _verification;
        private void btnVerify_Click(System.Object sender, System.EventArgs e)
        {
            if (_verification == null)
            {
                _verification = new Verification();
                _verification._sender = this;
            }

            _verification.ShowDialog();

            _verification.Dispose();
            _verification = null;
        }

        private Identification _identification;
        private void btnIdentify_Click(System.Object sender, System.EventArgs e)
        {
            if (_identification == null)
            {
                _identification = new Identification();
                _identification._sender = this;
            }

            _identification.ShowDialog();

            _identification.Dispose();
            _identification = null;
        }

        private Enrollment _enrollment;
        private void btnEnroll_Click(System.Object sender, System.EventArgs e)
        {
            if (_enrollment == null)
            {
                _enrollment = new Enrollment();
                _enrollment._sender = this;
            }

            _enrollment.ShowDialog();
        }

        private Stream _stream;
        private void btnStreaming_Click(System.Object sender, System.EventArgs e)
        {
            if (_stream == null)
            {
                _stream = new Stream();
                _stream._sender = this;
            }

            _stream.ShowDialog();

            _stream.Dispose();
            _stream = null;
        }

        EnrollmentControl enrollmentControl;
        private void btnEnrollmentControl_Click(object sender, EventArgs e)
        {
            if (enrollmentControl == null)
            {
                enrollmentControl = new EnrollmentControl();
                enrollmentControl._sender = this;
            }

            enrollmentControl.ShowDialog();
        }

        IdentificationControl identificationControl;
        private void btnIdentificationControl_Click(object sender, EventArgs e)
        {
            if (identificationControl == null)
            {
                identificationControl = new IdentificationControl();
                identificationControl._sender = this;
            }

            identificationControl.ShowDialog();

            identificationControl.Dispose();
            identificationControl = null;
        }
        #endregion

        /// <summary>
        /// Open a device and check result for errors.
        /// </summary>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool OpenReader()
        {
            reset = false;
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            // Open reader
            result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                reset = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            // Activate capture handler
            currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            // Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Cancel the capture and then close the reader.
        /// </summary>
        /// <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            if (currentReader != null)
            {
                currentReader.CancelCapture();

                // Dispose of reader handle and unhook reader events.
                currentReader.Dispose();

                if (reset)
                {
                    CurrentReader = null;
                }
            }
        }

        /// <summary>
        /// Check the device status before starting capture.
        /// </summary>
        /// <returns></returns>
        public void GetStatus()
        {
            Constants.ResultCode result = currentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                reset = true;
                throw new Exception("" + result);
            }

            if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                currentReader.Calibrate();
            }
            else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + currentReader.Status.Status);
            }
        }

        /// <summary>
        /// Check quality of the resulting capture.
        /// </summary>
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    throw new Exception("Quality - " + captureResult.Quality);
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception("" + captureResult);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create a bitmap from raw data in row/column format.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        #region SendMessage
        private enum Action
        {
            UpdateReaderState
        }
        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action state, object payload)
        {
            if (this.txtReaderSelected.InvokeRequired)
            {
                SendMessageCallback d = new SendMessageCallback(SendMessage);
                this.Invoke(d, new object[] { state, payload });
            }
            else
            {
                switch (state)
                {
                    case Action.UpdateReaderState:
                        if ((Reader)payload != null)
                        {
                            txtReaderSelected.Text = ((Reader)payload).Description.SerialNumber;
                            btnCapture.Enabled = true;
                            btnStreaming.Enabled = true;
                            btnVerify.Enabled = true;
                            btnIdentify.Enabled = true;
                            btnEnroll.Enabled = true;
                            btnEnrollmentControl.Enabled = true;
                            if (fmds.Count > 0)
                            {
                                btnIdentificationControl.Enabled = true;
                            }
                        }
                        else
                        {
                            txtReaderSelected.Text = String.Empty;
                            btnCapture.Enabled = false;
                            btnStreaming.Enabled = false;
                            btnVerify.Enabled = false;
                            btnIdentify.Enabled = false;
                            btnEnroll.Enabled = false;
                            btnEnrollmentControl.Enabled = false;
                            btnIdentificationControl.Enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}

