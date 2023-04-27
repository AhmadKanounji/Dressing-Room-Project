using System;
using System.Net.Http;
using System.Text;
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
        public async Task UpdateUserPassword(string username, string newPassword)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                user.Password = newPassword;
                await db.UpdateAsync(user);
            }
        }

        public async Task<string> getPassword(string username)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
            return user.Password;
        }

        public async Task deleteAccount(string username)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                await db.DeleteAsync(user);
            }

        }

        public async Task<List<User>> GetUser()
        {
            await Init();
            var result = await db.Table<User>().ToListAsync();
            if (result.Count == 0)
            {
                await Shell.Current.DisplayAlert("test", "test", "hello");
            }
            // This gets all the user in the database
            return result;
        }


    }
}