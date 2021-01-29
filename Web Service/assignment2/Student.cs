using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment2
{
    public class Student
    {
        public string name { get; set; }
        public List<Course> subjects { get; set; }

        public decimal Percentage()
        {
            decimal noOfSubjects = this.subjects.Count();
            decimal totalMarks = 100 * noOfSubjects;
            decimal totalObtainMarks = this.subjects.Sum(x => x.marks);
            decimal percent = (totalObtainMarks / totalMarks) * 100;
            return percent;

        }

    }
}