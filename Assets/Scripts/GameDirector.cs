using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임의 전반적인 흐름(씬 이동 등)을 관리하는 디렉터 스크립트입니다.
/// GameDirector 같은 관리용 빈 오브젝트에 부착하여 사용하세요.
/// </summary>
public class GameDirector : MonoBehaviour
{
    /// <summary>
    /// UI 버튼의 OnClick() 이벤트에 연결하여 씬을 이동시키는 함수입니다.
    /// Inspector 창에서 이동할 씬의 이름을 문자열로 직접 입력할 수 있습니다.
    /// </summary>
    /// <param name="sceneName">이동할 씬의 이름</param>
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("이동할 씬 이름이 입력되지 않았습니다.");
        }
    }
}
