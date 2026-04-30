using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// 게임의 전반적인 흐름(씬 이동 등)을 관리하는 디렉터 스크립트입니다.
/// GameDirector 같은 관리용 빈 오브젝트에 부착하여 사용하세요.
/// </summary>
public class GameDirector : MonoBehaviour
{
    private string currentscene;
    public Dictionary<string,int> items;
    public List<MaterialData> MaterialDataList;
    public List<CarData> CarDataList;
    /// <summary>
    /// UI 버튼의 OnClick() 이벤트에 연결하여 씬을 이동시키는 함수입니다.
    /// Inspector 창에서 이동할 씬의 이름을 문자열로 직접 입력할 수 있습니다.
    /// </summary>
    /// <param name="sceneName">이동할 씬의 이름</param>
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        items = new Dictionary<string,int>();
        foreach (MaterialData key in MaterialDataList)
        {
            items[key.itemName] = 0;
        }
    }
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            currentscene=sceneName;
            SceneManager.LoadScene(sceneName);
            if (currentscene=="merge"){
                //
            }
            else if (currentscene=="Car_center"){
                //
            }
            else if (currentscene=="trash"){
                //
            }
        }
        else
        {
            Debug.LogWarning("이동할 씬 이름이 입력되지 않았습니다.");
        }
    }
}
