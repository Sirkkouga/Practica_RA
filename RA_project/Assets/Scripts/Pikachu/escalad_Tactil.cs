using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalad_Tactil : MonoBehaviour
{
    public float scaleSpeed = 0.1f; 
    public float minScale = 0.5f;
    public float maxScale = 2.0f; 

    private Vector2 initialTouchPosition1;
    private Vector2 initialTouchPosition2; 
    private float initialDistance; 
    private Vector3 initialScale; 

    void Update()
    {
        if (Input.touchCount == 2) // Detecta dos dedos en pantalla
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);

                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    initialTouchPosition1 = touch1.position;
                    initialTouchPosition2 = touch2.position;
                    initialDistance = Vector2.Distance(initialTouchPosition1, initialTouchPosition2);
                    initialScale = transform.localScale;
                }

                float scaleRatio = currentDistance / initialDistance;
                
                Vector3 newScale = initialScale * scaleRatio;
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                transform.localScale = newScale;
            }
        }
    }
}
