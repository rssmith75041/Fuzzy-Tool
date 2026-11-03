using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Turtle_Pad_Form : Form
    {
        private System.Windows.Forms.Timer animTimer = new System.Windows.Forms.Timer();
        public bool IsAnimating = false;

        public Fuzzy_Turtle_Pad_Form()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            animTimer.Interval = 30; // 30 ms per frame (~33 FPS)
            animTimer.Tick += AnimTimer_Tick;
        }

        private void AnimTimer_Tick(object? sender, EventArgs e)
        {
            if (engine.AnimationQueue.Count > 0)
            {
                idleBob = (float)Math.Sin(Environment.TickCount * 0.005f) * 2f;
                var step = engine.AnimationQueue.Dequeue();
                step();

                this.Invalidate(); // redraw turtle
            }
            else { animTimer.Stop(); }
        }

        private void Fuzzy_Turtle_Pad_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Fuzzy_Turtle_Pad_Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = this.ClientSize.Width / 2;
            int cy = this.ClientSize.Height / 2;

            // 1. Draw the path
            if (engine.Path.Count > 1)
            {
                using (Pen pathPen = new Pen(Color.Blue, 2))
                {
                    for (int i = 1; i < engine.Path.Count; i++)
                    {
                        PointF p1 = Transform(engine.Path[i - 1], cx, cy);
                        PointF p2 = Transform(engine.Path[i], cx, cy);
                        g.DrawLine(pathPen, p1, p2);
                    }
                }
            }

            // 2. Draw the turtle (triangle)
            Draw_Turtle(g, cx, cy);
        }

        private Turtle_Engine engine = new Turtle_Engine();
        public void Run_Commands(string commands)
        {
            engine = new Turtle_Engine(); // reset turtle
            engine.ExecuteCommands(commands); // fills AnimationQueue
            animTimer.Start(); // begin animation
        }

        // Rotation math
        private float rad => engine.Angle * (float)Math.PI / 180f;
        private float sin => (float)Math.Sin(rad);
        private float cos => (float)Math.Cos(rad);

        private float idleBob { get; set; } = 0;

        private PointF Transform(PointF p, int cx, int cy)
        {
            return new PointF(cx + p.X, cy + p.Y);
        }

        private PointF RotatePoint(PointF pos, float x, float y)
        {
            float rx = x * cos - y * sin;
            float ry = x * sin + y * cos;
            return new PointF(pos.X + rx, pos.Y + ry);
        }

        private PointF[] RotateRect(PointF pos, RectangleF r)
        {
            return new PointF[]
            {
                    RotatePoint(pos, r.Left,  r.Top),
                    RotatePoint(pos, r.Right, r.Top),
                    RotatePoint(pos, r.Right, r.Bottom),
                    RotatePoint(pos, r.Left,  r.Bottom)
            };
        }

        //A squarish turtle
        //private void Draw_Turtle(Graphics g, int cx, int cy)
        //{
        //    // Turtle position in screen coords
        //    PointF pos = Transform(new PointF(engine.X, engine.Y), cx, cy);

        //    // Turtle body parts defined around (0,0)
        //    // These are BEFORE rotation
        //    RectangleF shell = new RectangleF(-15, -20, 30, 40);   // oval shell
        //    RectangleF head = new RectangleF(-7, -32, 14, 14);    // circle head
        //    RectangleF tail = new RectangleF(-4, 18, 8, 10);      // small tail

        //    // Leg positions
        //    RectangleF[] legs =
        //    {
        //        new RectangleF(-18, -18, 10, 14),  // left front
        //        new RectangleF(  8, -18, 10, 14),  // right front
        //        new RectangleF(-18,   6, 10, 14),  // left back
        //        new RectangleF(  8,   6, 10, 14)   // right back
        //    };

        //    // Apply rotation to all parts
        //    float rad = engine.Angle * (float)Math.PI / 180f;
        //    float sin = (float)Math.Sin(rad);
        //    float cos = (float)Math.Cos(rad);

        //    PointF RotatePoint(float x, float y)
        //    {
        //        float rx = x * cos - y * sin;
        //        float ry = x * sin + y * cos;
        //        return new PointF(pos.X + rx, pos.Y + ry);
        //    }

        //    // Helper to rotate rectangles
        //    PointF[] RotateRect(RectangleF r)
        //    {
        //        return new PointF[]
        //        {
        //    RotatePoint(r.Left,  r.Top),
        //    RotatePoint(r.Right, r.Top),
        //    RotatePoint(r.Right, r.Bottom),
        //    RotatePoint(r.Left,  r.Bottom)
        //        };
        //    }

        //    // Draw shell
        //    using (Brush shellBrush = new SolidBrush(Color.DarkOliveGreen))
        //    using (Pen shellPen = new Pen(Color.Black, 2))
        //    {
        //        g.FillPolygon(shellBrush, RotateRect(shell));
        //        g.DrawPolygon(shellPen, RotateRect(shell));
        //    }

        //    // Draw head
        //    using (Brush headBrush = new SolidBrush(Color.OliveDrab))
        //    using (Pen headPen = new Pen(Color.Black, 2))
        //    {
        //        g.FillPolygon(headBrush, RotateRect(head));
        //        g.DrawPolygon(headPen, RotateRect(head));
        //    }

        //    // Draw legs
        //    using (Brush legBrush = new SolidBrush(Color.ForestGreen))
        //    using (Pen legPen = new Pen(Color.Black, 2))
        //    {
        //        foreach (var leg in legs)
        //        {
        //            g.FillPolygon(legBrush, RotateRect(leg));
        //            g.DrawPolygon(legPen, RotateRect(leg));
        //        }
        //    }

        //    // Draw tail
        //    using (Brush tailBrush = new SolidBrush(Color.DarkGreen))
        //    using (Pen tailPen = new Pen(Color.Black, 2))
        //    {
        //        g.FillPolygon(tailBrush, RotateRect(tail));
        //        g.DrawPolygon(tailPen, RotateRect(tail));
        //    }
        //}

        //Triangle
        //private void Draw_Turtle(Graphics g, int cx, int cy)
        //{
        //    // Turtle position in screen coords
        //    PointF pos = Transform(new PointF(engine.X, engine.Y), cx, cy);

        //    // Triangle points (turtle shape)
        //    PointF[] tri =
        //    {
        //        new PointF(0, -20),   // tip
        //        new PointF(-15, 15),  // left base
        //        new PointF(15, 15)    // right base
        //    };

        //    // Rotate triangle by Engine.Angle
        //    float rad = engine.Angle * (float)Math.PI / 180f;
        //    float sin = (float)Math.Sin(rad);
        //    float cos = (float)Math.Cos(rad);

        //    for (int i = 0; i < tri.Length; i++)
        //    {
        //        float x = tri[i].X;
        //        float y = tri[i].Y;

        //        // rotation
        //        float rx = x * cos - y * sin;
        //        float ry = x * sin + y * cos;

        //        // translate to turtle position
        //        tri[i] = new PointF(pos.X + rx, pos.Y + ry);
        //    }

        //    using (Pen pen = new Pen(Color.DarkGreen, 3))
        //    {
        //        g.DrawPolygon(pen, tri);
        //    }
        //}

        //Roblox turtle
        private void Draw_Turtle(Graphics g, int cx, int cy)
        {
            // Turtle position in screen coords
            //PointF pos = Transform(new PointF(engine.X, engine.Y), cx, cy);
            PointF pos = Transform(new PointF(engine.X, engine.Y + idleBob), cx, cy);

            // Roblox turtle = blocky shapes
            // All defined around (0,0) before rotation

            // Body (shell)
            RectangleF body = new RectangleF(-20, -15, 40, 30);

            // Head
            RectangleF head = new RectangleF(-10, -35, 20, 20);

            // Legs (4 blocks)
            RectangleF[] legs =
            {
                new RectangleF(-25, -20, 12, 18),  // left front
                new RectangleF( 13, -20, 12, 18),  // right front
                new RectangleF(-25,   2, 12, 18),  // left back
                new RectangleF( 13,   2, 12, 18)   // right back
            };

            // Tail
            RectangleF tail = new RectangleF(-5, 18, 10, 12);

            // Colors (Roblox style)
            Brush shellBrush = new SolidBrush(Color.FromArgb(60, 180, 75));   // green
            Brush headBrush = new SolidBrush(Color.FromArgb(80, 200, 90));   // lighter green
            Brush legBrush = new SolidBrush(Color.FromArgb(50, 160, 60));   // darker green
            Brush tailBrush = new SolidBrush(Color.FromArgb(40, 140, 50));   // dark tail
            Pen outlinePen = new Pen(Color.Black, 2);

            // Draw body
            g.FillPolygon(shellBrush, RotateRect(pos, body));
            g.DrawPolygon(outlinePen, RotateRect(pos, body));
            Pen patternPen = new Pen(Color.FromArgb(20, 80, 20), 3);
            // vertical stripe
            g.DrawLine(patternPen, RotatePoint(pos, 0, -15), RotatePoint(pos, 0, 15));
            // horizontal stripe
            g.DrawLine(patternPen, RotatePoint(pos, -15, 0), RotatePoint(pos, 15, 0));

            // Draw head
            g.FillPolygon(headBrush, RotateRect(pos, head));
            g.DrawPolygon(outlinePen, RotateRect(pos, head));
            // Eyes (Roblox style: two black squares)
            RectangleF leftEye = new RectangleF(-6, -30, 5, 5);
            RectangleF rightEye = new RectangleF(1, -30, 5, 5);
            g.FillPolygon(Brushes.Black, RotateRect(pos, leftEye));
            g.FillPolygon(Brushes.Black, RotateRect(pos, rightEye));

            // Draw legs
            foreach (var leg in legs)
            {
                g.FillPolygon(legBrush, RotateRect(pos, leg));
                g.DrawPolygon(outlinePen, RotateRect(pos, leg));
            }

            // Draw tail
            g.FillPolygon(tailBrush, RotateRect(pos, tail));
            g.DrawPolygon(outlinePen, RotateRect(pos, tail));
        }
    }
}

/*

Add a Ninja Turtle Mask (because why not)

// Mask band
RectangleF mask = new RectangleF(-12, -32, 24, 8);
Brush maskBrush = new SolidBrush(Color.Red); // or Blue/Purple/Orange

g.FillPolygon(maskBrush, RotateRect(mask));
g.DrawPolygon(outlinePen, RotateRect(mask));

Boom. Leonardo, Raphael, Donatello, or Michelangelo — your choice.

---

Alright Russell — time to make your Roblox turtle **walk like a Roblox turtle**, not slide like a Roomba.

We’re going to alternate the legs **based on animation frames**, so as the turtle moves forward, the legs swing:

- front‑left + back‑right forward  
- then front‑right + back‑left forward  
- repeat  

Classic blocky Roblox waddle.

And the best part:  
You don’t need to change your engine — just your drawing code.

---

**STEP 1 — Add a “step phase” counter**

Put this in your form (or engine — either works):

private int walkPhase = 0;

Then update it **every animation tick**:

private void animTimer_Tick(object sender, EventArgs e)
{
    if (engine.AnimationQueue.Count > 0)
    {
        var step = engine.AnimationQueue.Dequeue();
        step();

        walkPhase++;   // advance walking animation
        this.Invalidate();
    }
}

This gives you a number that increases as the turtle moves.

---

**STEP 2 — Convert walkPhase into a leg offset**

Inside `Draw_Turtle`, add:

float legOffset = (float)Math.Sin(walkPhase * 0.25f) * 4f;

This produces a smooth oscillation between -4 and +4.

---

**STEP 3 — Apply the offset to alternating legs**

Replace your legs array with this:

RectangleF[] legs =
{
    new RectangleF(-25, -20 + legOffset, 12, 18),  // left front
    new RectangleF( 13, -20 - legOffset, 12, 18),  // right front
    new RectangleF(-25,   2 - legOffset, 12, 18),  // left back
    new RectangleF( 13,   2 + legOffset, 12, 18)   // right back
};

Notice the pattern:

- left‑front moves **up** when right‑front moves **down**
- left‑back moves **down** when right‑back moves **up**

That’s the Roblox waddle.

---

# 🟩 **STEP 4 — Everything else stays the same**

Your shell, head, tail, rotation math — all unchanged.

The turtle now waddles automatically whenever animation frames are being consumed.

---

**RESULT**

Your Roblox turtle now:

- waddles its legs as it moves  
- alternates left/right like a blocky NPC  
- looks alive instead of sliding  
- stays perfectly synced with your animation queue  
- still rotates and moves exactly as before  

It’s adorable.

---

Want to go even further?

I can add:

- **head bobbing**  
- **tail wiggle**  
- **eye blinking**  
- **jump animation**  
- **idle breathing animation**  
- **Roblox particle effects** (sparkles, hearts, smoke)  
- **shell color customization**  
- **baby turtle mode**  

Just tell me what direction you want your little guy to evolve.

*/

