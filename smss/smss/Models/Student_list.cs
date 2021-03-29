
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace smss.Models
{
    public class Student_list
    {
        [PrimaryKey]
        public int Student_id { get; set; }
        public string Student_name { get; set; }
        public string Student_course { get; set; }
        public string Student_department { get; set; }
        public string Student_status { get; set; }

        public override string ToString()
        {
            return this.Student_name + "( " + this.Student_course + ",  " + this.Student_department + ",  " + Student_status + "  )" ;
        }
    }
}
