using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTestLib
{
    public class MathClass
    {
      public static double AddFunc(double v1, double v2)
      {
      if ((v1 == 0) || (v2 == 0))
        throw new Exception("Value cannot be Zero");
      if ((v1 < 0) || (v2 < 0))
        throw new Exception("Value cannot be Negative");
      return v1 + v2;
      
    }

    public static double SubFunc(int v1, int v2)
    {
      if (v2 > v1)
        throw new Exception("Greater number cannot be subtracted");
      if(v1 <= 0)
        throw new Exception("First Operand should be nonzero positive number");
      return v1 - v2;
    }

    public static double mulFunc(int v1, int v2)
    {
      return v1 * v2;
    }
  }
}
