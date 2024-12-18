using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotation : MonoBehaviour
{
    public float rotationSpeed = 90f; // Velocidad de rotaci��n (grados por segundo)
    private bool isRotating = false; // Controla si el objeto est�� rotando
    private Quaternion initialRotation; 

    private void Start()
    {
        initialRotation = Quaternion.Euler(0, -180, 0);
        transform.rotation = initialRotation;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void ToggleRotation()
    {
        if (isRotating)
        {
            // Detiene la rotacion y vuelve a la posicion inicial 
            isRotating = false;
            transform.rotation = initialRotation;  
        }
        else
        {
            // Inicia
            isRotating = true;
        }
    }

}
