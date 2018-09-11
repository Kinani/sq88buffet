using System;
using System.Collections.Generic;
using System.Text;
using SQ88Buffet.Helpers;
using SQ88Buffet.Models;

namespace SQ88Buffet.Services
{
    public class PersonRepository : IPersonRepository
    {
        DatabaseHelper _databaseHelper;
        public PersonRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public void DeleteAllPersons()
        {
            _databaseHelper.DeleteAllPersons();
        }

        public void DeletePerson(int id)
        {
            _databaseHelper.DeletePerson(id);
        }

        public List<Person> GetAllPersonsData()
        {
            return _databaseHelper.GetAllPersonsData();
        }

        public Person GetPersonData(int id)
        {
            return _databaseHelper.GetPersonData(id);
        }

        public void InsertPerson(Person person)
        {
            _databaseHelper.InsertPerson(person);
        }

        public void UpdatePerson(Person person)
        {
            _databaseHelper.UpdatePerson(person);
        }
    }
}
