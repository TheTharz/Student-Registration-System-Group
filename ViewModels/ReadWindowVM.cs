using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Module = StudentRegistrationSystem.Models.Module;
using StudentModule = StudentRegistrationSystem.Models.StudentModule;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class ReadWindowVM : ObservableObject
    {
        public ObservableCollection<Student> DatabaseUsers { get; set; }

        public ReadWindowVM()
        {
            using (var db = new DataBaseContext())
            {
                DatabaseUsers = new ObservableCollection<Student>(db.Students.Select(s => new Student
                {
                    StudentId = s.StudentId,
                    Fname = s.Fname,
                    LName = s.LName,
                    GPA = s.GPA
                }));
            }
        }

        [ObservableProperty]
        public int selectedindex;

        [ObservableProperty]
        public Student user;

        //***********
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
        public int id;

        public void Assign(Student s)
        {
            id = s.StudentId;
            firstname = s.Fname;
            lastname = s.LName;
            emailt = s.Email;
            address = s.Address;
            bday = s.DOB;
        }

        public ReadWindowVM(int selectedindex,DataBaseContext pq)
        {
            temp = new List<Module>();

            using (var db = new DataBaseContext())
            {
                var selectedStudent = db.Students.Find(selectedindex);
                user = selectedStudent;
                Assign(user);
            }
            rmodules = new ObservableCollection<Module>();
            foreach (Module n in GetModulesForStudent(user.StudentId))
            {
                rmodules.Add(n);
            }
            LoadModules();
            LoadMarks(user);
            userModuleLoad(user);
        }
        [RelayCommand]
        public void ViewUser()
        {

            using (var db = new DataBaseContext())
            {
                var selectedStudent = db.Students.Find(selectedindex);
                user = selectedStudent;


                if (user != null)
                {
                    //LoadRegisteredModules(user);
                    
                    var window = new StudentDetail();
                    window.DataContext = new ReadWindowVM(selectedindex,db);//mekata overloaded constructor
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid ID", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        [RelayCommand]
        public void UpdateUser()
        {
            using (var db = new DataBaseContext())
            {
                var selectedStudent = db.Students.Find(selectedindex);
                user = selectedStudent;

            }

            if (user != null)
            {
                var db = new DataBaseContext();
                var window = new UpdateWindow();
                window.DataContext = new ReadWindowVM(selectedindex,db);//mekata overloaded constructor
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid ID", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [ObservableProperty]
        public ObservableCollection<Module> availablemodules;

        [RelayCommand]
        public void RegisterModuleWindow()
        {
            foreach (var module in SelectedItems)
            {
                temp.Add(module);
            }

            using (var db = new DataBaseContext())
            {
                var selectedStudent = db.Students.Find(selectedindex);
                user = selectedStudent;

                var window = new ModuleRegitrationWindow();
                window.DataContext = new ReadWindowVM(selectedindex, db);
                window.ShowDialog();

            }
        }

        [RelayCommand]
        public void SaveChanges()
        {
            using (var db = new DataBaseContext())
            {
                var selectedStudent = db.Students.Find(id);
                user = selectedStudent;

                Student e = user;
                e.Fname = firstname;
                e.LName = lastname;
                e.Address = address;
                e.Email = emailt;
                e.DOB = bday;

                db.SaveChanges();
            }
            //GetItemsFromDataGrid();

        }

        private ObservableCollection<Module> _selectedItems = new ObservableCollection<Module>();
        public ObservableCollection<Module> SelectedItems
        {
            get { return _selectedItems; }
            set { _selectedItems = value; }
        }

        public List<Module> temp;


        public void GetSelectedData()
        {
            //Window view = Application.Current.Windows.OfType<Window>().SingleOrDefault(w=>w.DataContext == this);
            //if(view!=null)
            //{
            //    DataGrid datagrid = view.FindName("ModuleData") as DataGrid;
            //    if (datagrid != null)
            //    {
            //        foreach (var m in datagrid.SelectedItems)
            //        {
            //            temp.Add((Module)m);
            //            temp[temp.Count-1].IsRegistered = true;
            //            //methanadi add krnna puluwn oni nm module walata register wela inna userlawa
            //        }
            //    }
            //}

            Window view = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.DataContext == this);
            if (view != null)
            {
                ListView datagrid = view.FindName("ModuleData") as ListView;
                if (datagrid != null)
                {
                    foreach (var m in datagrid.SelectedItems)
                    {
                        temp.Add((Module)m);
                        temp[temp.Count - 1].IsRegistered = true;
                        //methanadi add krnna puluwn oni nm module walata register wela inna userlawa
                    }
                }
            }
        }

        [RelayCommand]
        public void RegisterModule()
        {

            user.RegisteredModules = temp;
            StudentModule r = new StudentModule();
            r.StudentId = user.StudentId;
            DataBaseContext context = new DataBaseContext();
            foreach (Module m in temp)
            {
                r.ModuleId = m.Id;
                
                bool exists = context.StudentModules.Any(sm => sm.StudentId == user.StudentId && sm.ModuleId == m.Id);
                if (exists)
                {
                    continue;
                }
                else
                {
                    context.StudentModules.Add(r);
                    context.SaveChanges();
                }
            }

            if (user.RegisteredModules.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Success", "Ok", MessageBoxButton.OK);
            }
        }

        public void LoadModules()
        {
            availablemodules = new ObservableCollection<Module>();

            using (var db = new DataBaseContext())
            {
                availablemodules = new ObservableCollection<Module>(db.Modules.Select(m => new Module
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
        public ObservableCollection<Module> rmodules;

        public void LoadRegisteredModules(Student tempuser)
        {
            rmodules = new ObservableCollection<Module>();

            using (var dbc = new DataBaseContext())
            {
                var moduleIds = dbc.StudentModules
                               .Where(sm => sm.StudentId == tempuser.StudentId)
                               .Select(sm => sm.ModuleId);

                foreach (var i in moduleIds)
                {
                    rmodules = new ObservableCollection<Module>();

                    rmodules.Add((Module)dbc.Modules.Where(sm => sm.Id == i).Select(sm => new Module
                    {
                        Id = sm.Id,
                        ModuleName = sm.ModuleName,
                        Code = sm.Code,
                        Credits = sm.Credits,
                    }));
                }
            }
        }

        public List<Module> GetModulesForStudent(int studentId)
        {
            using (var context = new DataBaseContext())
            {
                var modules = (from sm in context.StudentModules
                               join m in context.Modules on sm.ModuleId equals m.Id
                               where sm.StudentId == studentId
                               select m).ToList();

                return modules;
            }
        }

        [ObservableProperty]
        public ObservableCollection<StudentModule> myCollection;

        [ObservableProperty]
        public ObservableCollection<Module> loadedModules;

        [RelayCommand]
        public void LoadMarks(Student p)
        {
            int mid;
            myCollection = new ObservableCollection<StudentModule>();
            loadedModules = new ObservableCollection<Module>();
            var modules = GetModulesForStudent(p.StudentId);

            using (var db = new DataBaseContext())
            {
                foreach (var k in modules)
                {
                    var studentModule = db.StudentModules.FirstOrDefault(sm => sm.ModuleId == k.Id && sm.StudentId == p.StudentId);
                    mid = studentModule != null ? studentModule.Id : 0;
                    k.addScore(studentModule.Score, k);
                    k.gpv = studentModule.Score;
                    myCollection.Add(studentModule);
                }

                foreach(var m in modules)
                {
                    loadedModules.Add(m);
                }
            }
        }

        public List<StudentModule> GetModulesForStudentssss(int studentId)
        {
            using (var context = new DataBaseContext())
            {
                var studentModules = context.StudentModules
                    .Include(sm => sm.Module)
                    .Where(sm => sm.StudentId == studentId)
                    .ToList();

                return studentModules;
            }
        }


        //gpa calculation
        public double CalculateGPA(Student student, List<StudentModule> studentModules)
        {
            int totalCredits = 0;
            double totalScore = 0;

            foreach (var studentModule in studentModules)
            {
                double score = studentModule.Score;

                if (score <= 100 && score >= 75)
                {
                    score = 4.0;
                }
                else if (score >= 70)
                {
                    score = 3.7;
                }
                else if (score >= 65)
                {
                    score = 3.4;
                }
                else if (score >= 60)
                {
                    score = 3.0;
                }
                else if (score >= 55)
                {
                    score = 2.7;
                }
                else if (score >= 50)
                {
                    score = 2.4;
                }
                else if (score >= 45)
                {
                    score = 2.1;
                }
                else if (score >= 40)
                {
                    score = 1.8;
                }
                else
                {
                    score = 0;
                }

                totalScore += score * studentModule.Module.Credits;
                totalCredits += studentModule.Module.Credits;
            }

            double averageScore = 0;
            if (totalCredits != 0)
            {
                averageScore = totalScore / totalCredits;
            }

            return Math.Round(averageScore, 2);
        }


        [ObservableProperty]
        public ObservableCollection<Module> userModules;
        [ObservableProperty]
        public double average;
        public void userModuleLoad(Student v)
        {
            var UserModules = new ObservableCollection<Module>();

            var studentModules = GetModulesForStudentssss(v.StudentId);

            double gpa = CalculateGPA(v, studentModules);

            using (var db = new DataBaseContext())
            {
                Student dbStudent = db.Students.Find(v.StudentId);
                dbStudent.GPA = gpa;
                average = gpa;
                db.SaveChanges();
            }
        }


        public void UpdateScore(int rowIndex, int columnIndex, TextBox editedCell)
        {
            // Get the student and module IDs from the first two columns of the row
            int studentId = myCollection[rowIndex].StudentId;
            int moduleId = myCollection[rowIndex].ModuleId;

            // Get the new score from the edited cell
            string newScore = editedCell.Text;
            int nscore = Convert.ToInt32(editedCell.Text);
            // Update the database
            using (var context = new DataBaseContext())
            {
                var studentModule = context.StudentModules.FirstOrDefault(sm => sm.StudentId == studentId && sm.ModuleId == moduleId);

                if (studentModule != null)
                {
                    if (columnIndex == 2)
                    {
                        // Reload the entity from the database to ensure we have the latest version
                        context.Entry(studentModule).Reload();

                        // Update the score
                        studentModule.Score = int.Parse(newScore);

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            // Handle the concurrency exception
                            ex.Entries.Single().Reload();
                            context.SaveChanges();
                        }
                    }

                }
            }
        }
    }
}
