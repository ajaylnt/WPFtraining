using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

/*
Web services are the most primitive Service Oriented Architecture in the .NET Community. It is now replaced by WCF and RESTFull Services. But there are many Services which are still working under Web Services Technology, so U should use them for backward Compatibility and Code Legacy.
All Web Services in .NET are classes derived from System.Web.Services.WebService. This class contain the required infrastructure for creating Proxies and SOAP Formatting for data transfer across platforms. 
Web services use a sp XML based language called WSDL(Web services Description Language) for exposing the services, its methods to the clients. .NET Programmers will use attributes for exposing the services thro WSDL.
XML Web services expose the methods only thro HTTP and SOAP. U cannot use TCP for the web services. This is the main limitation of Web Services. 
The data types used in XML Web services should be representable as XML objects, else they cannot be used within the services. 
Web Servics in .NET are saved as .asmx files. The mark up will determine the WSDL support.
All methods that U R exposing should be attributed with WebMethod. 
What are Attributes? Attributes are optional properties that are injected to the code at runtime. If the attribute is not set, the property will never be the part of the object metadata.
*/


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class EmpService : System.Web.Services.WebService
{
  const string STRCONNECTION = "Data Source=.;Initial Catalog=LntDatabase;Integrated Security=True";
  const string STRSELECTSTATEMENT = "SELECT * FROM EMPTABLE";
    public EmpService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

  [WebMethod]
  public DataSet GetAllEmployees()
  {
    //This function will connect to the database using disconnected model and return the data as a Dataset.
    SqlDataAdapter ada = new SqlDataAdapter(STRSELECTSTATEMENT, STRCONNECTION);
    
    DataSet ds = new DataSet("MyDs");
    Debug.WriteLine("Before Filling, ConnectionState: " + ada.SelectCommand.Connection.State);
    ada.Fill(ds, "EmpData");//Optional Name of the table where the data is filled...
    Debug.WriteLine("After Filling, ConnectionState: " + ada.SelectCommand.Connection.State);
    return ds;
    //DataTable table = new DataTable();
    //table.Load();
    //ds.Tables.Add(table);
    //Get the data thro connected model and convert the dataReader object to a dataTable and add the table to the dataset...
    //return ds;
  }
    
}