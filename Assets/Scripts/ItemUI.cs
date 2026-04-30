using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    // 프리팹 인스펙터에서 '이미지가 들어갈 자리'만 딱 연결해두세요.
    public Image iconDisplay;

    private MaterialData _myData;
    private ItemDescriptionUI _descriptionUI;

    // 매니저가 생성 시점에 호출하는 함수
    public void Setup(MaterialData data, ItemDescriptionUI ui)
    {
        _myData = data;
        _descriptionUI = ui;

        // [이게 유저님이 원하신 로직] 
        // 매니저가 넘겨준 data(MaterialData)에 이미 들어있는 이미지를 UI에 꽂음
        if (_myData.itemIcon != null && iconDisplay != null)
        {
            iconDisplay.sprite = _myData.itemIcon;
        }
    }

    public void OnClickItem() // 버튼의 OnClick에 연결
    {
        if (_myData != null && _descriptionUI != null)
            _descriptionUI.DisplayItemInfo(_myData);
    }
}