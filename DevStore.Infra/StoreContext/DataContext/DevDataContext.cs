using DevStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DevStore.Infra.StoreContext.DataContext
{
    public class DevDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DevDataContext()
        {
            this.Connection = new SqlConnection(Settings.ConnectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            if (this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();
        }
    }
}
