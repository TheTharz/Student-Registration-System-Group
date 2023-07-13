using CommunityToolkit.Mvvm.ComponentModel;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Module = StudentRegistrationSystem.Models.Module;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class ModuleRegistrationWindowVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Module> availablemodules;

        private ObservableCollection<Module> _selectedItems = new ObservableCollection<Module>();
        public ObservableCollection<Module> SelectedItems
        {
            get { return _selectedItems; }
            set { _selectedItems = value; }
        }

        public List<Module> temp;

        public ModuleRegistrationWindowVM()
        {
            availablemodules = new ObservableCollection<Module>();

            using(var db = new DataBaseContext())
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

            foreach(var module in SelectedItems)
            {
                temp.Add(module);
            }
        }
    }
}
