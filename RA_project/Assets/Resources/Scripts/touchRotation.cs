using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // Velocidad de rotaci��n

    private void Update()
    {
        if (Input.touchCount == 1) // Verifica si hay un toque en pantalla
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) // Si el dedo se est�� moviendo
            {
                // Ajusta la rotaci��n
                float rotationX = touch.deltaPosition.y * rotationSpeed;
                float rotationY = -touch.deltaPosition.x * rotationSpeed;

                // Aplica la rotaci��n al objeto (ajusta los ejes seg��n necesites)
                transform.Rotate(Vector3.up, rotationY, Space.World);   // Rotaci��n en el eje Y
                transform.Rotate(Vector3.right, rotationX, Space.World); // Rotaci��n en el eje X
            }
        }
    }
}
