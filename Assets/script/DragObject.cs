using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public float maxDistance = 100f;
    public Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = maxDistance;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }

    void OnMouseUp()
    {
        transform.position = originalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
