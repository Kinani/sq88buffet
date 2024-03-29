﻿using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        decimal balanceTemp;

        public string Name
        {
            get => _person.Name == string.Empty? null : _person.Name;
            set
            {
                _person.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Rank
        {
            get => _person.Rank == string.Empty ? null : _person.Rank;
            set
            {
                _person.Rank = value;
                NotifyPropertyChanged("Rank");
            }
        }

        public decimal Balance
        {
            get => decimal.TryParse(_person.Balance.ToString(), out balanceTemp) ? balanceTemp : 0;
            set
            {
                _person.Balance = decimal.TryParse(value.ToString(), out balanceTemp) ? balanceTemp : 0;
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

        ObservableCollection<Person> _personsList;
        public ObservableCollection<Person> PersonsList
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
