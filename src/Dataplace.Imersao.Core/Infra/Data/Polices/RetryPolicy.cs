using Polly;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Infra.Data.Polices
{
    public sealed class RetryPolicy
    {
        public static readonly RetryPolicy Instance = new RetryPolicy();
        private readonly AsyncPolicy _retryPolicy;
        private readonly ISet<int> _errorCode = new HashSet<int>(new[] { 1205 });
        private readonly ISet<string> _errorMessage = new HashSet<string>(new[] { "deadlock", "timeout expired" });
        private const int _retries = 2;
        //private RetryPolicy()
        //{
        //    _retryPolicy = Policy
        //                .Handle<SqlException>(ex => _errorCode.Contains(ex.Number))
        //                    .Or<OdbcException>(ex => _errorMessage.Any(value => ex.Message.ToLower().Contains(value)))
        //                .WaitAndRetry(retryCount: _retries, sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
        //}


        private RetryPolicy()
        {
            _retryPolicy = Policy
                        .Handle<SqlException>()
                            .Or<OdbcException>()
                        .WaitAndRetryAsync(retryCount: _retries, sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
        }
        public void Execute(Func<Task> method) => _retryPolicy.ExecuteAsync(method);
        public Task<TResult> Execute<TResult>(Func<Task<TResult>> method)
        {
            return  _retryPolicy.ExecuteAsync(method);
        }

        //public Task<TResult> Execute<TResult>( Func<TResult> method)
        //{
        //    return _retryPolicy.ExecuteAsync(method);
        //}

    }


    public sealed class InfinityPolicy
    {
        public static readonly InfinityPolicy Instance = new InfinityPolicy();
        private readonly AsyncPolicy _retryPolicy;
        private const int _retries = 1000;

        private InfinityPolicy()
        {
            _retryPolicy = Policy
                        .Handle<Exception>()
                        .WaitAndRetryAsync(retryCount: _retries, sleepDurationProvider: attempt => TimeSpan.FromSeconds(2));
        }
        public void Execute(Func<Task> method) => _retryPolicy.ExecuteAsync(method);
        public Task<TResult> Execute<TResult>(Func<Task<TResult>> method)
        {
            return _retryPolicy.ExecuteAsync(method);
        }
    }
}
