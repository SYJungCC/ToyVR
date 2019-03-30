using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ToyShootingVr.Items
{
    public enum eItemType
    {
        Ammo,
        Gun,
        Sword,
        Heal,
    }

    public interface IItemBase
    {
        int Id { get; }
        string Name { get; }
        eItemType Type { get;  }
        Sprite Image { get; }
        int Count { get; set; }
        bool IsGrap { get; set;  }

        void OnPickUp();
        void OnDrop(Vector3 dropPosition);
    }

    public class ItemBase : NetworkBehaviour, IItemBase
    {
        public virtual int Id
        {
            get
            {
                return -1;
            }
        }

        public virtual string Name {
            get
            {
                return "InventoryItemBase";
            }
        }

        [SerializeField]private Sprite image;
        public Sprite Image
        {
            get
            {
                return image;
            }
        }

        [SerializeField]private eItemType type;
        public eItemType Type {
            get
            {
                return type;
            }
        }

        public int Count  {  get; set; }
        public bool IsGrap { get; set; }

        public virtual void OnPickUp()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnDrop(Vector3 dropPosition)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = dropPosition;
        }
    }
}