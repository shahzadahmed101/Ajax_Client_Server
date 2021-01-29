using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;


namespace assignment2
{
   
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Marksheet : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public string Calculate()
        {
            var request = HttpContext.Current.Request.Params;
            var student = JsonConvert.DeserializeObject <Student>(request["student_details"]);

            Course MinSubjectMarks = student.subjects.First(x => x.marks == student.subjects.Min(y => y.marks));
            Course MaxSubjectMarks = student.subjects.First(x => x.marks == student.subjects.Max(y => y.marks));


            Result result = new Result()
            {
                MinSubject = MinSubjectMarks,
                MaxSubject = MaxSubjectMarks,
                Percentage = student.Percentage()
            };


            return JsonConvert.SerializeObject(result);
        }
        
    }
}
