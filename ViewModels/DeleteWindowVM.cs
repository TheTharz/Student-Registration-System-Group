using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class DeleteWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [RelayCommand]
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public DeleteWindowVM()
        {
            using (var db = new DataBaseContext())
            {
                students = new ObservableCollection<Student>(db.Students.Select(s => new Student
                {
                    StudentId = s.StudentId,
                    Fname = s.Fname,
                    LName = s.LName,
                    Email = s.Email,
                    GPA = s. GPA,
                }));
            }
        }


        [ObservableProperty]
        public int deleteId;

        [RelayCommand]
        public void DeleteUser(string Id)
        {
            using (var db = new DataBaseContext())
            {
                var student = db.Students.Find(deleteId);
                if (student != null)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to delete records permenently!", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        
                        db.Students.Remove(student);
                        db.SaveChanges();
                        MessageBox.Show("Student record removed successfuly","Done",MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Load();
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("User does not exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        [RelayCommand]
        public void Load()
        {
            using (var db = new DataBaseContext())
            {
                var list = db.Students.ToList();
                students = new ObservableCollection<Student>(list);
            }
        }
    }
}
