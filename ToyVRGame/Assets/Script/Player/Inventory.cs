using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyShootingVr.Items;

namespace ToyShootingVr.Player
{
    public class Inventory : MonoBehaviour {

        private const int SLOTS = 9;
        private Dictionary<int , ItemBase> itemList = new Dictionary<int, ItemBase>();

        public void AddItem(ItemBase item)
        {
            if(itemList.Count < SLOTS)
            {
                Collider col = item.gameObject.GetComponent<Collider>();
                if(col.enabled)
                {
                    col.enabled = false;
                    if(itemList.ContainsKey(item.Id))
                    {
                        itemList[item.Id].Count += item.Count;
                    }
                    else
                    {
                        itemList.Add(item.Id,item);
                    }
                }
            }
        }

        public void DropItem(ItemBase item)
        {

        }

        public void DropItemAll(ItemBase item)
        {

        }

        public void ClearInventory()
        {

        }

    }
}