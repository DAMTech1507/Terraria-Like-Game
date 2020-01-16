using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using DapperDino.Items;

public class PlayerMove2 : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;
	public Tilemap TileMap;


    Vector3 mousePos;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	float MouseDistance;
	public Tile PlaceBlock;
	
	public Hotbar hotbar;
	public Inventory inventory;
	ItemContainer itemContainer;

	void Start () {
		TileMap = FindObjectOfType<Tilemap>();
		itemContainer = inventory.ItemContainer;
	}

	// Update is called once per frame
	void Update () {
		#region Movement
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		#endregion

		#region Break and place

		#region mouse
		MouseDistance = Vector3.Distance(mousePos, transform.position);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		#endregion
		
		if (Input.GetButtonDown("Fire1")){
			if(MouseDistance < 11.5){
			string Tilename = TileMap.GetTile(TileMap.WorldToCell(mousePos)).name;
			if(Tilename != null){
				TileMap.SetTile(TileMap.WorldToCell(mousePos), null);
				Debug.Log(Tilename);

				string[] GetTiles;
				GetTiles = AssetDatabase.FindAssets($"{Tilename}", new[] {"Assets/Resources/Items"});

				string itemPath = AssetDatabase.GUIDToAssetPath(GetTiles[0]); 
				InventoryItem item = (InventoryItem)AssetDatabase.LoadAssetAtPath(itemPath, typeof(InventoryItem));

				itemContainer.AddItem(new ItemSlot(item, 1));
			}
			}
		}
		
		if (Input.GetButtonDown("Fire2")){
			if(hotbar.selected.SlotItem is InventoryItem inventoryItem){
				if(itemContainer.HasItem(inventoryItem)){
					if(MouseDistance < 11.5){
						string[] GetTiles;
						if(PlaceBlock.name == "log"){
							GetTiles = AssetDatabase.FindAssets("Tree", new[] {"Assets/Resources/Items"});
						} else {
						GetTiles = AssetDatabase.FindAssets($"{PlaceBlock.name}", new[] {"Assets/Resources/Items"});
						}
						string itemPath = AssetDatabase.GUIDToAssetPath(GetTiles[0]); 
						InventoryItem item = (InventoryItem)AssetDatabase.LoadAssetAtPath(itemPath, typeof(InventoryItem));
						
						if(TileMap.GetTile(TileMap.WorldToCell(mousePos)) == null){
							TileMap.SetTile(TileMap.WorldToCell(mousePos), PlaceBlock);
							itemContainer.UpdatedRemove(item, 1);
						}
					}
				}
			}
		}
		#endregion
		
		#region Block Selection
		
		#region KeyPresses
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			hotbar.Select(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			hotbar.Select(1);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			hotbar.Select(2);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			hotbar.Select(3);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha5)){
			hotbar.Select(4);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha6)){
			hotbar.Select(5);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha7)){
			hotbar.Select(6);
		}		
		if (Input.GetKeyDown(KeyCode.Alpha8)){
			hotbar.Select(7);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9)){
			hotbar.Select(8);
		}
		if (Input.GetKeyDown(KeyCode.Alpha0)){
			hotbar.Select(9);
		}
		#endregion
		
		hotbar.GetSelected();

		PlaceBlock = hotbar.selected.SlotItem.PlaceTile;
		#endregion
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}