using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{   
    public CraftingRecipe[] CraftingRecipes;
    // Update is called once per frame
    void Update()
    {
        foreach(Transform Child in transform){
            Child.gameObject.SetActive(false);
        }

        for(int i = 0; i < CraftingRecipes.Length; i++){
            if(CraftingRecipes[i].CanCraft()){
                CraftingSlot ChildCraftingSlot = transform.GetChild(i).GetComponent<CraftingSlot>();
                ChildCraftingSlot.RecipeToCraft = CraftingRecipes[i];
                ChildCraftingSlot.ItemSprite = CraftingRecipes[i].Results[0].Item.Icon;
                transform.GetChild(i).gameObject.SetActive(true);
            }
        } 

    }
}
