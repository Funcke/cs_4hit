using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PersonTableWithDataAdapter
{
    public partial class Form1 : Form
    {
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRUD";
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataTable _table;
        private int _recNumber;

        public Form1()
        {
            InitializeComponent();
            this._connection = new SqlConnection(this._connectionString);
            this._table = new DataTable();
            this._adapter = new SqlDataAdapter("SELECT * FROM Person", this._connection);
            this.refreshPersionDataGrid();
        }

        private void refreshPersionDataGrid()
        {
            this._table.Clear();
            this._adapter.Fill(this._table);
            this.dataView.DataSource = this._table;
        }

        private void cmd_update_Click(object sender, System.EventArgs e)
        {
            try
            {
                this._recNumber = this.updateWithCmdBuilder();
                this.refreshPersionDataGrid();
                MessageBox.Show("Updated #{0} Entries", this._recNumber.ToString());
            } catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private int updateWithCmdBuilder()
        {
            return generateAdapter().Update(this._table);
        }

        private void cmd_exit_Click(object sender, EventArgs e)
        {
            this.updateWithCmdBuilder();
            Application.Exit();
        }

        private SqlDataAdapter generateAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            PersonCommandBuilder builder = new PersonCommandBuilder(this._connection);

            adapter.SelectCommand = builder.Query("Select * From Person").Build();

            builder.Query("INSERT INTO Person(FirstName, LastName)VALUES(@FirstName, @LastName)")
                .withFirstName()
                .withLastName()
                .withOriginalID();

            adapter.InsertCommand = builder.Build();

            builder.Query("UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE ID = @ID")
                .withFirstName()
                .withLastName()
                .withOriginalID();

            adapter.UpdateCommand = builder.Build();

            builder.Query("DELETE FROM Person WHERE ID = @ID")
                .withOriginalID();

            adapter.DeleteCommand = builder.Build();
            return adapter;
        }
    }
}
