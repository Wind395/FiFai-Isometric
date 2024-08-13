using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _inventory;
    private bool inventoryIsOn;
    // Start is called before the first frame update
    void Start()
    {
        inventoryIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            TabButton();
        }
    }
    void TabButton(){
        if(!inventoryIsOn){
            _inventory.SetActive(true);
            inventoryIsOn = true;
        }else{
            _inventory.SetActive(false);
            inventoryIsOn = false;
        }
    }
}
