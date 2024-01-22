using FireLoadCalculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator.Data
{
    public class MaterialDatabase
    {
        SQLiteAsyncConnection Database;
        public MaterialDatabase() {
            Init();
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Material>();
        }

        public async Task<List<Material>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Material>().ToListAsync();
        }

        public async Task<Material> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Material>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Material item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(Material item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}