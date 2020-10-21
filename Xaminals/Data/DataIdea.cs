using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using KeBei.Models;

namespace KeBei.Data
{
    public class DataIdea
    {
        readonly SQLiteAsyncConnection _database;

        public DataIdea(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Idea>().Wait();
        }
        //任务List<Note>   询问数据库并以List<>形式返回数据
        public Task<List<Idea>> GetIdeasAsync()
        {
            return _database.Table<Idea>().ToListAsync();
        }
        //返回该id的所有数据
        public Task<Idea> GetIdeaAsync(int id)
        {
            return _database.Table<Idea>()
                            .Where(j => j.ID == id)
                            .FirstOrDefaultAsync();
        }

        //where
        //id为primary key主键
        public Task<int> SaveIdeaAsync(Idea datacell)
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

        public Task<int> DeleteIdeaAsync(Idea datacell)
        {
            return _database.DeleteAsync(datacell);
        }
    }
}