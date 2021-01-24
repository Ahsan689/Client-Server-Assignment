using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace anotherWebApplication
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public static  List<StudentModel> Students = new List<StudentModel>();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string GetMarks()
        {
            string str = JsonConvert.SerializeObject(Students);
            return str;
        }
                

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string MinMarks()         // Minimum marks Method
        {
            double min = 0.0;
            string str = JsonConvert.SerializeObject(Students);
            foreach (var st in Students)
            {
                 min = Convert.ToDouble(Students.Min(x => x.subjectMarksObtained));
                // do something with your min, max, and curve
            }
            var newstr = Convert.ToString(min);
            return newstr;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public string maxMarksSubject()      // MAX marks subject Name
        {
            var max = "";
            var name = "";
            string str = JsonConvert.SerializeObject(Students);

            foreach (var st in Students)
            {
                max = Students.Max(x => x.subjectMarksObtained);
                name = Students.First(s => s.subjectMarksObtained == max).subjectName;
                // do something with your min, max, and curve

            }

            var newstr = name;
            return newstr;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public string MaxMarks()              // MAX marks Method
        {
            double max = 0.0;
            string str = JsonConvert.SerializeObject(Students);
            foreach (var st in Students)
            {
                max = Convert.ToDouble(Students.Max(x => x.subjectMarksObtained));
                // do something with your min, max, and curve
            }

            var newstr = Convert.ToString(max);
            return newstr;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string minMarksSubject()         // Minimum marks subject Name
        {
            var min = "";
            var name = "";
            string str = JsonConvert.SerializeObject(Students);

            foreach (var st in Students)
            {
                min = Students.Min(x => x.subjectMarksObtained);
                name = Students.First(s => s.subjectMarksObtained == min).subjectName;
                // do something with your min, max, and curve

            }

            var newstr = name;
            return newstr;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string Percent()                  // Percentage Method.
        {
            double min = 0.0;
            double sum = 0.0;
            double percent = 0.0;
            string str = JsonConvert.SerializeObject(Students);
            foreach (var st in Students)
            {
                min = Convert.ToDouble(Students.Min(x => x.Totalno));
                sum = Students.Sum(x => Convert.ToDouble(x.subjectMarksObtained));
                percent = (sum * 100) / min;
                // do something with your min, max, and curve
            }
            var newstr = Convert.ToString(percent);
            return newstr;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddMarks()                             // Marks Addition method
        {
            string studentStr = HttpContext.Current.Request.Params["request"];
            StudentModel student = JsonConvert.DeserializeObject<StudentModel>(studentStr);
            Students.Add(student);
        }



        public class StudentModel
        {
            public string subjectName { get; set; }
            public string subjectMarksObtained { get; set; }
            public string Totalno { get; set; }



        }
    }
}
