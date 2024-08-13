using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DVAH;
using System.Linq;

public class DataManager : Singleton<DataManager>
{
    [Header("----------Items----------")]
    [SerializeField] List<ItemDataSO> _generalDataItems = new List<ItemDataSO>();
    public List<ItemDataSO> generalDataItems => _generalDataItems;

    void Start(){
        
    }
    private void OnDrawGizmosSelected() {
        _generalDataItems = Resources.LoadAll<ItemDataSO>("Items").ToList();
    }
}
