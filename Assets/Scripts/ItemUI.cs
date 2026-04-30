using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private ItemData myData;
    private ItemDescriptionUI descriptionUI;

    public void Setup(ItemData data, ItemDescriptionUI uiReference)
    {
        myData = data;
        descriptionUI = uiReference;

        if (nameText != null)
            nameText.text = myData.itemName;

        GetComponent<Button>().onClick.AddListener(OnItemClick);
    }

    void OnItemClick()
    {
        if (myData != null && descriptionUI != null)
        {
            descriptionUI.DisplayItemInfo(myData);
        }
    }
}