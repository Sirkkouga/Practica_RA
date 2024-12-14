using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchToScale : MonoBehaviour
{
    public float scaleSpeed = 0.1f; // Velocidad de escalado
    public float minScale = 0.5f;  // Escala m¨ªnima
    public float maxScale = 2.0f;  // Escala m¨¢xima

    private Vector2 initialTouchPosition1; // Posici¨®n inicial del primer toque
    private Vector2 initialTouchPosition2; // Posici¨®n inicial del segundo toque
    private float initialDistance; // Distancia inicial entre los dedos
    private Vector3 initialScale;  // Escala inicial del modelo

    void Update()
    {
        if (Input.touchCount == 2) // Detecta dos dedos en pantalla
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Si ambos dedos est¨¢n en movimiento
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                // Calcula la distancia actual entre los dedos
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);

                // Si es el primer frame del gesto, inicializa las variables
                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    initialTouchPosition1 = touch1.position;
                    initialTouchPosition2 = touch2.position;
                    initialDistance = Vector2.Distance(initialTouchPosition1, initialTouchPosition2);
                    initialScale = transform.localScale;
                }

                // Calcula la proporci¨®n de escalado basada en la diferencia de distancias
                float scaleRatio = currentDistance / initialDistance;

                // Aplica el escalado al objeto, limitando a minScale y maxScale
                Vector3 newScale = initialScale * scaleRatio;
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                transform.localScale = newScale;
            }
        }
    }
}
