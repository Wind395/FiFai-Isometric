using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInventoryBase : MonoBehaviour
{
    [SerializeField] protected ItemDataSO _info;
    public int _quantity;
    [SerializeField] protected int _maxCapacity;
}
