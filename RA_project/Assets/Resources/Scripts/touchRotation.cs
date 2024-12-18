using UnityEngine;
using UnityEngine.EventSystems;

public class RotateOnTouch : MonoBehaviour
{
    private bool isBeingTouched = false;
    private Vector2 previousTouchPosition;

    void Update()
    {
        // Detecta si hay un toque en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Comprobamos si el toque inicial est¨¢ sobre este objeto
            if (touch.phase == TouchPhase.Began)
            {
                if (IsTouchingObject(touch))
                {
                    isBeingTouched = true;
                    previousTouchPosition = touch.position;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isBeingTouched)
            {
                // Calcula la rotaci¨®n basada en el movimiento del dedo
                Vector2 deltaPosition = touch.deltaPosition;
                float rotationSpeed = 0.2f; // Ajusta esta velocidad seg¨²n sea necesario

                // Aplica rotaci¨®n en el eje Y (horizontal) y X (vertical)
                transform.Rotate(Vector3.up, -deltaPosition.x * rotationSpeed, Space.World);
                transform.Rotate(Vector3.right, deltaPosition.y * rotationSpeed, Space.World);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isBeingTouched = false;
            }
        }
    }

    private bool IsTouchingObject(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.transform == transform;
        }
        return false;
    }
}
