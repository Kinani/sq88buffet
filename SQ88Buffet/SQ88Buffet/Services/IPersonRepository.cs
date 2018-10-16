using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQ88Buffet.Services
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersonsData();
        Task<List<Person>> GetAllPersonsData(string rank);
        Task<Person> GetPersonData(int id);
        Task DeleteAllPersons();
        Task DeletePerson(int id);
        Task InsertPerson(Person person);
        Task UpdatePerson(Person person);
    }
}
