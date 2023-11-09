using Ejercicio1._3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._3.Controllers
{
    public class DatosDB
    {
        private SQLiteAsyncConnection _connection;

        public DatosDB()
        { }


        public async Task Init()
        {
            if (_connection is not null)
            {
                return;
            }

            _connection = new SQLiteAsyncConnection(Config.DatabasePath, Config.Flags);
            var result = await _connection.CreateTableAsync<Models.Datos>();


        }

        public DatosDB(String dbpath)
        {

            try
            {
                
                _connection = new SQLiteAsyncConnection(dbpath);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            //Creacion de objetos de base de datos
            _connection.CreateTableAsync<Models.Datos>().Wait();



        }

        //CRUD 
        public async Task<int> StoreDatos(Models.Datos datos)
        {
            await Init();
            if (datos.Id == 0)
            {
                return await _connection.InsertAsync(datos);
            }
            else
            {
                return await _connection.UpdateAsync(datos);
            }
        }

        //read list
        public async Task<List<Models.Datos>> ListaDatos()
        {
            await Init();
            return await _connection.Table<Models.Datos>().ToListAsync();
        }


        //get
        public Task<Models.Datos> GetListaDatos(int pid)
        {
            return _connection.Table<Models.Datos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }


        //delete
        public Task<int> DeleteDatos(Models.Datos datos)
        {
            return _connection.DeleteAsync(datos);
        }
    }
}
