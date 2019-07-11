using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.DbProvider
{
    public class MongoDbProvider<T> : IMongoDbProvider<T>
    {
        private readonly string _connectionString;
        private readonly string _database;
        private readonly string _collection;

        public MongoDbProvider(IConfiguration configuration)
        {
            _connectionString = configuration["MongoDb:ConnectionString"];
            _database = configuration["MongoDb:Database"];
            _collection = configuration["MongoDb:Collection"];
        }

        public IMongoCollection<T> GetConnection()
        {
            ValidateCanCreateConnection();

            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_database);

            return database.GetCollection<T>(_collection);
        }

        private void ValidateCanCreateConnection()
        {
            if (_connectionString == null 
                || _database == null
                || _collection == null)
            {
                throw new ArgumentException($"Cannot create connection for {nameof(T)} collection.");
            }
        }
    }
}
