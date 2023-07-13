using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Module = StudentRegistrationSystem.Models.Module;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class CreateWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Module> modules;

        [ObservableProperty]
        public ObservableCollection<Student> students;

        [RelayCommand]
        public void AddModule(Module module)
        {
            modules.Add(module);
        }

        

        public CreateWindowVM()
        {
            

            students = new ObservableCollection<Student>();
            modules = new ObservableCollection<Module>();
            //modules.Add(new Module("IS1402", "Mathematics", 4, "Ally",false,1));
            //modules.Add(new Module("IS1402", "Drawing", 4, "Ally",false, 2));
            //modules.Add(new Module("IS1402", "Programming", 4, "Ally", false,3));
            //modules.Add(new Module("IS1402", "Society", 4, "Ally", false,4));

            using (var db = new DataBaseContext())
            {
                modules = new ObservableCollection<Module>(db.Modules.Select(m => new Module
                {
                    Id = m.Id,
                    ModuleName = m.ModuleName,
                    Code = m.Code,
                    Credits = m.Credits,
                }));
                db.Dispose();
            }
        }

        [ObservableProperty]
        public string firstname;
        [ObservableProperty]
        public string lastname;
        [ObservableProperty]
        public string emailt;
        [ObservableProperty]
        public string address;
        [ObservableProperty]
        public DateTime bday = DateTime.Now;
        [ObservableProperty]
        public int gen = -1;
        [ObservableProperty]
        public Module selectedmodules;

        [ObservableProperty]
        public ObservableCollection<Module> modulesselected;

        [RelayCommand]
        public void Create()
        {
            Student student = new Student();
            //modulesselected = new ObservableCollection<Module>
            //{
            //    selectedmodules
            //};
            //selectedmodules = new Module();

            if (firstname != null && lastname != null && address!=null && emailt != null && bday != null && gen!=-1)
            {
                student.Fname = firstname;
                student.LName = lastname;
                student.Address = address;
                student.Email = emailt;
                student.DOB = bday;

                if(gen == 1)
                {
                    student.Gender = "Female";
                }
                else
                {
                    student.Gender = "Male";
                }

                DataBaseContext dataBaseContext = new DataBaseContext();
                dataBaseContext.Students.Add(student);
                dataBaseContext.SaveChanges();

                students.Add(student);

                MessageBox.Show($"{firstname} {lastname} was registered successfully","Successful",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please fill all the required fields", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
