using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "Item")]
public class ItemDataSO : ScriptableObject
{
    public int _id;
    public string _name;
    public string _type;
    public Sprite _image;
    public string _descrip;
}
