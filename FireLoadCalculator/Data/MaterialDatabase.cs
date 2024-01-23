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
        private SQLiteAsyncConnection db;

        public MaterialDatabase(FireLoadCalculatorDatabase _db) {
            db = _db.Database;
        }

        public async Task<List<Material>> GetItemsAsync()
        {
            return await db.Table<Material>().ToListAsync();
        }

        public async Task<Material> GetItemAsync(int id)
        {
            return await db.Table<Material>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Material item)
        {
            if (item.Id != 0)
            {
                return await db.UpdateAsync(item);
            }
            else
            {
                return await db.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(Material item)
        {
            return await db.DeleteAsync(item);
        }
    }
}