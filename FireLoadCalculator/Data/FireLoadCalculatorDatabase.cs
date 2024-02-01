using FireLoadCalculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FireLoadCalculator.Data
{
    public class FireLoadCalculatorDatabase
    {
        public SQLiteAsyncConnection Database;

        public FireLoadCalculatorDatabase() {
            Init();
        }

        async Task<SQLiteAsyncConnection> Init()
        {
            if (Database is not null)
                return Database;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Material>();
            await Database.CreateTableAsync<Room>();
            await Database.CreateTableAsync<RoomMaterial>();
            return Database;
        }
    }
}
