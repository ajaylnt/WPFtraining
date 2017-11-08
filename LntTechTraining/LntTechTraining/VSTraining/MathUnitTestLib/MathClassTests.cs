using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTestLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTestLib.Tests
{
  [TestClass()]
  public class MathClassTests
  {
    [TestMethod()]
    public void mulFuncTest()
    {
      var res = MathClass.mulFunc(3, 2);
      Assert.AreEqual(6, res);
    }
  }
}