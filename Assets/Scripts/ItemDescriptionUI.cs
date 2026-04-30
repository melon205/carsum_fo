using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDescriptionUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        gameObject.SetActive(false); 
    }

    public void DisplayItemInfo(MaterialData data)
    {
        gameObject.SetActive(true);
        nameText.text = data.itemName;
        descriptionText.text = data.description;
    }
}