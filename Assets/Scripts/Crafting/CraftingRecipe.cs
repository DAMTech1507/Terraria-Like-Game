using System;
using System.Collections.Generic;
using UnityEngine;
using DapperDino.Items;

[Serializable]
public struct ItemAmount
{
	public InventoryItem Item;
	[Range(1, 999)]
	public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
	public List<ItemAmount> Materials;
	public List<ItemAmount> Results;

    public Inventory inventory;

	public bool CanCraft()
	{
		return HasMaterials();
	}

	private bool HasMaterials()
	{
		foreach (ItemAmount itemAmount in Materials)
		{
			if (inventory.ItemContainer.GetTotalQuantity(itemAmount.Item) < itemAmount.Amount)
			{
				Debug.LogWarning("You don't have the required materials.");
				return false;
			}
		}
		return true;
	}


	public void Craft()
	{
		RemoveMaterials();
		AddResults();
	}

	private void RemoveMaterials()
	{
		foreach (ItemAmount itemAmount in Materials)
		{
			for (int i = 0; i < itemAmount.Amount; i++)
			{
				inventory.ItemContainer.RemoveItem(new ItemSlot(itemAmount.Item , 1));
			}
		}
	}

	private void AddResults()
	{
		foreach (ItemAmount itemAmount in Results)
		{
			for (int i = 0; i < itemAmount.Amount; i++)
			{
				inventory.ItemContainer.AddItem(new ItemSlot(itemAmount.Item, 1));
			}
		}
	}
}