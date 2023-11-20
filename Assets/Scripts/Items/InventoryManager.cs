using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager Instance;
   public List<Item> Items = new List<Item>();

   public Transform ItemContent;
   public GameObject InventoryItem;

   public Toggle EnableRemove;

   public InventoryItemController[] InventoryItems;

   private void Awake() 
    {
        Instance = this;
    }

   public void Add(Item item)
    {
        Items.Add(item);
    }

   public void Remove(Item item)
    {
        Items.Remove(item);
    }

   public void ListItems()
    {
        if (ItemContent == null || InventoryItem == null || Items == null)
        {
            Debug.LogError("One or more required objects are not assigned.");
            return;
        }

        foreach (Transform item in ItemContent) //khong bi duplicate
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            if (item == null)
            {
                Debug.LogWarning("Found a null item in the Items array.");
                continue;
            }

            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            if (itemName != null)
            {
                itemName.text = item.itemName;
            }
            else
            {
                Debug.LogWarning("ItemName component not found on InventoryItem prefab.");
            }

            if (itemIcon != null && item.icon != null)
            {
                itemIcon.sprite = item.icon;
            }
            else
            {
                Debug.LogWarning("ItemIcon component not found on InventoryItem prefab, or the item's icon is null.");
            }
            if (EnableRemove.isOn)
                removeButton.gameObject.SetActive(true); //toggle remove on = hien nut remove
        }
        SetInventoryItems();
    }
   public void EnableItemRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}

