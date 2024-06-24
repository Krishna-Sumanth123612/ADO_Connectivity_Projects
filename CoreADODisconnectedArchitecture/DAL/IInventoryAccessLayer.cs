using CoreADODisconnectedArchitecture.Models;

namespace CoreADODisconnectedArchitecture.DAL
{
    public interface IInventoryAccessLayer
    {
        public IEnumerable<Inventory> GetInventories();
        public void AddInventory(Inventory inventory);
        public Inventory GetInventory(int id);
        public void DeleteInventory(int id,Inventory inventory);
        public void EditInventory(int id,Inventory inventory);
    }
}
