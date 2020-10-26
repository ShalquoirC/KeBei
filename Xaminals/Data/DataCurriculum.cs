using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using KeBei.Models;

namespace KeBei.Data
{
    public class DataCurriculum
    {
        readonly SQLiteAsyncConnection _database;

        public DataCurriculum(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Curriculum>().Wait();
        }
        //任务List<Note>   询问数据库并以List<>形式返回数据
        public Task<List<Curriculum>> GetCurriculumsAsync()
        {
            return _database.Table<Curriculum>().ToListAsync();
        }
        //返回该id的所有数据
        public Task<Curriculum> GetCurriculumAsync(int id)
        {
            return _database.Table<Curriculum>()
                            .Where(j => j.ID == id)
                            .FirstOrDefaultAsync();
        }

        //where
        //id为primary key主键
        public Task<int> SaveCurriculumAsync(Curriculum datacell)
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

        public Task<int> DeleteCurriculumAsync(Curriculum datacell)
        {
            return _database.DeleteAsync(datacell);
        }
        
    }
}