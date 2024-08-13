using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuContext : MonoBehaviour
{
    public Equipment eWeapon;
    public Equipment eArmor;
    public Equipment eRing;
    public Equipment eBp;


    public static MenuContext instance;
    public GameObject mainBoard;
    public NormalItem item;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Update() {
        
    }

    public void Show(NormalItem x)
    {
        item = x;
        icon.sprite = item._imageItem.sprite;
        nameText.text = item._nameItem.text;
        descriptionText.text = item.description;
        mainBoard.SetActive(true);
    }

    public void EquipBtn()
    {
        if (item != null)
        {
            switch (item.type)
            {
                case "weapon":
                    {
                        eWeapon.Equip(item);
                        item._quantity--;
                        if (item._quantity == 0) {
                            Destroy(item.gameObject);
                        }
                        //InventoryManager.Instant.RemoveItem(item);
                        //InventoryManager.Instant.Init();
                        CancelBtn();
                    }
                    break;

                case "armor":
                    {
                        eArmor.Equip(item);
                        item._quantity--;
                        if (item._quantity == 0) {
                            Destroy(item.gameObject);
                        }
                        //InventoryManager.Instant.RemoveItem(item);
                        //InventoryManager.Instant.Init();
                        CancelBtn();
                    }
                    break;

                case "ring":
                    {
                        eRing.Equip(item);
                        item._quantity--;
                        if (item._quantity == 0) {
                            Destroy(item.gameObject);
                        }
                        //InventoryManager.Instant.RemoveItem(item);
                        //InventoryManager.Instant.Init();
                        CancelBtn();
                    }
                    break;

                case "backpack":
                    {
                        eBp.Equip(item);
                        item._quantity--;
                        if (item._quantity == 0) {
                            Destroy(item.gameObject);
                        }
                        //InventoryManager.Instant.RemoveItem(item);
                        //InventoryManager.Instant.Init();
                        CancelBtn();
                    }
                    break;
            }
        }
        else
        {
            Debug.LogError("Item không được tìm thấy!");
        }
    }

    public void CancelBtn()
    {
        if (item != null)
        {
            item = null;
            mainBoard.SetActive(false);
        }
    }
}