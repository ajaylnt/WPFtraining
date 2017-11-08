
using System.Runtime.Serialization;
using System.ServiceModel;
//If UR Operations in WCF are using any custom data types like data classes, then the classes should have attributes:
//The class should be a DataContract and the properties that represent the data should be having DataMember attribute


[DataContract]
public class Employee
{
  [DataMember]
  public int EmpID { get; set; }
  [DataMember]
  public string EmpName { get; set; }
  [DataMember]
  public string EmpAddress { get; set; }
  [DataMember]
  public int EmpSalary { get; set; }
  [DataMember]
  public int DeptID { get; set; }

  //When U want to modify the base class function in UR Derived class, then U could override them. 
  [OperationContract]
  public override string ToString()
  {
    return EmpName;
  }
}

[DataContract]
public class Dept
{
  [DataMember]
  public int DeptID { get; set; }
  [DataMember]
  public string DeptName { get; set; }
}
