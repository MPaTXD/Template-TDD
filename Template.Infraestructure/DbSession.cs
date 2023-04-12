using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace Lorni.Infrastructure
{
    public class DbSession
    {
      
        public DbContext GenerateConnection(IConfiguration configuration)
        {
            var conn = new DbContext(configuration);

            if (conn.ConnectionSingleton)
            {
                var connSingleton = DbContext.GetInstance(configuration);
                conn.Connection = connSingleton.Connection;
            }
            return conn;
        }

       
    }

    public class DbContext : IDisposable
    {
        private static DbContext _instance;
        public IDbTransaction Transaction { get; set; }
        public static DbContext GetInstance(IConfiguration configuration)
        {
            if (_instance == null)
            {
                _instance = new DbContext(configuration);
            }
            return _instance;
        }
        public NpgsqlConnection Connection { get; set; }
        public bool ConnectionSingleton { get; set; }
        public DbContext(IConfiguration configuration)
        {
            try
            {
                Connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
                Connection.Open();
                ConnectionSingleton = false;
            }
            catch (Exception)
            {
                ConnectionSingleton = true;
            }
        }
        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            if (!ConnectionSingleton)
            {
                Connection?.Dispose();
            }
        }
    }

    public static class SingletonConnection
    {
        static SingletonConnection() { }


        private static NpgsqlConnection _instance;

        public static NpgsqlConnection GetInstance(IConfiguration configuration)
        {
            if (_instance == null)
            {
                _instance = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            }
            return _instance;
        }
    }
}
