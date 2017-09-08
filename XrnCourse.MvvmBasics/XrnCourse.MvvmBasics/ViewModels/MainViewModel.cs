using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ClassmateInMemoryService classmateService;

        public MainViewModel()
        {
            classmateService = new ClassmateInMemoryService();
            //initialize the Classmates collection
            Classmates = new ObservableCollection<Classmate>(classmateService.GetAll().Result);
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
        
        private ObservableCollection<Classmate> classmates;
        public ObservableCollection<Classmate> Classmates
        {
            get { return classmates; }
            set {
                classmates = value;
                RaisePropertyChanged(nameof(Classmates));
            }
        }

        public ICommand SortCommand => new Command(
            async () =>
            {
                //refresh the list and sort data by Name
                var sortedMates = (await classmateService.GetAll()).OrderBy(e => e.Name).ToList();
                //reset the collection
                Classmates = new ObservableCollection<Classmate>(sortedMates);
            });
    }
}
