using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public Button RemoveButton;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        Debug.Log(mainCharacter.Instance);
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                mainCharacter.Instance.IncreaseHealth(item.value);
                break;
            case Item.ItemType.Food:
                mainCharacter.Instance.IncreaseHealth(item.value);
                break;
        }
        RemoveItem();
    }
}
