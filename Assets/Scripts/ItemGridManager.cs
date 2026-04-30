using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Image 컴포넌트 접근용

public class ItemGridManager : MonoBehaviour
{
    //public List<MaterialData> MaterialDataList; // 스크립터블 오브젝트 리스트
    public GameObject itemPrefab;      // 빈 이미지 칸이 있는 프리팹
    public Transform contentTransform;
    public ItemDescriptionUI descriptionUI;
    public GameObject gd;
    public GameObject buttonUI;
    public string order;
    public void setgd(GameObject gamed){
        gd=gamed;
    }
    public void setui(Dictionary<string,int> items, List<MaterialData> MaterialDataList, List<CarData> CarDataList)
    {
        if (order=="Material")
        {
            foreach (MaterialData data in MaterialDataList){
                if (items[data.itemName]!=0){
                    // 1. 프리팹 생성
                    GameObject newItem = Instantiate(itemPrefab, contentTransform);

                    // 2. [핵심] 매니저가 프리팹 내부의 ItemUI 스크립트를 찾아 데이터를 직접 주입
                    ItemUI itemScript = newItem.GetComponent<ItemUI>();
                    if (itemScript != null && descriptionUI!=null)
                    {
                        // 여기서 매니저가 "자, 이 데이터로 이미지랑 설명 다 세팅해!"라고 명령하는 겁니다.
                        itemScript.Setup(data, descriptionUI);
                    }
                }
            }
        }
        else if (order=="Car"){
            foreach (CarData data in CarDataList){
                // 1. 프리팹 생성
                GameObject newItem = Instantiate(itemPrefab, contentTransform);

                // 2. [핵심] 매니저가 프리팹 내부의 ItemUI 스크립트를 찾아 데이터를 직접 주입
                ItemUI itemScript = newItem.GetComponent<ItemUI>();
                if (itemScript != null && descriptionUI!=null)
                {
                    // 여기서 매니저가 "자, 이 데이터로 이미지랑 설명 다 세팅해!"라고 명령하는 겁니다.
                    itemScript.Setup(data, descriptionUI);
                }
                MergeImage itemScript2 = newItem.GetComponent<MergeImage>();
                if (itemScript2 != null && buttonUI!=null)
                {
                    Debug.Log("c");
                    // 여기서 매니저가 "자, 이 데이터로 이미지랑 설명 다 세팅해!"라고 명령하는 겁니다.
                    itemScript2.Setup(data, buttonUI, gd);
                }
            }
        }
    }
}