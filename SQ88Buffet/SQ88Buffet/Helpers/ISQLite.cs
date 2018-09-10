using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
