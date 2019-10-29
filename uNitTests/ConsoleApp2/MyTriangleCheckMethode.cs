using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public class MyTriangleCheckMethode
    {
        public bool Check(double AB, double AC, double BC)
        {
            if (AB <= 0 || AC <= 0 || BC <= 0)
                return false;
            if ((AB + BC) <= AC || (AC + BC) <= AB || (AB + AC) <= BC)
                return false;
            return true;
        }
    }
}
