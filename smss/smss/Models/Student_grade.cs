using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace smss.Models
{
    class Student_grade
    {
        [PrimaryKey]
        public int Student_id { get; set; }
        public string Student_name { get; set; }
        public string Student_subject1 { get; set; }
        public string Student_subject2 { get; set; }
        public string Student_subject3 { get; set; }

       
        public override string ToString()
        {
            return this.Student_name + "(oop : " + Student_subject1 + ", Maths :  " + Student_subject2 + ", Java : " + Student_subject3 + "  )";
        }
    }
}
