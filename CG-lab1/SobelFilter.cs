using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class SobelFilter : MatrixFilter
    {
        public SobelFilter()
        {
            const int sizeX = 3;
            const int sizeY = 3;
            kernel = new float[sizeX, sizeY] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        }
    }
}
