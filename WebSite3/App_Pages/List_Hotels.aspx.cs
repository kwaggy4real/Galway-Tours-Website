using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



public partial class App_Pages_List_Hotels : System.Web.UI.Page
{
        string script;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        
        List<Employee> eList = new List<Employee>();
        public void Page_Load(object sender, EventArgs e1)
        {
           
            Employee e = new Employee();
             JArray array = new JArray();
             JObject obj = new JObject();
            e.Name = "Minal";
            e.Age = "24";
            
            eList.Add(e);

            e = new Employee();
            e.Name = "Santosh";
            e.Age = "24";
         
            eList.Add(e);
           
            JObject o = new JObject();
            o["Hotels"] = array;
           

             script = JsonConvert.SerializeObject(eList);
          //  serializer.Serialize(eList); 
           

            //or try deleting employee array title
          //   script = "{" +ans+"};";
            //script += "for(i = 0;i<employeeList.Employee.length;i++)";
           // script += "{";
           // script += "alert ('Name : ='+employeeList.Employee[i].Name+'Age : = '+employeeList.Employee[i].Age);";
           // script += "}";

            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(Page.GetType(), "JSON", serializer.ToString(), true);
        }
        public string getstring()
        {

            return script;
        }
    
    
    public class Employee
    {
        public string Name;
        public string Age;

    }
 
}