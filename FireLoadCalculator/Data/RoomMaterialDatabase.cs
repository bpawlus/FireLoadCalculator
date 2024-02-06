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

        public async Task<List<RoomMaterial>> GetItemsByRoomIdAsync(int id)
        {
            return await db.Table<RoomMaterial>().Where(i => i.RoomId == id).ToListAsync();
        }

        public async Task<double> GetFireLoadByRoomId(int id)
        {
            var roommaterials = await Constants.RoomMaterial_DB.GetItemsByRoomIdAsync(id);
            double result = 0;
            foreach (var roommaterial in roommaterials)
            {
                if (roommaterial == null) continue;
                var material = await Constants.Material_DB.GetItemAsync(roommaterial.MaterialId);
                if (material == null) continue;
                result += material.CombustionHeat * roommaterial.MaterialWeight * roommaterial.MaterialCount;
            }
            return result;
        }

        public async Task<double> GetFireLoadAllRooms()
        {
            double result = 0;
            var rooms = await Constants.Room_DB.GetItemsAsync();
            
            foreach (var room in rooms)
            {
                result += await GetFireLoadByRoomId(room.Id);
            }
            return result;
        }

        public async Task<string> GetFireLoadDensityAllRooms()
        {
            var fireLoad = await GetFireLoadAllRooms();
            var area = await Constants.Room_DB.GetItemsTotalArea();

            try
            {
                fireLoad /= area;

                if (Double.IsNaN(fireLoad)) 
                    throw new DivideByZeroException();

                if (fireLoad > Constants.MaxTotalFireLoadDisplay) return String.Format(">{0:0.##}", Constants.MaxTotalFireLoadDisplay);
                else return String.Format("{0:0.##}", fireLoad);
            }
            catch (DivideByZeroException e)
            {
            }

            return "∞";
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
