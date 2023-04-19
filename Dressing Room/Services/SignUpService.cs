using System;
using Dressing_Room.Models;
using SQLite;

namespace Dressing_Room.Services
{
    public class SignUpService
    {

        public SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<User>();
        }

        public async Task AddUser(User user)
        {
            await Init();
            await db.InsertAsync(user);



        }

        public async Task UpdateUser(string username, string new_username, string email, byte[] photo)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
            user.Username = new_username;
            user.Email = email;
            user.Source = photo;
            await db.UpdateAsync(user);


        }

        public async Task<List<User>> GetUser()
        {
            await Init();
            var result = await db.Table<User>().ToListAsync(); // This gets all the user in the database
            return result;
        }


    }
}