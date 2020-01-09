using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace DapperDino.Items
{
    public abstract class HotbarItem : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] private new string name = "New Hotbar Item Name";
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public abstract string ColouredName { get; }
        public Sprite Icon => icon;

        public Tile PlaceTile;

        public abstract string GetInfoDisplayText();
    }
}
