using UnityEngine;
using UnityEngine.EventSystems;

namespace DapperDino.Items{
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private HotbarSlot[] hotbarSlots =new HotbarSlot[10];
        public HotbarSlot selected;
        public void Add(HotbarItem ItemToAdd){
            foreach(HotbarSlot hotbarSlot in hotbarSlots) {
                if(hotbarSlot.AddItem(ItemToAdd)){ return; }
            }
        }

        public void Select(int index){
            foreach(HotbarSlot hotbarSlot in hotbarSlots) {
                if(hotbarSlot.SlotIndex == index){
                    hotbarSlot.isSelected = true;
                } else {
                    hotbarSlot.isSelected = false;
                }
            }
        }

        public void GetSelected(){
            foreach(HotbarSlot hotbarSlot in hotbarSlots) {
                if(hotbarSlot.isSelected = true){
                    selected = hotbarSlot;
                }
            }
        }

    }
}