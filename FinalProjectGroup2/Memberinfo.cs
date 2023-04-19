using System;

namespace FinalProjectGroup2
{


    public class Member
    {
        //primary key
        public int Id {get; set;}
        //names
        public string FullName {get; set;}

        //birthdays
        public DateTime Birthday {get; set;}

        //college program
        public string Program {get; set;}

        //Year in program
        public string Year {get; set;}
    }
}