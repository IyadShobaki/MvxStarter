using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxStarter.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MvxStarter.Core.ViewModels
{
    public class GuestBookViewModel : MvxViewModel
    {
        public GuestBookViewModel()
        {
            AddGuestCommand = new MvxCommand(AddGuest);
        }
        public IMvxCommand AddGuestCommand { get; set; }
        public void AddGuest()
        {
            PersonModel p = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName

            };
            FirstName = string.Empty;
            LastName = string.Empty;

            People.Add(p);
        }

        public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0; 


        private ObservableCollection<PersonModel> _people = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> People
        {
            get { return _people; }
            // SetProperty will notify any changes happend to People property,
            // if we override the entire list with a new one. But because we are using
            // ObservableCollection this will fire the notify of property change if any
            // internal changes happend to the People list.
            set { SetProperty(ref _people, value);  }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                SetProperty(ref _firstName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        public string FullName => $"{FirstName} {LastName}";

    }
}
