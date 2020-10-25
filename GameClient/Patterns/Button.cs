using System;
using System.Drawing;

namespace GameClient
{
    class Button
    {
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }

        ButtonAlgorithm buttonAlgorithm;

        public void SetAlgorithm(ButtonAlgorithm algorithm)
        {
            buttonAlgorithm = algorithm;
        }

        public void Activate()
        {
            buttonAlgorithm.Activate();
        }

        public bool CheckIfIsDistance(Point reference, int distance)
        {
            return (Math.Pow(coordinateX - reference.X, 2) + Math.Pow(coordinateY - reference.Y, 2)) < (distance * distance);
        }

    }
}
