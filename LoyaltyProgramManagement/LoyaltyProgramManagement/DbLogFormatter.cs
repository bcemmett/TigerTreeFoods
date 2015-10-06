using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace LoyaltyProgramManagement
{
    class SimpleLogDbConfiguration : DbConfiguration
    {
        public SimpleLogDbConfiguration()
        {
            SetDatabaseLogFormatter((context, writeAction) =>
                new SimpleDatabaseLogFormatter(context, writeAction));
        }
    }

    class SimpleDatabaseLogFormatter : DatabaseLogFormatter
    {
        public SimpleDatabaseLogFormatter(DbContext context, Action<string> writeAction)
            : base(context, writeAction)
        {
        }
        public override void LogCommand<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            foreach (DbParameter p in command.Parameters)
            {
                Write(string.Format("DECLARE @{0} NVARCHAR(MAX) = '{1}'" + Environment.NewLine, p.ParameterName, p.Value));
            }
            Write(command.CommandText + Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine);
        }

        public override void LogResult<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
        }

        public override void Opened(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        {
        }

        public override void Closed(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        {
        }
    }
}