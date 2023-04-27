using Dressing_Room.Models;
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

        public async Task<List<Clothes>> GetSpecificClothes(string user_name)
        {
            await Init();
            var result = await db.Table<Clothes>().Where(c => c.UserID == user_name).ToListAsync();
            return result;
        }
        public async Task<List<Clothes>> GetSpecificClothesByID(int ID)
        {
            await Init();
            var result = await db.Table<Clothes>().Where(c => c.CID == ID).ToListAsync();
            return result;
        }

        public async Task<List<Clothes>> GetClothesByColor(string color, string type)
        {
            await Init();
            var result = await db.Table<Clothes>().Where(c => c.Color == color && c.Categories == type).ToListAsync();
            return result;
        }


        public async Task DdeleteClothes(int id)
        {
            await Init();
            var cloth = await db.GetAsync<Clothes>(id);
            if (cloth != null) { await db.DeleteAsync(cloth); }


        }
        public async Task UpdateClothes(string username, string new_username)
        {
            await Init();
            var cloth = await db.Table<Clothes>().Where(u => u.UserID == username).ToListAsync();
            foreach (Clothes c in cloth)
            {
                c.UserID = new_username;
                await db.UpdateAsync(c);
            }
        }
    }
}


