using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using KeBei.Models;

namespace KeBei.Data
{
    public class DataBClass
    {
        readonly SQLiteAsyncConnection _database;

        public DataBClass(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<BClass>().Wait();
        }
        //任务List<Note>   询问数据库并以List<>形式返回数据
        public Task<List<BClass>> GetDataBClasssAsync()
        {
            return _database.Table<BClass>().ToListAsync();
        }
        //返回该id的所有数据
        public Task<BClass> GetDataBClassAsync(int id)
        {
            return _database.Table<BClass>()
                            .Where(j => j.ID == id)
                            .FirstOrDefaultAsync();
        }

        //where
        //id为primary key主键
        public Task<int> SaveDataBClassAsync(BClass datacell)
        {
            if (datacell.ID != 0)
            {
                //返回
                return _database.UpdateAsync(datacell);
            }
            else
            {
                //
                return _database.InsertAsync(datacell);
            }
        }

        public Task<int> DeleteDataBClassAsync(BClass datacell)
        {
            return _database.DeleteAsync(datacell);
        }
    }
}