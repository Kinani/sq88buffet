using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public async Task DeleteAllPersons()
        {
            await _databaseHelper.DeleteAllPersons();
        }

        public async Task DeletePerson(int id)
        {
            await _databaseHelper.DeletePerson(id);
        }

        public async Task<List<Person>> GetAllPersonsData()
        {
            return await _databaseHelper.GetAllPersonsData();
        }

        public async Task<List<Person>> GetAllPersonsData(string rank)
        {
            return await _databaseHelper.GetAllPersonsData(rank);
        }

        public async Task<Person> GetPersonData(int id)
        {
            return await _databaseHelper.GetPersonData(id);
        }

        public async Task InsertPerson(Person person)
        {
            await _databaseHelper.InsertPerson(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await _databaseHelper.UpdatePerson(person);
        }
    }
}
