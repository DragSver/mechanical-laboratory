using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.DataBase.Interfaces;
using Mono.Data.Sqlite;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.DataBase
{
    public class SqliteDataAccess : IDataAccess
    {
        private readonly DbConnection _connection;

        private readonly string _path = Application.dataPath + "/StreamingAssets/mechanical_laboratory.db";
        private readonly string TAG = "SQLite service: ";
        private readonly int _retryCount = 5;
        private readonly int _responseTimeout = (int)TimeSpan.FromSeconds(5).TotalSeconds;

        public SqliteDataAccess()
        {
            var connectionString = $"Data Source={_path};Version=3;";
            _connection = new SqliteConnection(connectionString);
            SetConnection();
        }
        private void SetConnection()
        {
            Debug.Log($"{TAG}starting connection on {_path} ...");

            for (int i = 1; i < _retryCount; i++)
            {
                try
                {
                    _connection.Open();
                    if (_connection.State != ConnectionState.Open)
                    {
                        Debug.Log($"{TAG}connection failed. Trying again after {_responseTimeout} ms...");
                        Thread.Sleep(_responseTimeout);
                    }
                    else return;
                }
                catch (Exception e)
                {
                    Debug.Log($"{TAG}unhandled exception - {e.Message}");
                    break;
                }
            }
        }

        public async Task<SqliteCommand> CreateCommand(string sqlCommand)
        {
            var command = new SqliteCommand();
            command.Transaction = await _connection.BeginTransactionAsync() as SqliteTransaction;
            command.Connection = _connection as SqliteConnection;
            command.CommandText = sqlCommand;

            return command;
        }
    }
}
