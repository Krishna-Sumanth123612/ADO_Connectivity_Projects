using CoreADODisconnectedArchitecture.Models;

namespace CoreADODisconnectedArchitecture.DAL
{
    public class InventoryAccessLayer : IInventoryAccessLayer
    {

        public IEnumerable<Inventory> GetInventories()
        {
            throw new NotImplementedException();
        }
        public void AddInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void DeleteInventory(int id, Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void EditInventory(int id, Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
