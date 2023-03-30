using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshifter.Model;

namespace workshifter.Data
{
    class WorkshiftDatabase
    {
        SQLiteAsyncConnection Database;
        public WorkshiftDatabase()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var result = await Database.CreateTableAsync<Workshift>();
        }

        public async Task<List<Workshift>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Workshift>().ToListAsync();
        }

        //public async Task<List<Workshift>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<Workshift>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<Workshift>("SELECT * FROM [Workshift] WHERE [Done] = 0");
        //}

        public async Task<Workshift> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Workshift>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Workshift item)
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

        public async Task<int> DeleteItemAsync(Workshift item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
