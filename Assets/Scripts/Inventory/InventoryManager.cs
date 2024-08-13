using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DVAH;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] Transform _gridLayout;
    [SerializeField] List<ItemInventoryBase> _items = new List<ItemInventoryBase>();
    public List<ItemInventoryBase> items => _items;

    public List<Transform> _itemSlots = new List<Transform>();

    private void Start() {
        _itemSlots = _gridLayout.GetComponentsInChildren<Transform>().ToList();
        _itemSlots.RemoveAt(0);
        Init();
    }
    
    public void Init(){
        int i = 0;
        foreach(ItemInventoryBase item in _items){
            Instantiate(item.gameObject, _itemSlots[i]);
            i++;
        }
    }

    public void RemoveItem(ItemInventoryBase item) {
        if (item != null && _items.Contains(item)) {
            Debug.Log("item1");
            int index = _items.IndexOf(item);
            _items.RemoveAt(index);
            int slotIndex = _itemSlots.IndexOf(item.transform);
            if (slotIndex != -1) {
                Destroy(item.transform.gameObject);
                _itemSlots.RemoveAt(slotIndex);
            }
        }
    }
}
