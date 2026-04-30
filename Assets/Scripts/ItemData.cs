using UnityEngine;

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
public class MaterialData : ItemData
{
}
public class CarData : ItemData
{
    public int id;
}