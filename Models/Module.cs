using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public string Coordinator { get; set; }

        public bool IsRegistered { get; set; }

        public double Score { get; set; }

        public double gpv { get; set; }

        public List<Student> RegisteredStudents { get; set; }

        public Module(string code, string name, int credits, string coordinator, bool isRegistered, int id)
        {
            Code = code;
            ModuleName = name;
            Credits = credits;
            Coordinator = coordinator;
            IsRegistered = isRegistered;
            Id = id;
            Score = 0;
            gpv = 0;
        }
        public Module()
        {
            
        }

        public void addScore(double score,Module module)
        {
            module.Score = score;
        }
    }

}
