using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite itemIcon;
    // 필요하다면 아이템 타입을 구분하는 열거형을 추가할 수도 있습니다.
    // public enum ItemType { Car, Material }
    // public ItemType type;
}
[CreateAssetMenu(fileName = "NewMaterialData", menuName = "ScriptableObjects/MaterialData")]
public class MaterialData : ItemData
{
    public int id;
}
[CreateAssetMenu(fileName = "NewCarData", menuName = "ScriptableObjects/CarData")]
public class CarData : ItemData
{
    public int id;
    public int mutagen;
    public List<Modifier> modifiers = new List<Modifier>();
}