using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class Dilation : MatrixFilter
    {
        public Dilation()
        {
            const int size = 3;
            kernel = new float[size, size] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = sourceImage.GetPixel(x, y).R;
            float resultG = sourceImage.GetPixel(x, y).G;
            float resultB = sourceImage.GetPixel(x, y).B;
            for (int j = -radiusY; j <= radiusY; j++)
                for (int i = -radiusX; i <= radiusX; i++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    if (kernel[i + radiusX, j + radiusY] == 1.0f)
                    {
                        resultR = Math.Max(sourceImage.GetPixel(idX, idY).R, resultR);
                        resultG = Math.Max(sourceImage.GetPixel(idX, idY).G, resultG);
                        resultB = Math.Max(sourceImage.GetPixel(idX, idY).B, resultB);
                    }
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }
}
