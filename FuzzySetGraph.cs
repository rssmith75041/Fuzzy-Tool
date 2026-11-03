using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class FuzzySetGraph : Control
    {
        public string[,] FuzzySet { get; set; } = new string[0, 0];

        public FuzzySetGraph()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (FuzzySet == null) { return; }
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            int width = this.Width;
            int height = this.Height;

            for (int j = 0; j < 7; j++)
            {
                if (string.IsNullOrWhiteSpace(FuzzySet[j, 0])) { continue; }
                using Pen pen = new Pen(Color.FromArgb(50 + j * 20, 100 + j * 10, 200 - j * 20), 2);

                int ff = 0;
                bool first = true;
                float lastX = 0;
                float lastY = 0;

                for (int i = 0; i < 4; i++)
                {
                    string raw = FuzzySet[j, i]!.Trim();

                    if (string.IsNullOrEmpty(raw) && i == 0) { break; }
                    if (raw == "INF" || raw == "-INF")
                    {
                        ff = 1 - ff;
                        continue;
                    }

                    float x = float.Parse(raw);
                    float y = ff;

                    float py = height - (y * height);
                    if (!first) { g.DrawLine(pen, lastX, lastY, x, py); }

                    lastX = x;
                    lastY = py;
                    first = false;
                    ff = 1 - ff;
                }
            }

            // INF extension logic
            float p1 = Math.Abs(float.Parse(FuzzySet[0, 1]) - float.Parse(FuzzySet[0, 2]));
            float p2 = Math.Abs(float.Parse(FuzzySet[6, 1]) - float.Parse(FuzzySet[6, 0]));
            float maxp = Math.Max(p1, p2);

            // Left infinite
            if (FuzzySet[0, 0].Trim() == "-INF")
            {
                using Pen pen = new Pen(Color.FromArgb(50, 100, 200), 2);
                float x = float.Parse(FuzzySet[0, 1]) - maxp;
                float y = height - height;
                g.DrawLine(pen, x, y, float.Parse(FuzzySet[0, 1]), y);
            }

            // Right infinite
            if (FuzzySet[6, 2].Trim() == "INF")
            {
                using Pen pen = new Pen(Color.FromArgb(170, 160, 60), 2);
                float x = float.Parse(FuzzySet[6, 1]) + maxp;
                float y = height - height;
                g.DrawLine(pen, float.Parse(FuzzySet[6, 1]), y, x, y);
            }
        }
    }
}
