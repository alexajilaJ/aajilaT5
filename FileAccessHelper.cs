using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aajilaT5
{
    public class FileAccessHelper
    {
        private const string DB_NAME = "personaBD.db3";
        private readonly SQLiteAsyncConnection _connection;
        
        public FileAccessHelper()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Modelos.Persona>();
        }
        public async Task<List<Modelos.Persona>> GetPersonas()
        {
            return await _connection.Table<Modelos.Persona>().ToListAsync();
        }
        public async Task<Modelos.Persona> GetById(int id)
        {
            return await _connection.Table<Modelos.Persona>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Modelos.Persona customer)
        {
            await _connection.InsertAsync(customer);
        }
        public async Task Update(Modelos.Persona customer)
        {
            await _connection.UpdateAsync(customer);
        }
        public async Task Delete(Modelos.Persona customer)
        {
            await _connection.DeleteAsync(customer);
        }
    }
}
