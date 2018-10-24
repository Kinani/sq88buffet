using SQ88Buffet.Helpers;
using SQ88Buffet.UWP.Implementations;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(UWPSQLite))]
namespace SQ88Buffet.UWP.Implementations
{
    public class UWPSQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string localFolderPath = ApplicationData.Current.LocalFolder.Path;

            var path = Path.Combine(localFolderPath, DatabaseHelper.DbFileName);
            //var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            return conn;
        }
    }
}
