using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTableWithDataAdapter
{
    class PersonCommandBuilder
    {
        private SqlCommand _command;
        private SqlConnection _connection;

        public PersonCommandBuilder(SqlConnection conn)
        {
            this._command = new SqlCommand("", conn);
            this._connection = conn;
        }

        public PersonCommandBuilder Query(string query)
        {
            this._command = new SqlCommand(query, this._connection);
            return this;
        }

        public PersonCommandBuilder withFirstName()
        {
            this._command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
            return this;
        }

        public PersonCommandBuilder withLastName()
        {
            this._command.Parameters.Add("@LastName", SqlDbType.NVarChar, 30, "LastName");
            return this;
        }

        public PersonCommandBuilder withOriginalID()
        {
            this._command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
                .SourceVersion = DataRowVersion.Original;
            return this;
        }
        public SqlCommand Build()
        {
            return this._command;
        }
    }
}
