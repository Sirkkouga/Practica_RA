using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // Velocidad de rotaci車n

    private void Update()
    {
        if (Input.touchCount == 1) // Verifica si hay un toque en pantalla
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) // Si el dedo se est芍 moviendo
            {
                // Ajusta la rotaci車n
                float rotationX = touch.deltaPosition.y * rotationSpeed;
                float rotationY = -touch.deltaPosition.x * rotationSpeed;

                // Aplica la rotaci車n al objeto (ajusta los ejes seg迆n necesites)
                transform.Rotate(Vector3.up, rotationY, Space.World);   // Rotaci車n en el eje Y
                transform.Rotate(Vector3.right, rotationX, Space.World); // Rotaci車n en el eje X
            }
        }
    }
}
