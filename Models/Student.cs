using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
        public string Fname { get; set; }
        [Key]
        public int StudentId { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public List<Module> RegisteredModules { get; set; }

        public Student()
        {
            
        }

        public Student(string fname, int id, string lName, int age, string email)
        {
            Fname = fname;
            StudentId = id;
            LName = lName;
            Age = age;
            GPA = 0;
            Email = email;
        }
       
    }
}
