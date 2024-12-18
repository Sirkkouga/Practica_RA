using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    private bool isRotating = false; 

    public float rotation_speed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime, Space.World);
        }
    }


    void toggleRotation(){
        isRotating = !isRotating;
    }
}
