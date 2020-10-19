using System;
using System.Collections.Generic;
using KeBei.Models;
using System.Threading.Tasks;
using SQLite;



//
namespace KeBei.Data
{
    public class DataSubject
    {
        readonly SQLiteAsyncConnection _database;

        public DataSubject(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Subject>().Wait();
        }
        //任务List<Subject>   询问数据库并以List<>形式返回数据
        public Task<List<Subject>> GetSubjectsAsync()
        {
            return _database.Table<Subject>().ToListAsync();
        }


        //返回该id的所有数据
        public Task<Subject> GetSubjectAsync(int id)
        {
            return _database.Table<Subject>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
            //FirstOrDefaultAsync：只取一条明细，如果没有数据返回null， 如果明细条目大于1条取第一条
            //
        }
        //id为primary key
        public Task<int> SaveSubjectAsync(Subject subject)
        {
            if (subject.StartDateString == null)
            {
                //返回
                return _database.UpdateAsync(subject);
            }
            else
            {
                //
                return _database.InsertAsync(subject);
            }
        }

        public Task<int> DeleteSubjectAsync(Subject subject)
        {
            return _database.DeleteAsync(subject);
        }
    }
}