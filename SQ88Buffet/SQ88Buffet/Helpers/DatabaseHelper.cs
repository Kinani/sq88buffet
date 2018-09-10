
using SQ88Buffet.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "buffetDB.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<Person>();
            sqliteconnection.CreateTable<Product>();
            sqliteconnection.CreateTable<Purchase>();
        }


    }
}
