using Dressing_Room.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Services
{
    public class OutfitsService
    {
        public SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Outfits>();
        }

        public async Task AddOutfits(Outfits outfits)
        {
            await Init();
            await db.InsertAsync(outfits);



        }

        public async Task<List<Outfits>> GetOutfits()
        {
            await Init();
            var result = await db.Table<Outfits>().ToListAsync(); // This gets all the user in the database
            return result;
        }

        public async Task<List<Outfits>> GetSpecificOutfits(string user_name)
        {
            await Init();
            var result = await db.Table<Outfits>().Where(c => c.UserID == user_name).ToListAsync();
            return result;
        }

        public async Task DdeleteOutfits(int id)
        {
            await Init();
            var outfit = await db.GetAsync<Outfits>(id);
            if (outfit != null) { await db.DeleteAsync(outfit); }


        }

        public async Task UpdateOutfits(string username, string new_username, byte[] photo)
        {
            await Init();
            var outfit = await db.Table<Outfits>().Where(u => u.UserID == username).ToListAsync();
            foreach (Outfits c in outfit)
            {
                c.UserID = new_username;
                c.ProfilePhoto = photo;
                await db.UpdateAsync(c);
            }
        }
    }
}
