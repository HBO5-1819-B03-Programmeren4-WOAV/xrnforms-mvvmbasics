using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class ClassmateViewModel : INotifyPropertyChanged
    {
        private ClassmateInMemoryService classmateService;
        private Classmate CurrentClassmate;

        public ClassmateViewModel()
        {
            classmateService = new ClassmateInMemoryService();
            //initialize the properties with data from domain model
            CurrentClassmate = classmateService.GetAll().Result.FirstOrDefault();
            this.Name = CurrentClassmate.Name;
            this.Phone = CurrentClassmate.Phone;
            this.Birthdate = CurrentClassmate.Birthdate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if it has handlers attached to it
        /// </summary>
        /// <param name="propertyName">name of the prop that was changed</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                RaisePropertyChanged(nameof(Birthdate));
            }
        }

        public int Age
        {
            get {
                int age = DateTime.Now.Year - birthdate.Year;
                if (birthdate > DateTime.Now.AddYears(-age)) age--; //adjust for leap year
                return age;
            }
        }

    }
}
