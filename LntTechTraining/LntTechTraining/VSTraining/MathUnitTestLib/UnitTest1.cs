using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTestLib;
//A set of code that is considered as a non dependent blocked is called as Unit. We need to test those units as parts. This is called as UNIT TESTING. Programmers are recommended to create the Unit tests for their code and develop the Code to satisfy the test results so that it could be placed for integration. Unit Tests are conducted mostly on functions that might take arguments and yeild a result which is verified for the expected result...

//A class which contain an attribute called TestClass defined under the namespace Microsoft.VisualStudio.TestTools.UnitTesting. This class will contain a non parameterized, void functions that will test blocks of code thro objects that are created...
namespace MathUnitTestLib
{
  [TestClass]
  public class MathTestUnits
  {
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestForPositiveNumber()
    {
      //If an argument passed to UR Function is a negative number, then UR function should not accept it and it should throw an Exception...
      var result = MathClass.AddFunc(-123, -234);
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestForNonZeroNumber()
    {
      //If an argument passed to UR Function is a 0 then UR function should not accept it and it should throw an Exception...
      var result = MathClass.AddFunc(0, 234);
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void TestForAddingNumbers()
    {
      var result = MathClass.AddFunc(3, 2);
      Assert.AreEqual(5, result);
    }

    //Test for Sub Functions: 2nd operand should be lesser than the first. 1st operand should be positive and non 0 number. 

  }
  [TestClass]
  public class SubtractTestClass
  {
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestForSecondOperand()
    {
      var res = MathClass.SubFunc(123, 543);
      Assert.AreEqual(0, res);
    }
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestForPositiveNumber()
    {
      var res = MathClass.SubFunc(-123, -543);
      Assert.AreEqual(0, res);
    }
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestForNonZeroValue()
    {
      var res = MathClass.SubFunc(0, -324);
      Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void SubtractionTest()
    {
      var res = MathClass.SubFunc(5, 3);
      Assert.AreEqual(2, res);
    }
  }
}
