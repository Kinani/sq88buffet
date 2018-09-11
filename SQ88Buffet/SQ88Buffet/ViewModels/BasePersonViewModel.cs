using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class BasePersonViewModel : INotifyPropertyChanged
    {
        public Person _person;
        public INavigation _navigation;
        public IPersonRepository _personRepository;


        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Rank
        {
            get => _person.Rank;
            set
            {
                _person.Rank = value;
                NotifyPropertyChanged("Rank");
            }
        }

        public float Balance
        {
            get => _person.Balance;
            set
            {
                _person.Balance = value;
                NotifyPropertyChanged("Balance");
            }
        }

        public DateTime LastBilled
        {
            get => _person.LastBilled;
            set
            {
                _person.LastBilled = value;
                NotifyPropertyChanged("LastBilled");
            }
        }

        List<Person> _personsList;
        public List<Person> PersonsList
        {
            get => _personsList;
            set
            {
                _personsList = value;
                NotifyPropertyChanged("PersonsList");
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
