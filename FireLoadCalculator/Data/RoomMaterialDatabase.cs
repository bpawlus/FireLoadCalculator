using FireLoadCalculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator.Data
{
    public class RoomMaterialDatabase
    {
        private SQLiteAsyncConnection db;

        public RoomMaterialDatabase(FireLoadCalculatorDatabase _db)
        {
            db = _db.Database;
        }

        public async Task<List<RoomMaterial>> GetItemsAsync()
        {
            return await db.Table<RoomMaterial>().ToListAsync();
        }

        public async Task<RoomMaterial> GetItemAsync(int id)
        {
            return await db.Table<RoomMaterial>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RoomMaterial>> GetItemByRoomIdAsync(int id)
        {
            return await db.Table<RoomMaterial>().Where(i => i.RoomId == id).ToListAsync();
        }

        public async Task<int> SaveItemAsync(RoomMaterial item)
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

        public async Task<int> DeleteItemAsync(RoomMaterial item)
        {
            return await db.DeleteAsync(item);
        }
    }
}
