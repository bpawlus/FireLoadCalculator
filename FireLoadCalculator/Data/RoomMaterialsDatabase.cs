using FireLoadCalculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator.Data
{
    public class RoomMaterialsDatabase
    {
        private SQLiteAsyncConnection db;

        public RoomMaterialsDatabase(FireLoadCalculatorDatabase _db)
        {
            db = _db.Database;
        }

        public async Task<List<RoomMaterials>> GetItemsAsync()
        {
            return await db.Table<RoomMaterials>().ToListAsync();
        }

        public async Task<RoomMaterials> GetItemAsync(int id)
        {
            return await db.Table<RoomMaterials>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(RoomMaterials item)
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

        public async Task<int> DeleteItemAsync(RoomMaterials item)
        {
            return await db.DeleteAsync(item);
        }
    }
}
