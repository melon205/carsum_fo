using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MergeImageUI : MonoBehaviour
{
    public Image buttonImage1;
    public Image buttonImage2;
    bool _Image1=false;
    bool _Image2=false;
    CarData Data1;
    CarData Data2;

    void Start()
    {
        //gameObject.SetActive(false);
        //buttonImage = GetComponent<Image>();
    }

    public bool DisplayItemImage(CarData data)
    {
        if (_Image1==false){
            gameObject.SetActive(true);
            buttonImage1.sprite=data.itemIcon;
            _Image1=true;
            Data1=data;
            //car1=data;
            return true;
        }
        else if (_Image2==false){
            gameObject.SetActive(true);
            buttonImage2.sprite=data.itemIcon;
            _Image2=true;
            Data2=data;
            //car2=data;
            return true;
        }
        else{
            return false;
        }
    }
}