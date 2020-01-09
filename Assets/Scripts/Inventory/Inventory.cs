using DapperDino.Events.CustomEvents;
using UnityEngine;

namespace DapperDino.Items
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
        [SerializeField] private ItemSlot testItemSlot = new ItemSlot();

        public ItemContainer ItemContainer { get; } = new ItemContainer(20);

        public void OnEnable() => ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;

        public void OnDisable() => ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;

        public void Add(ItemSlot itemSlot)
        {
            ItemContainer.AddItem(itemSlot);
        }
        public void Remove(ItemSlot itemSlot)
        {
            ItemContainer.RemoveItem(itemSlot);
            ItemContainer.OnItemsUpdated.Invoke();
        
        }
    }
}
