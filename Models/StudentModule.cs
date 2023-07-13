using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrationSystem.Models
{
    public class StudentModule
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public int Score { get; set; }

        public byte[] Version { get; set; }
    }
}
