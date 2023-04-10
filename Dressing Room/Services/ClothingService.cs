﻿using Dressing_Room.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Services
{
    public class ClothingService
    {
        public SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Clothes>();
        }

        public async Task AddClothes(Clothes clothes)
        {
            await Init();
            await db.InsertAsync(clothes);



        }

        public async Task<List<Clothes>> GetClothes()
        {
            await Init();
            var result = await db.Table<Clothes>().ToListAsync(); // This gets all the user in the database
            return result;
        }


    }
}
