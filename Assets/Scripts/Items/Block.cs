using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DapperDino.Items
{
    [CreateAssetMenu(fileName = "New Block", menuName = "Items/Block")]
    public class Block : InventoryItem
    {
        
        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(Rarity.Name).AppendLine();
            builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
            builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

            return builder.ToString();
        }
    }
}
