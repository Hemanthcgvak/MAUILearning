using MAUILearning.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUILearning.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProteinPowder>().Wait();
        }

        public Task<int> AddProteinPowder(ProteinPowder proteinPowder)
        {
            return _database.InsertAsync(proteinPowder);
        }

        public Task<List<ProteinPowder>> GetProteinPowders()
        {
            return _database.Table<ProteinPowder>().ToListAsync();
        }

        public Task<ProteinPowder> GetProteinPowderById(int id)
        {
            return _database.Table<ProteinPowder>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> UpdateProteinPowder(ProteinPowder proteinPowder)
        {
            return _database.UpdateAsync(proteinPowder);
        }

        public Task<int> DeleteProteinPowder(int id)
        {
            return _database.DeleteAsync<ProteinPowder>(id);
        }
    }
}
