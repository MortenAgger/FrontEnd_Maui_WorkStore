using fwd_bilvaerksted.Models;
using SQLite;

namespace fwd_bilvaerksted.Data
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "fwd_bilvaerksted.db");

            //string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

            //if (string.IsNullOrEmpty(_dbEncryptionKey))
            //{
            //    Guid g = new Guid();
            //    _dbEncryptionKey = g.ToString();
            //    SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
            //}

            //var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);
            var dbOptions = new SQLiteConnectionString(databasePath, true);

            _connection = new SQLiteAsyncConnection(dbOptions);

            _ = Initialise();
        }

        private async Task Initialise()
        {
            await _connection.CreateTableAsync<WorkOrder>();
        }

        public async Task<List<WorkOrder>> GetModels()
        {
            return await _connection.Table<WorkOrder>().ToListAsync();
        }

        public async Task<WorkOrder> GetModel(int id)
        {
            var query = _connection.Table<WorkOrder>().Where(m => m.Id == id);


            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> AddModel(WorkOrder model)
        {
            return await _connection.InsertAsync(model);
        }

        public async Task<int> DeleteModel(WorkOrder model)
        {
            return await _connection.DeleteAsync(model);
        }

        public async Task<int> UpdateModel(WorkOrder model)
        {
            return await _connection.UpdateAsync(model);
        }
    }
}
