using Ejercicio1._3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._3.Controllers
{
    public class SQLiteDbContext
    {
        const string DatabaseFileName = "sqlitedatabase.db3";

        static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
        const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        SQLiteAsyncConnection Database;


        async Task Init()
        {
            if (Database is not null) 
            {
                return;
            }

            var result = await Database.CreateTableAsync<Datos>();

        }

        public async Task<List<Datos>> GetAllData()
        {
            await Init();
            return await Database.Table<Datos>().ToListAsync();
        }
    }
}
