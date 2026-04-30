using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    void Update()
    {
        if (buttonImage == null || FusionDirector.Instance == null) return;

        if (FusionDirector.Instance.CanFusion())
        {
            //Debug.Log("1");
            buttonImage.color = Color.green;
        }
        else
        {
            //Debug.Log("1");
            buttonImage.color = Color.gray;
        }
    }
}