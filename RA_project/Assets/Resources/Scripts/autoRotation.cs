using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // Velocidad de rotaci車n (grados por segundo)
    private bool isRotating = false; // Controla si el objeto est芍 rotando
    private Quaternion initialRotation; // Rotaci車n inicial del objeto

    private void Start()
    {
        // Guarda la rotaci車n inicial
        initialRotation = Quaternion.Euler(0, -180, 0);
        transform.rotation = initialRotation;
    }

    private void Update()
    {
        if (isRotating)
        {
            // Realiza la rotaci車n continua en el eje Y
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void ToggleRotation()
    {
        if (isRotating)
        {
            // Detiene la rotaci車n y vuelve a la posici車n inicial
            isRotating = false;
            transform.rotation = initialRotation;
        }
        else
        {
            // Inicia la rotaci車n
            isRotating = true;
        }
    }

}
