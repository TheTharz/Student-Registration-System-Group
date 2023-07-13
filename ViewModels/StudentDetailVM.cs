using CommunityToolkit.Mvvm.ComponentModel;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class StudentDetailVM
    {
        public StudentDetailVM(Student selectedStudent) 
        {
            var detailUser = selectedStudent;
        }

        public StudentDetailVM()
        {
            
        }
    }
}
