using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item Item;

  void Pickup()
  {
    InventoryManager.Instance.Add(Item);
    Destroy(gameObject);
  }

 private void OnTriggerEnter2D(Collider2D other) 
 {
    Pickup();
 }
}
//add script nay cho tat ca cac prefab + assign item
