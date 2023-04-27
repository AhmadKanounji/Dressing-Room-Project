using Dressing_Room.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Services
{
    public class FollowService
    {
        public SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<FollowedTable>();
        }

        public async Task AddFollow(FollowedTable follow)
        {
            await Init();
            await db.InsertAsync(follow);



        }

        public async Task<List<FollowedTable>> GetFollows()
        {
            await Init();
            var result = await db.Table<FollowedTable>().ToListAsync(); // This gets all the user in the database
            return result;
        }

        public async Task<List<FollowedTable>> GetSpecificFollows(string user_name)
        {
            await Init();
            var result = await db.Table<FollowedTable>().Where(c => c.Follower == user_name).ToListAsync();
            return result;
        }

        public async Task DeleteFollow(int id)
        {
            await Init();
            var follow = await db.GetAsync<FollowedTable>(id);
            if (follow != null) { await db.DeleteAsync(follow); }


        }


    }
}

