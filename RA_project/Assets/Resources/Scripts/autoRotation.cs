using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // Velocidad de rotaci��n (grados por segundo)
    private bool isRotating = false; // Controla si el objeto est�� rotando
    private Quaternion initialRotation; // Rotaci��n inicial del objeto

    private void Start()
    {
        // Guarda la rotaci��n inicial
        initialRotation = Quaternion.Euler(0, -180, 0);
        transform.rotation = initialRotation;
    }

    private void Update()
    {
        if (isRotating)
        {
            // Realiza la rotaci��n continua en el eje Y
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void ToggleRotation()
    {
        if (isRotating)
        {
            // Detiene la rotaci��n y vuelve a la posici��n inicial
            isRotating = false;
            transform.rotation = initialRotation;
        }
        else
        {
            // Inicia la rotaci��n
            isRotating = true;
        }
    }

}
