using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 큰 UI 이미지를 드래그하여 이동할 수 있게 해주는 스크립트입니다.
/// 화면 밖으로 나가지 않도록 이동 범위가 제한됩니다.
/// 사용할 UI Image 오브젝트에 이 스크립트를 부착하세요.
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class UIDraggableImage : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 lastMousePosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 시작된 마우스 위치를 UI 공간 좌표로 변환하여 저장
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out lastMousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition;
        
        // 현재 마우스 위치를 UI 공간 좌표로 변환
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out currentMousePosition))
        {
            // 드래그한 거리(offset) 계산
            Vector2 offset = currentMousePosition - lastMousePosition;
            
            // 이미지 위치 이동
            rectTransform.anchoredPosition += offset;
            
            // 부모(배경) 밖으로 나가지 않도록 위치 제한
            ClampToBoundary();
            
            // 다음 프레임을 위해 현재 마우스 위치 업데이트
            lastMousePosition = currentMousePosition;
        }
    }

    private void ClampToBoundary()
    {
        RectTransform parentRect = rectTransform.parent as RectTransform;
        if (parentRect == null) return;

        Vector3 pos = rectTransform.localPosition;

        // 스케일을 고려한 현재 이미지의 크기
        Vector2 myMin = rectTransform.rect.min * rectTransform.localScale;
        Vector2 myMax = rectTransform.rect.max * rectTransform.localScale;

        // 부모 영역 기준 이동 가능한 최소/최대 위치 계산
        Vector2 limit1 = parentRect.rect.min - myMin;
        Vector2 limit2 = parentRect.rect.max - myMax;

        float minX = Mathf.Min(limit1.x, limit2.x);
        float maxX = Mathf.Max(limit1.x, limit2.x);
        float minY = Mathf.Min(limit1.y, limit2.y);
        float maxY = Mathf.Max(limit1.y, limit2.y);

        // 계산된 한계치 내로 좌표 고정
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        rectTransform.localPosition = pos;
    }
}
