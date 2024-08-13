using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class NormalItem : ItemInventoryBase, IPointerClickHandler
{
    public Image _imageItem;
    public Text _nameItem;
    public string description;
    public string type;
    public int id;
    [SerializeField] Text _quantityItem;

    void Start()
    {
        if(_info == null){
            return;}
        _imageItem.sprite = _info._image;
        _nameItem.text = _info._name;
        _quantityItem.text = this._quantity.ToString();
        description = _info._descrip;
        type = _info._type;
        id = _info._id;
    }
    private void OnDrawGizmosSelected() {
        if(_info == null){
            return;}
        _imageItem.sprite = _info._image;
        _nameItem.text = _info._name;
        _quantityItem.text = this._quantity.ToString();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (MenuContext.instance != null){
            MenuContext.instance.Show(this);
            MenuContext.instance.gameObject.SetActive(true);            
        }else{
            Debug.LogError("MenuContext instance is null!");
            return;
        }
    }
}
