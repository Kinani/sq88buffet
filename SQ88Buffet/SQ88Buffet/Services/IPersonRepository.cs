using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Services
{
    public interface IPersonRepository
    {
        List<Person> GetAllPersonsData();
        Person GetPersonData();
        void DeleteAllPersons();
        void DeletePerson(int id);
        void InsertPerson(Person person);
        void UpdatePerson(Person person);
    }
}
