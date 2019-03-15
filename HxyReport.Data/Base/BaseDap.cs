using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Dapper;

namespace HxyReport.Data
{
    public partial class BaseDap
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        protected BaseDap()
        {

        }
        protected IDbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        protected IDbTransaction Transaction
        {
            get { return _transaction; }
            set
            {
                _transaction = value;
                if (_transaction != null)
                    _connection = _transaction.Connection;
            }
        }

        /// <summary>
        /// Execute parameterized SQL  
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Return a list of dynamic objects, reader is closed after the call
        /// </summary>
        public IEnumerable<dynamic> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Executes a query, returning the data typed as per T
        /// </summary>
        /// <remarks>the dynamic param may seem a bit odd, but this works around a major usability issue in vs, if it is Object vs completion gets annoying. Eg type new [space] get new object</remarks>
        /// <returns>A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        public IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query<TFirst, TSecond, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 5 input parameters
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 4 input parameters
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn
        /// </summary>
        public SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            try
            {
                return SqlMapper.QueryMultiple(_connection, sql, param, transaction, commandTimeout, commandType);
            }
            catch
            {
                throw;
            }
        }
    }
}
