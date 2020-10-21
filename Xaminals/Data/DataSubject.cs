﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using KeBei.Models;

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
        //任务List<Note>   询问数据库并以List<>形式返回数据
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
    }
}