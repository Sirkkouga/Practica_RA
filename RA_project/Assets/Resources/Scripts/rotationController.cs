using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationController : MonoBehaviour
{
    public Animator animator;
    bool isRotating = false;

    public void rotation()
    {
        if(!isRotating)
        {
            animator.SetBool("rotation", true);
            isRotating = true;
        }
        else
        {
            animator.SetBool("rotation", false);
            isRotating = false;
        }
    }

}
