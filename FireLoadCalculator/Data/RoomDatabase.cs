using FireLoadCalculator.Models;
using SQLite;

namespace FireLoadCalculator.Data
{
    public class RoomDatabase
    {
        private SQLiteAsyncConnection db;

        public RoomDatabase(FireLoadCalculatorDatabase _db)
        {
            db = _db.Database;
        }

        public async Task<List<Room>> GetItemsAsync()
        {
            return await db.Table<Room>().ToListAsync();
        }

        public async Task<Room> GetItemAsync(int id)
        {
            return await db.Table<Room>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Room item)
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

        public async Task<int> DeleteItemAsync(Room item)
        {
            return await db.DeleteAsync(item);
        }
    }
}
