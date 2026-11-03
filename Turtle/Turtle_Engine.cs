using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Tool
{
    public class Turtle_Engine
    {
        public Queue<Action> AnimationQueue = new Queue<Action>();
        public List<PointF> Path = new List<PointF>();
        public bool PenDown;
        public float Angle; // degrees
        public float X;
        public float Y;

        public Turtle_Engine()
        {
            X = 0;
            Y = 0;

            Path.Add(new PointF(X, Y));
            PenDown = true;
            Angle = 0;
        }

        public void ExecuteCommands(string commands)
        {
            List<string> parsedCommands = new List<string>(commands.Split(' '));

            foreach (string cmd in parsedCommands)
            {
                switch (cmd.Trim())
                {
                    case "F": Move(10); break;   // forward
                    case "B": Move(-10); break;  // backward
                    case "R": X += 10; break;    // right
                    case "L": X -= 10; break;    // left
                    case "C": Rotate(15); break; // clockwise rotation
                    case "UP": { PenDown = false; continue; }
                    case "DN": { PenDown = true; continue; }
                    case "CC": { Rotate(15); } break; // Counterclockwise rotation
                }
            }
        }

        private void Rotate(float degrees)
        {
            float stepAngle = degrees / 10;

            for (int i = 0; i < 10; i++)
            {
                AnimationQueue.Enqueue(() =>
                {
                    Angle += stepAngle;
                });
            }
        }

        public void Move(float distance)
        {
            float stepDist = distance / 20;

            for (int i = 0; i < 20; i++)
            {
                AnimationQueue.Enqueue(() =>
                {
                    float rad = Angle * (float)Math.PI / 180f;
                    float newX = X + (float)(Math.Sin(rad) * stepDist);
                    float newY = Y - (float)(Math.Cos(rad) * stepDist);

                    if (PenDown) { Path.Add(new PointF(newX, newY)); }
                    X = newX;
                    Y = newY;
                });
            }
        }
    }
}
