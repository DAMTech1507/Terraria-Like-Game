using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DapperDino.Items
{
    public class HotbarSlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantityText = null;

        private HotbarItem slotItem = null;
        
        private Block slotBlock = null;

        public bool isSelected = false;

        public override HotbarItem SlotItem
        {
            get { return slotItem; }
            set { slotItem = value; UpdateSlotUI(); }
        }

        public Block SlotBlock
        {
            get { return slotBlock; }
            set { slotBlock = value; UpdateSlotUI(); }
        }

        public bool AddItem(HotbarItem itemToAdd)
        {
            if (SlotItem != null) { return false; }

            SlotItem = itemToAdd;

            return true;
        }
        public bool AddItem(Block itemToAdd)
        {
            if (SlotBlock != null) { return false; }

            SlotBlock = itemToAdd;

            return true;
        }
        public bool UseSlot(int index)
        {
            if (index == SlotIndex) { isSelected = true; Debug.Log(SlotIndex);return true; }
            
            isSelected = false;
        
            return false;
        }

        public bool DebugID(int index){
           if (index == SlotIndex) { Debug.Log(SlotIndex); return true;}

            return false;

        }

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
            if (itemDragHandler == null) { return; }

            InventorySlot inventorySlot = itemDragHandler.ItemSlotUI as InventorySlot;
            if (inventorySlot != null)
            {
                SlotItem = inventorySlot.ItemSlot.item;
                return;
            }

            HotbarSlot hotbarSlot = itemDragHandler.ItemSlotUI as HotbarSlot;
            if (hotbarSlot != null)
            {
                HotbarItem oldItem = SlotItem;
                SlotItem = hotbarSlot.SlotItem;
                hotbarSlot.SlotItem = oldItem;
                return;
            }
        }

        public override void UpdateSlotUI()
        {
            if (SlotItem == null)
            {
                EnableSlotUI(false);
                return;
            }

            itemIconImage.sprite = SlotItem.Icon;

            EnableSlotUI(true);

            SetItemQuantityUI();
        }

        private void SetItemQuantityUI()
        {
            if (SlotItem is InventoryItem inventoryItem)
            {
                if (inventory.ItemContainer.HasItem(inventoryItem))
                {
                    int quantityCount = inventory.ItemContainer.GetTotalQuantity(inventoryItem);
                    itemQuantityText.text = quantityCount > 1 ? quantityCount.ToString() : "";
                }
                else
                {
                    SlotItem = null;
                }
            }
            else
            {
                itemQuantityText.enabled = false;
            }
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
            itemQuantityText.enabled = enable;
        }
    }
}