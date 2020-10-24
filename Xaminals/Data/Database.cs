using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using KeBei.Models;
using System.Threading.Tasks;

namespace KeBei.Data
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbpath)
        {

            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<BClass>();
            _database.CreateTableAsync<Curriculum>();
            _database.CreateTableAsync<Idea>();
            _database.CreateTableAsync<Subject>();
        }

        public Task<List<Subject>> GetSubjectsAsync()
        {
            return _database.Table<Subject>().ToListAsync();
        }
        //返回该id的所有数据
        public Task<Subject> GetSubjectAsync(int id)
        {
            return _database.Table<Subject>()
                            .Where(j => j.ID == id)
                            .FirstOrDefaultAsync();
        }

        //where
        //id为primary key主键
        public Task<int> SaveSubjectAsync(Subject datacell)
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

        public Task<int> DeleteSubjectAsync(Subject datacell)
        {
            return _database.DeleteAsync(datacell);
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
    //任务List<Note>   询问数据库并以List<>形式返回数据
    
}
