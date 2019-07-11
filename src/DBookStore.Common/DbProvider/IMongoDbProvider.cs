using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.DbProvider
{
    public interface IMongoDbProvider<T>
    {
        IMongoCollection<T> GetConnection();
    }
}
