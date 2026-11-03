using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class FuzzyGraph : Control
    {
        private SmoothingMode smoothingMode = SmoothingMode.None;
        private Bitmap? buffer;
        private Graphics? g;

        private float lastY = 0;
        private int x = 0;

        public Pen Pen = new Pen(Color.Lime, 1);
        public float Shift = 0f;
        public float Zoom = 1f;

        public FuzzyGraph(SmoothingMode mode)
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            smoothingMode = mode;
            InitBuffer();
        }

        private void InitBuffer()
        {
            if (this.Width <= 0 || this.Height <= 0) { return; }

            buffer = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(buffer);

            g.SmoothingMode = smoothingMode;
            g.Clear(Color.Black);
            lastY = 0;
            x = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InitBuffer();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (buffer == null) { return; }
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImageUnscaled(buffer!, 0, 0);
        }

        public void Reset()
        {
            lastY = 0;
            x = 0;
        }

        public void Plot(float value)
        {
            if (g != null)
            {
                float y = (value + Shift) * Zoom;

                // Flip Y axis (WinForms origin is top-left)
                y = buffer!.Height - y;

                if (x == 0) { g.DrawLine(Pen, x, y, x, y); }
                else { g.DrawLine(Pen, x - 1, lastY, x, y); }

                lastY = y;
                x++;

                if (x >= buffer!.Width)
                {
                    g.Clear(Color.Black);
                    x = 0;
                }

                if (this.Parent is ScrollableControl sc)
                {
                    sc.AutoScrollPosition = new Point(Global.yx - sc.Width / 2, sc.AutoScrollPosition.Y);
                }

                this.Invalidate();
            }
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            if (g != null)
            {
                g.DrawLine(pen, x1, y1, x2, y2);

                if (this.Parent is ScrollableControl sc)
                {
                    sc.AutoScrollPosition = new Point(Global.yx - sc.Width / 2, sc.AutoScrollPosition.Y);
                }

                this.Invalidate();
            }
        }

        public void FillRectangle(Brush brush, float x, float y, float w, float h)
        {
            if (g != null)
            {
                g.FillRectangle(brush, x, y, w, h);

                if (this.Parent is ScrollableControl sc)
                {
                    sc.AutoScrollPosition = new Point(Global.yx - sc.Width / 2, sc.AutoScrollPosition.Y);
                }

                this.Invalidate();
            }
        }

        public void Fill_Circle(Brush brush, float cx, float cy, int radius)
        {
            if (g != null)
            {
                int d = radius * 2;
                g.FillEllipse(brush, cx - radius, cy - radius, d, d);

                if (this.Parent is ScrollableControl sc)
                {
                    sc.AutoScrollPosition = new Point(Global.yx - sc.Width / 2, sc.AutoScrollPosition.Y);
                }

                this.Invalidate();
            }
        }

        public void Clear(Color c)
        {
            if (g != null)
            {
                g.Clear(Color.Black);
            }
        }
    }
}
