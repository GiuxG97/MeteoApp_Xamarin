using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    public class DatabaseHelper
    {

        private SQLiteAsyncConnection database;

        public DatabaseHelper()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Locations.db3");
            database = new SQLiteAsyncConnection(dbPath);
            try
            {
                database.CreateTableAsync<Entry>().Wait();
            }
            catch (AggregateException a)
            {
                System.Diagnostics.Debug.WriteLine(a);
            }
        }

        public Task<int> SaveLocationAsync(Entry location)
        {
            if (database.Table<Entry>().Where(i => i.Name == location.Name).CountAsync().Result > 0)
            {
                return database.UpdateAsync(location);
            }
            return database.InsertAsync(location);
        }

        public Task<List<Entry>> GetLocationAsync()
        {
            return database.Table<Entry>().ToListAsync();
        }
    }
}
