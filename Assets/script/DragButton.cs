using UnityEngine;
using UnityEngine.EventSystems;

public class DragButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    //private Vector3 originalPosition;

    public float maxDistance = 20f;
    public Vector2 originalPosition;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.position;
        originalPosition = RectTransformUtility.WorldToScreenPoint(null, originalPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 difference = mousePosition - originalPosition;
        float distance = difference.magnitude;
        if (distance > maxDistance)
        {
            difference = difference.normalized * maxDistance;
            mousePosition = originalPosition + difference;
        }
        rectTransform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.position = originalPosition;
    }
}
