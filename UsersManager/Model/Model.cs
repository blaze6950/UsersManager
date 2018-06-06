using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Documents;

namespace UsersManager.Model
{
    public class Model : IDisposable
    {
        private DataSet _usersDataSet;
        private DataSet _categoriesDataSet;

        private DbDataAdapter _usersAdapter;
        private DbDataAdapter _categoriesAdapter;

        private String _connectionString;
        private String _factoryName;
        private DbProviderFactory _factory;
        private DbConnection _connection;

        public Model()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UserManagerCS"].ConnectionString;
            _factoryName = ConfigurationManager.ConnectionStrings["UserManagerCS"].ProviderName;

            _factory = DbProviderFactories.GetFactory(_factoryName);
            _connection = _factory.CreateConnection();
            _connection.ConnectionString = _connectionString;

            _usersDataSet = new DataSet();
            _categoriesDataSet = new DataSet();

            LoadData();
        }

        private void LoadData()
        {
            // _usersAdapter
            _usersAdapter = _factory.CreateDataAdapter();

            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;
            command.CommandText = "SELECT * FROM Users";

            DbCommandBuilder builder = _factory.CreateCommandBuilder(); // for what?
            builder.DataAdapter = _usersAdapter;

            _usersAdapter.SelectCommand = command;

            _usersAdapter.Fill(_usersDataSet, "Users");

            // _categoriesAdapter
            _categoriesAdapter = _factory.CreateDataAdapter();

            DbCommand command1 = _factory.CreateCommand();
            command1.Connection = _connection;
            command1.CommandText = "SELECT * FROM UserCategories";

            DbCommandBuilder builder1 = _factory.CreateCommandBuilder(); // for what?
            builder1.DataAdapter = _categoriesAdapter;

            _categoriesAdapter.SelectCommand = command1;

            _categoriesAdapter.Fill(_categoriesDataSet, "UserCategories");
        }

        public DataTable GetCategories()
        {
            return _categoriesDataSet.Tables["UserCategories"];
        }

        public DataTable GetUsers()
        {
            return _usersDataSet.Tables["Users"];
        }

        public void CommitChanges()
        {
            _usersAdapter.Update(_usersDataSet, "Users");
            _categoriesAdapter.Update(_categoriesDataSet, "UserCategories");
        }

        public void RefreshData()
        {
            CommitChanges();
        }

        public DataTable GetUserCategory(List<int> id)
        {
            _usersDataSet.Clear();
            if (id.Count > 0)
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;

                command.CommandText = $"SELECT * FROM Users Where Id_Category IN (";
                int i = 0;
                foreach (var id1 in id)
                {
                    if (i == 0)
                    {
                        command.CommandText += id1;
                    }
                    else
                    {
                        command.CommandText += ", " + id1;
                    }
                    i++;
                }
                command.CommandText += ")";


                DbCommandBuilder builder = _factory.CreateCommandBuilder(); // for what?
                builder.DataAdapter = _usersAdapter;

                _usersAdapter.SelectCommand = command;
                _usersAdapter.Fill(_usersDataSet, "Users");
            }
            else
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;
                command.CommandText = "SELECT * FROM Users";

                DbCommandBuilder builder = _factory.CreateCommandBuilder(); // for what?
                builder.DataAdapter = _usersAdapter;

                _usersAdapter.SelectCommand = command;

                _usersAdapter.Fill(_usersDataSet, "Users");
            }
            return _usersDataSet.Tables["Users"];
        }

        public void Dispose()
        {
            CommitChanges();
            _usersDataSet?.Dispose();
            _categoriesDataSet?.Dispose();
            _usersAdapter?.Dispose();
            _categoriesAdapter?.Dispose();
            _connection?.Dispose();
        }
    }
}