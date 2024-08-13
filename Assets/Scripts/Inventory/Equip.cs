using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equipment : MonoBehaviour, IPointerClickHandler
{
    public enum Type
    {
        weapon,
        armor,
        ring,
        backpack
    }
    public Type type;

    public NormalItem item;
    public Image icon;

    public void Equip(NormalItem x)
    {
        item = x;
        icon.sprite = item._imageItem.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //show bảng thông tin trang bị
    }
}
