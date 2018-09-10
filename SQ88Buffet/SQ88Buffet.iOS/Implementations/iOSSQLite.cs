using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQ88Buffet.Helpers;
using SQLite.Net;
using UIKit;

namespace SQ88Buffet.iOS.Implementations
{
    public class iOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
            // Create the connection  
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLiteConnection(plat, path);
            // Return the database connection  
            return conn;
        }
    }
}