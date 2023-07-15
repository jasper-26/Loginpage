using System;
using LoginProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LoginProject.Services
{
	public class LoginService
	{

        private readonly IMongoCollection<UserDetailModel> _booksCollection;

        public LoginService(
            IOptions<UserLoginDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<UserDetailModel>(
                bookStoreDatabaseSettings.Value.LoginCollectionName);

            Console.WriteLine(_booksCollection);
        }

        public async Task<List<UserDetailModel>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<UserDetailModel?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<UserDetailModel?> GetAsync(string username, string password) =>
            await _booksCollection.Find(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();

        public async Task CreateAsync(UserDetailModel newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, UserDetailModel updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}

