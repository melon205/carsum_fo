using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemGridManager : MonoBehaviour
{
    [Header("Item Data List")]
    // 자동차 매니저에는 자동차 데이터를, 재료 매니저에는 재료 데이터를 넣습니다.
    public List<ItemData> itemDataList;

    [Header("UI References")]
    public GameObject itemPrefab;      // 공용 버튼 프리팹
    public Transform contentTransform; // 아이템이 생성될 Content 위치
    public ItemDescriptionUI descriptionUI; // 우측 설명창 연결

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        foreach (ItemData data in itemDataList)
        {
            GameObject newItemBtn = Instantiate(itemPrefab, contentTransform);
            ItemUI itemScript = newItemBtn.GetComponent<ItemUI>();

            if (itemScript != null)
            {
                itemScript.Setup(data, descriptionUI);
            }
        }
    }
}