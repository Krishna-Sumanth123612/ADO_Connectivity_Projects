using CoreADODisconnectedArchitecture.Models;
using System.Data;
using System.Data.SqlClient;

namespace CoreADODisconnectedArchitecture.DAL
{
    public class InventoryAccessLayer : IInventoryAccessLayer
    {
        public IConfiguration Configuration { get; }
        public InventoryAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<Inventory> GetInventories()
        {
            List<Inventory> inventories = new List<Inventory>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Select * from Inventory";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Inventory inventory = new Inventory();
                inventory.Id = Convert.ToInt32(dataRow[0]);
                inventory.Name = dataRow[1].ToString();
                inventory.Price = Convert.ToInt64(dataRow[2]);
                inventory.Quantity = Convert.ToInt32(dataRow[3]);
                inventories.Add(inventory);
            }
            return inventories;
        }
        public void AddInventory(Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Select * from Inventory";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DataRow dataRow = dataTable.NewRow();
            dataRow[1] = inventory.Name;
            dataRow[2] = inventory.Price;
            dataRow[3] = inventory.Quantity;
            dataTable.Rows.Add(dataRow);
            dataAdapter.UpdateCommand = command.GetInsertCommand();
            dataAdapter.Update(dataTable);

        }

        public void DeleteInventory(int id, Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Select * from Inventory";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (Convert.ToInt32(dataRow[0]) == id)
                {
                    dataRow.Delete();
                    break;
                }
            }

            dataAdapter.UpdateCommand = command.GetDeleteCommand();
            dataAdapter.Update(dataTable);
        }

        public void EditInventory(int id, Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Select * from Inventory";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (Convert.ToInt32(dataRow[0]) == id)
                {
                    dataRow[1] = inventory.Name;
                    dataRow[2] = inventory.Price;
                    dataRow[3] = inventory.Quantity;
                }
            }

            dataAdapter.UpdateCommand = command.GetUpdateCommand();
            dataAdapter.Update(dataTable);
        }

        public Inventory GetInventory(int id)
        {
            Inventory inventory = new Inventory();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Select * from Inventory";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (Convert.ToInt32(dataRow[0]) == id)
                {
                    inventory.Id = Convert.ToInt32(dataRow[0]);
                    inventory.Name = dataRow[1].ToString();
                    inventory.Price = Convert.ToInt64(dataRow[2]);
                    inventory.Quantity = Convert.ToInt32(dataRow[3]);
                    inventory.AddedOn = Convert.ToDateTime(dataRow[4]);
                }
            }

            return inventory;
        }
    }
}
