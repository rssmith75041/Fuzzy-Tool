using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Control_Form : Form
    {
        private ModernFuzzyController? modernFuzzy;
        private FuzzyController? fuzzyController;

        private FuzzyGraph setGraph = new FuzzyGraph(System.Drawing.Drawing2D.SmoothingMode.None);
        private ParserModern? mParser;
        private Parser? parser;

        private string[] Cat_Names = new string[10];
        private FuzzyVariable? DErrorVar;
        private FuzzyVariable? OutputVar;
        private FuzzyVariable? ErrorVar;
        private List<FuzzyRule>? Rules;

        public Fuzzy_Control_Form()
        {
            InitializeComponent();
            pnlGraph.Scroll += (s, e) => setGraph.Invalidate();
            pnlGraph.Controls!.Add(setGraph);
            setGraph.Height = 650;
            setGraph.Width = 20000;
        }

        public void Fuzzy_Firing_Form_Closed()
        {
            ckbDisplayFiring.Checked = false;
        }

        private void Fuzzy_Control_Load(object sender, EventArgs e)
        {
            SetUpFlags();
            DErrorVar = Global.FuzzyMainForm!.DErrorVar;
            OutputVar = Global.FuzzyMainForm!.OutputVar;
            ErrorVar = Global.FuzzyMainForm!.ErrorVar;
            Rules = Global.FuzzyMainForm!.Rules;

            modernFuzzy = new ModernFuzzyController(ErrorVar, DErrorVar, OutputVar, Rules);
            fuzzyController = new FuzzyController();

            mParser = new ParserModern();
            parser = new Parser();

            Global.SetupArrays();
            Global.CurrentState[0] = Global.InitialState[0];
            Global.CurrentState[1] = Global.InitialState[1];
            Global.XError = 0;
            Global.dError = 0;

            Cat_Names[1] = "NL";
            Cat_Names[2] = "NM";
            Cat_Names[3] = "NS";
            Cat_Names[4] = "ZE";
            Cat_Names[5] = "PS";
            Cat_Names[6] = "PM";
            Cat_Names[7] = "PL";

            string whichParser = Global.Which_Parser == 0 ? "Modern" : "Legacy";
            lblWhichParser.Text = $"Parser: {whichParser}";

            setGraph.Dock = DockStyle.Fill;
            setGraph.BackColor = Color.Black;
            setGraph.Clear(Color.Black);

            Draw_Y_Scale_Block();
        }

        private void Fuzzy_Control_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private string Get_Noise_Err_Msg(int r)
        {
            switch (r)
            {
                case 1: return "ERROR: 1 - undefined function name in equation X.";
                case 2: return "ERROR: 2 - attempting to take square root of negative (-) number in equation X.";
                case 3: return "ERROR: 3 - missing an open parenthesis ( in equation X.";
                case 4: return "ERROR: 4 - missing a close parenthesis ) in equation X.";
                case 5: return "ERROR: 5 - unkown operator in equation X, legal operators are: ^ * / + -.";
                case 6: return "ERROR: 6 - missing ) or unknown command in equation X.";
                case 7: return "ERROR: 7 - possible divide by error because X is used as divisor in equation X.";
                case 8: return "ERROR: 8 - possible power error";
            }

            return string.Empty;
        }

        private int istr_int = 0;
        private void btnNoise_Click(object sender, EventArgs e)
        {
            if (Global.Noiseq.Trim() == "") { return; }

            string answer2 = string.Empty;
            string formula = string.Empty;
            string answer = string.Empty;
            string tester = string.Empty;
            string temp = string.Empty;
            string istr = string.Empty;
            int slength = 0;
            int pos = 0;
            int r = 0;

            if (Global.Noise1 != 0)
            {
                Global.Noiseq = Global.Noiseq.ToUpper();
                tester = $"{Global.CurrentState[0]:F5}";
                istr = $"{istr_int++}";
                temp = Global.Noiseq;
                slength = temp.Length;
                formula = "";

                while (slength > 0)
                {
                    pos = temp.IndexOf("X");  // Get position.

                    if (pos >= 0)
                    {
                        formula += temp.Substring(0, pos).Trim();
                        formula += tester.Trim();
                        temp = temp.Substring(pos + 1);
                        slength = temp.Length;
                    }
                    else
                    {
                        formula += temp.Trim();
                        slength = 0;
                    }
                }

                temp = formula;
                formula = "";
                slength = temp.Length;

                while (slength > 0)
                {
                    pos = temp.IndexOf("Z");  // Get position.

                    if (pos >= 0)
                    {
                        formula += temp.Substring(0, pos).Trim();
                        formula += istr.Trim();
                        temp = temp.Substring(pos + 1);
                        slength = temp.Length;
                    }
                    else
                    {
                        formula += temp.Trim();
                        slength = 0;
                    }
                }

                answer = parser!.Evaluate(formula).ToString();
            }

            if (Global.Noise2 != 0)
            {
                Global.Noiseq = Global.Noiseq.ToUpper();
                tester = $"{Global.CurrentState[1]:F5}";
                istr = $"{istr_int++}";
                formula = "";
                temp = Global.Noiseq;
                slength = temp.Length;

                while (slength > 0)
                {
                    pos = temp.IndexOf('X');

                    if (pos >= 0)
                    {
                        formula += temp.Substring(0, pos);
                        formula += tester.Trim();
                        temp = temp.Substring(pos + 1);
                        slength = temp.Length;
                    }
                    else
                    {
                        formula += temp.Trim();
                        slength = 0;
                    }
                }

                temp = formula;
                formula = "";
                slength = temp.Length;

                while (slength > 0)
                {
                    pos = temp.IndexOf("Z"); // Get position.

                    if (pos >= 0)
                    {
                        formula += temp.Substring(0, pos);
                        formula += istr.Trim();
                        temp = temp.Substring(pos + 1);
                        slength = temp.Length;
                    }
                    else
                    {
                        formula += temp.Trim();
                        slength = 0;
                    }
                }

                //noise for Y2
                answer2 = parser!.Evaluate(formula).ToString();
            }

            string msg = Get_Noise_Err_Msg(r);
            if (msg != "") { MessageBox.Show(msg); }
            if (Global.Noise1 != 0) { Global.CurrentState[0] = float.Parse(answer); }
            if (Global.Noise2 != 0) { Global.CurrentState[1] = float.Parse(answer2); }

            //Calculate error and change in error
            if (!ckbXVelocityAsDError.Checked)
            {
                Global.dError = (Global.CurrentState[0] - Global.IdealState[0]) - Global.XError;
            }
            else
            {
                Global.dError = Global.CurrentState[1]; //X Velocity as dError
            }

            Global.XError = Global.CurrentState[0] - Global.IdealState[0];
        }

        private void RefreshSetGraph()
        {
            setGraph.Clear(Color.Black);

            // Background + palette equivalent
            setGraph.BackColor = Color.Black;
            int height = setGraph.Height;

            for (int j = 0; j < 7; j++)
            {
                // Skip empty sets (VB6: if fuzzyset(j,0) <> "")
                if (string.IsNullOrWhiteSpace(Global.FuzzySet[j, 0])) { continue; }
                using Pen pen = new Pen(Color.FromArgb(50 + j * 20, 100 + j * 10, 200 - j * 20), 2);
                bool first = true;
                float lastX = 0;
                float lastY = 0;
                int ff = 0;

                for (int i = 0; i < 4; i++)
                {
                    string raw = Global.FuzzySet[j, i]!.Trim();

                    // VB6: If empty AND i=1 then skip whole set
                    if (string.IsNullOrEmpty(raw) && i == 0) { break; }
                    if (raw == "") { break; }
                    // Skip INF values here; handled later
                    if (raw == "INF" || raw == "-INF")
                    {
                        ff = 1 - ff;
                        continue;
                    }

                    float x = float.Parse(raw);
                    float y = ff;

                    float py = Height - (y * height);
                    if (!first) { setGraph.DrawLine(pen, lastX, lastY, x, py); }
                    lastX = x;
                    lastY = py;
                    first = false;
                    ff = 1 - ff;
                }
            }

            // Now handle INF / -INF extension logic
            float p1 = Math.Abs(float.Parse(Global.FuzzySet[0, 1]) - float.Parse(Global.FuzzySet[0, 2]));
            float p2 = Math.Abs(float.Parse(Global.FuzzySet[6, 1]) - float.Parse(Global.FuzzySet[6, 0]));
            float maxp = Math.Max(p1, p2);

            // Left infinite
            if (Global.FuzzySet[0, 0].Trim() == "-INF")
            {
                using Pen pen = new Pen(Color.FromArgb(50, 100, 200), 2);
                float x = float.Parse(Global.FuzzySet[0, 1]) - maxp;
                float y = height;
                setGraph.DrawLine(pen, x, y, float.Parse(Global.FuzzySet[0, 1]), y);
            }

            // Right infinite
            if (Global.FuzzySet[6, 2].Trim() == "INF")
            {
                using Pen pen = new Pen(Color.FromArgb(170, 160, 60), 2);
                float x = float.Parse(Global.FuzzySet[6, 1]) + maxp;
                float y = height;
                setGraph.DrawLine(pen, float.Parse(Global.FuzzySet[6, 1]), y, x, y);
            }

            setGraph.Invalidate();
        }

        private void SetUpFlags()
        {
            Global.Pause_Execution = false;
            Global.Stop_Execution = true;
            Global.Executing = false;
            Global.Stepping = false;
        }

        private void btnStep_Click(object sender, EventArgs e) //Index 10
        {
            Global.Pause_Execution = false;
            Global.Stepping = true;

            if (!Global.Executing)
            {
                if (Global.CategoryValuesFlag && Global.XGridValuesFlag && Global.FuzzySetsFlag && Global.IdealFlag && Global.InitialFlag)
                {
                    Global.Stop_Execution = false;
                    Global.Executing = true;
                    btnRefresh.Enabled = false;
                    btnClose.Enabled = false;
                    btnExecute.Enabled = false;
                    btnPause.Enabled = false;
                    btnStop.Enabled = true;
                    btnResume.Enabled = true;
                    Execute_System();
                }
                else { MessageBox.Show("You haven't set up the whole system yet!", "Setup"); }
            }
        }

        private void btnResume_Click(object sender, EventArgs e) //Index = 5
        {
            Global.Pause_Execution = false;
            Global.Stepping = false;

            btnResume.Enabled = false;
            btnPause.Enabled = true;
            btnStep.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e) //Index = 4
        {
            Global.Stop_Execution = true;
            Global.Executing = false;
            Global.Stepping = false;

            btnStep.Enabled = true;
            btnResume.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnExecute.Enabled = true;
            btnClose.Enabled = true;
            btnRefresh.Enabled = true;

            pnlGraph.AutoScrollPosition = new Point(Global.yx - pnlGraph.Width / 2, pnlGraph.AutoScrollPosition.Y);
        }

        private void btnPause_Click(object sender, EventArgs e) //Index = 3
        {
            Global.Pause_Execution = true;
            btnPause.Enabled = false;
            btnResume.Enabled = true;
            btnStep.Enabled = true;

            pnlGraph.AutoScrollPosition = new Point(Global.yx - pnlGraph.Width / 2, pnlGraph.AutoScrollPosition.Y);
        }

        private void btnExecute_Click(object sender, EventArgs e) //Index = 2
        {
            if (Global.CategoryValuesFlag && Global.XGridValuesFlag && Global.FuzzySetsFlag && Global.IdealFlag && Global.InitialFlag)
            {
                Global.Stop_Execution = false;
                Global.Pause_Execution = false;
                Global.Stepping = false;
                Global.Executing = true;
                btnRefresh.Enabled = false;
                btnClose.Enabled = false;
                btnExecute.Enabled = false;
                btnPause.Enabled = true;
                btnStop.Enabled = true;

                Execute_System();
            }
            else { MessageBox.Show("You haven't set up the whole system yet!"); }
        }

        private void btnClose_Click(object sender, EventArgs e) //Index = 1
        {
            Global.Executing = false;
            Global.Stepping = false;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e) // Index = 0
        {
            RefreshSetGraph();
            Global.yder = 0;
            Global.yx = 0;

            Global.CurrentState[0] = Global.InitialState[0];
            Global.CurrentState[1] = Global.InitialState[1];
            Global.XError = Global.CurrentState[0] - Global.IdealState[0];

            float prevError = Global.XError;
            float errorNow = Global.CurrentState[0] - Global.IdealState[0];
            if (!ckbXVelocityAsDError.Checked) { Global.dError = errorNow - prevError; }
            else { Global.dError = Global.CurrentState[1]; } //X Velocity as dError
            Global.XError = errorNow;
            Global.Fuzzy = 0;

            if (Global.FuzzyFiringForm != null)
            {
                Global.FuzzyFiringForm!.Reset_All();
                Global.FuzzyFiringForm.Fuzzy_Values = Global.CategoryValues;
            }

            Global.Executing = false;
            Global.Stepping = false;

            btnResume.Enabled = false;
            btnExecute.Enabled = true;
            btnRefresh.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnClose.Enabled = true;
            btnStep.Enabled = true;

            pnlGraph.AutoScrollPosition = new Point(Global.yx - pnlGraph.Width / 2, pnlGraph.AutoScrollPosition.Y);
        }

        private void Exec_ModelOf_System()
        {
            string[] eqs = Global.Equations!;
            float FuzzyNo;

            FuzzyNo = Global.Fuzzy;
            float[] result;
            int r = 0;

            if (Global.Which_Parser is 0)
            {
                result = new float[3];

                r = mParser!.Process_Equations_N(eqs, Global.Step_h, FuzzyNo, Global.CurrentState, out result, Global.Interval);
                Global.CurrentState = result;
            }
            else
            {
                string YOUT1 = "", YOUT2 = "";

                r = parser!.Process_Equations(eqs[0], eqs[1], Global.Step_h, FuzzyNo, Global.CurrentState[0], Global.CurrentState[1],
                    ref YOUT1, ref YOUT2, Global.Interval);
                result = new float[2];
                result[0] = float.Parse(YOUT1);
                result[1] = float.Parse(YOUT2);
                Global.CurrentState = result;
            }


            if (Global.FuzzyFiringForm != null)
            {
                switch (Global.Equations!.Length)
                {
                    case 0: Global.FuzzyFiringForm!.Youts_While_Firing = $"Current State: {result[0]}\r\nPrevious State: {result[1]}\r\n" +
                            $"2nd Previous State: {result[2]}\r\n"; break;
                    default: Global.FuzzyFiringForm!.Youts_While_Firing = $"Current State: {result[0]}\r\nPrevious State: {result[1]}\r\n"; break;
                }
            }

            if (r != 0) { MessageBox.Show($"Parser Error {r}"); btnStop_Click(new object(), EventArgs.Empty); }
            if (ckbDisplayFiring.Checked && Global.FuzzyFiringForm != null)
            {
                if (Global.FuzzyFiringForm is null)
                {
                    Global.FuzzyFiringForm = new Fuzzy_Firing_Form();
                    Global.FuzzyFiringForm.MdiParent = this.MdiParent;
                    Global.FuzzyFiringForm.Show();
                }

                Global.FuzzyFiringForm.Invalidate();
                //Global.FuzzyFiringForm!.Youts_While_Firing = $"xErrorP: {Global.XError}, dError: {Global.dError}: IdealState[0]: {Global.IdealState[0]}: " +
                //    $"CurrentState[0]: {Global.CurrentState[0]}: DeealState[0] - CurrentState[0]: {Global.IdealState[0] - Global.CurrentState[0]}";
                //Global.FuzzyFiringForm.Invalidate();
            }
        }

        private int[]? catData;
        private void Execute_System()
        {
            int iterationNumber = 0;

            while (!Global.Stop_Execution)
            {
                while (!Global.Pause_Execution && !Global.Stop_Execution)
                {
                    //Calculate error and change in error
                    float prevError = Global.XError;
                    float errorNow = Global.CurrentState[0] - Global.IdealState[0];
                    if (!ckbXVelocityAsDError.Checked) { Global.dError = errorNow - prevError; }
                    else { Global.dError = Global.CurrentState[1]; } //X Velocity as dError
                    Global.XError = errorNow;

                    if (ckbDisplayGraph.Checked) { Graph_It(); }
                    //Check for Max iterations -> Max iterations reached -> Stop
                    if (iterationNumber >= Global.MaxIter && Global.MaxIter != 0) { btnStop_Click(new object(), EventArgs.Empty); }
                    //Check for Goal -> Goal reached -> stop
                    if (Global.GoalErr != 0 && Global.XError <= Global.GoalErr) { btnStop_Click(new object(), EventArgs.Empty); }

                    // Defuzzify();
                    if (!ckbLegacyVSMamdami.Checked)
                    {
                        Global.Fuzzy = fuzzyController!.Compute();
                        catData = fuzzyController!.DominantCat;
                    }
                    else { Global.Fuzzy = modernFuzzy!.Compute(Global.XError, Global.dError); }

                    Exec_ModelOf_System();
                    iterationNumber++;
                    Display_All_Firing();
                    if (Global.Stepping) { Global.Pause_Execution = true; }
                    Application.DoEvents();
                }

                Application.DoEvents();
            }
        }

        private void Display_All_Firing()
        {
            if (ckbDisplayFiring.Checked && Global.FuzzyFiringForm != null)
            {
                if (Global.FuzzyFiringForm is null)
                {
                    Global.FuzzyFiringForm = new Fuzzy_Firing_Form();
                    Global.FuzzyFiringForm.MdiParent = this.MdiParent;
                    Global.FuzzyFiringForm.Left = this.Right;
                    Global.FuzzyFiringForm.Show();
                }

                if (catData != null) { Global.FuzzyFiringForm.Category_While_Firing = $"{Global.CatNames[catData[0]]}:Err:{catData[1]}"; }
                Global.FuzzyFiringForm.Current_State_While_Firing = $"{Global.CurrentState[0]:F5}";
                Global.FuzzyFiringForm.xError_While_Firing = $"{Global.XError:F5}";
                Global.FuzzyFiringForm.dError_While_Firing = $"{Global.dError:F5}";
                Global.FuzzyFiringForm.Fuzzy_While_Firing = $"{Global.Fuzzy:F5}";
                Global.FuzzyFiringForm.Invalidate();
            }
        }

        private readonly Pen xPen = new Pen(Color.FromArgb((int)Global.xColor));
        private readonly Pen dPen = new Pen(Color.FromArgb((int)Global.dColor));
        public float lastYpx = 0f;

        private void Graph_It()
        {
            try
            {
                float data2 = 0;

                if (Global.yx >= setGraph.Width)
                {
                    setGraph.Clear(Color.Black);
                    Global.yder = 0;
                    Global.yx = 0;
                    lastYpx = 0f;
                }

                // 1) RAW VALUE (unscaled)
                float rawX = Global.XError + Global.shiftx;

                // 2) SCALE ONCE (VB6 behavior)
                Global.plotx = rawX * Global.Zoomx;

                // 3) AUTO-ZOOM (VB6 behavior)
                if (Global.autox)
                {
                    float bottom = -setGraph.Height / 2f;
                    float top = setGraph.Height / 2f;

                    // Avoid divide-by-zero
                    if (Math.Abs(rawX) < 0.000001f) { rawX = 0.000001f; }

                    if (Global.plotx > top)
                    {
                        Global.Zoomx = top / rawX;
                        Global.plotx = rawX * Global.Zoomx;
                        //Global.Update_ZX();
                    }
                    else if (Global.plotx < bottom)
                    {
                        Global.Zoomx = bottom / rawX;
                        Global.plotx = rawX * Global.Zoomx;
                        //Global.Update_ZX();
                    }
                }

                // 4) PIXEL CONVERSION (VB6 style)
                float centerY = this.setGraph.Height / 2f;
                float currY = centerY - Global.plotx;

                // 5) INTEGER ROUNDING (VB6 smear effect)
                int px = (int)Math.Round(currY);
                int lastPx = (int)Math.Round(lastYpx);

                // 6) DRAW - Controlling style
                if (!ckbDrawingStyle.Checked)
                {
                    if (Global.yx == 0) { this.setGraph.DrawLine(xPen, 0, px, 0, px); } // First pixel
                    else { this.setGraph.DrawLine(xPen, Global.yx - 1, lastPx, Global.yx, px); } // VB6-style smear line
                }
                else
                {
                    if (Global.yx == 0) { this.setGraph.Fill_Circle(xPen.Brush, 0, px, 1); } // First pixel                
                    else { this.setGraph.Fill_Circle(xPen.Brush, Global.yx - 1, lastPx, 1); } // VB6-style smear line
                }

                // 7) STORE LAST PIXEL
                lastYpx = px;

                // 8) ADVANCE X
                Global.yx++;

                data2 = Global.CurrentState[0];
                // VB6: If yder <= ScaleWidth
                if (Global.yder <= this.setGraph.Width)
                {
                    float height2 = this.setGraph.Height;
                    float centerY2 = height2 / 2f;

                    // VB6: ploty = data2 * zoomy
                    float ploty = data2 * Global.Zoomy;

                    // Convert VB6 Y to C# Y
                    float pixelY = centerY2 - ploty;

                    // Auto zoom (unchanged)
                    if (pixelY < 0 && Global.autod)
                    {
                        Global.Zoomy = (centerY2) / Math.Abs(data2);
                        ploty = data2 * Global.Zoomy;
                        pixelY = centerY2 - ploty;
                        //Global.Update_ZY();
                    }
                    else if (pixelY > height2 && Global.autod)
                    {
                        Global.Zoomy = (centerY2) / Math.Abs(data2);
                        ploty = data2 * Global.Zoomy;
                        pixelY = centerY2 - ploty;
                        //Global.Update_ZY();
                    }

                    if (!ckbDrawingStyle.Checked)
                    {
                        // DRAW - controlled circle
                        if (Global.yder == 0) { this.setGraph.DrawLine(dPen, 0, pixelY, 0, pixelY); }
                        else { this.setGraph.DrawLine(dPen, Global.yder - 1, Global.lastD, Global.yder, pixelY); }
                    }
                    else
                    {
                        // DRAW - controlled line
                        if (Global.yder == 0) { this.setGraph.Fill_Circle(dPen.Brush, 0, pixelY, 1); }
                        else { this.setGraph.Fill_Circle(dPen.Brush, Global.yder - 1, Global.lastD, 1); }
                    }

                    Global.lastD = pixelY;
                    Global.yder++;
                }
                else
                {
                    this.setGraph.Clear(Color.Black);
                    Global.yder = 0;
                }

                this.setGraph.Invalidate();
            }
            catch (OverflowException ofe)
            {
                if (Global.FuzzyFiringForm != null)
                {
                    Global.FuzzyFiringForm.Error_Messages = $"{ofe.Message}";
                }

                return;
            }
        }

        private void ckbDisplayGraph_CheckedChanged(object sender, EventArgs e)
        {
            //if (!ckbDisplayGraph.Checked) { Global.FuzzyGraphForm!.Close(); }
            //else
            //{
            //    Global.FuzzyGraphForm = new Fuzzy_Graph_Form();
            //    Global.FuzzyGraphForm.MdiParent = Global.FuzzyMainForm;
            //    Global.FuzzyGraphForm!.Show();
            //}
        }

        private void ckbDisplayFiring_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDisplayFiring.Checked)
            {
                Global.FuzzyFiringForm = new Fuzzy_Firing_Form();
                Global.FuzzyFiringForm.MdiParent = this.MdiParent;
                Global.FuzzyFiringForm.StartPosition = FormStartPosition.Manual;
                Global.FuzzyFiringForm.Left = this.Right;
                Global.FuzzyFiringForm.Top = 0;
                Global.FuzzyFiringForm.Show();
                Global.FuzzyFiringForm.Fuzzy_Values = Global.CategoryValues;
            }
        }

        private void ckbAutoX_CheckedChanged(object sender, EventArgs e)
        {
            Global.autox = ckbAutoX.Checked;
        }

        private void ckbAutoD_CheckedChanged(object sender, EventArgs e)
        {
            Global.autod = ckbAutoD.Checked;
        }

        private void ckbDrawingStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbDrawingStyle.Checked) { ckbDrawingStyle.Text = "Line"; }
            else { ckbDrawingStyle.Text = "Circle"; }
        }

        private Fuzzy_X_Weights? fxw = null;
        private void ckbDisplayFuzzyWeights_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDisplayFuzzyWeights.Checked)
            {
                fxw = new Fuzzy_X_Weights();
                fxw.StartPosition = FormStartPosition.Manual;
                fxw.MdiParent = this.MdiParent;
                fxw.Left = this.Right;
                fxw.Show();
            }
            else
            {
                fxw!.Close();
                fxw = null;
            }
        }

        private void ckbLegacyVSMamdami_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbLegacyVSMamdami.Checked)
            {
                ckbLegacyVSMamdami.Text = "Use Mamdami Fuzzy";
                btnFuzzyWorkspaceForm.Enabled = false;
                lblCurrentMode.Text = "Using Legacy Fuzzy";
            }
            else
            {
                ckbLegacyVSMamdami.Text = "Use Legacy Fuzzy";
                lblCurrentMode.Text = "Using Mamdami Fuzzy";
                btnFuzzyWorkspaceForm.Enabled = true;
            }
        }

        private void btnFuzzyWorkspaceForm_Click(object sender, EventArgs e)
        {
            Fuzzy_WorkSpace_Form form = new Fuzzy_WorkSpace_Form(ErrorVar, DErrorVar, OutputVar, Rules);
            form.MdiParent = this.MdiParent;
            form.OnFuzzyChanged = () => modernFuzzy = new ModernFuzzyController(ErrorVar, DErrorVar, OutputVar, Rules);
            form.Show();
        }

        public void Update_Parser_Message()
        {
            string whichParser = Global.Which_Parser == 0 ? "Modern" : "Legacy";
            lblWhichParser.Text = $"Parser: {whichParser}";
        }

        private void pnlGraphMeasure_Paint(object sender, PaintEventArgs e)
        {
            float yMax = (pnlGraphMeasure.Height / Global.Zoomy) / 2;
            float yCenter = pnlGraphMeasure.Height / 2;
            Graphics g = e.Graphics;

            g.DrawLine(Pens.White, pnlGraphMeasure.Width - 1, 3, pnlGraphMeasure.Width - 1, pnlGraphMeasure.Height - 3);
            g.DrawLine(Pens.White, pnlGraphMeasure.Width - 20, 3, pnlGraphMeasure.Width - 1, 3);
            g.DrawLine(Pens.White, pnlGraphMeasure.Width - 20, pnlGraphMeasure.Height - 3, pnlGraphMeasure.Width - 1, pnlGraphMeasure.Height - 3);
            g.DrawLine(Pens.White, pnlGraphMeasure.Width - 20, yCenter, pnlGraphMeasure.Width - 1, yCenter);
            g.DrawString($"+{yMax:F2}", new Font("Times New Roman", 7), Brushes.White, 3, 10);
            g.DrawString($"-{yMax:F2}", new Font("Times New Roman", 7), Brushes.White, 3, pnlGraphMeasure.Height - 20);
            g.DrawString("0", new Font("Times New Roman", 7), Brushes.White, 3, yCenter - 5);
        }

        private void Draw_Y_Scale_Block()
        {
            pnlGraphMeasure.Invalidate();
        }
    }
}
