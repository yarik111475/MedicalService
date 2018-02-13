using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using PrivateService.Models;

namespace PrivateService.Repositories.Abstract {
    public abstract class AbstractMsSqlRepository {
        private string connectionString = null;
        public AbstractMsSqlRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public SqlConnection CreateConnection() {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
