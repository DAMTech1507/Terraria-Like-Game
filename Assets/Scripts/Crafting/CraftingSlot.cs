using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public CraftingRecipe RecipeToCraft;
    public Image Icon;
    public Sprite ItemSprite;

    void Start(){
        Icon.sprite = ItemSprite;
    }

    public void Craft(){
        RecipeToCraft.Craft();
    }

}
