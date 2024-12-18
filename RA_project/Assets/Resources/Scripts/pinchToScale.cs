using UnityEngine;

public class PinchToScale : MonoBehaviour
{
    public float minScaleFactor = 0.5f;   // Escala m¨ªnima
    public float maxScaleFactor = 3.0f;  // Escala m¨¢xima

    private float initialDistance;
    private Vector3 initialScale;
    private bool isPinching = false;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if ((touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began) && !isPinching)
            {
                // Detectar si este modelo fue tocado con un Raycast
                Ray ray = Camera.main.ScreenPointToRay(touch1.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    isPinching = true;

                    initialDistance = Vector2.Distance(touch1.position, touch2.position);
                    initialScale = transform.localScale;
                }
            }
            else if (isPinching && (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved))
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);

                if (initialDistance > 1f)
                {
                    float ratio = currentDistance / initialDistance;
                    float factor = Mathf.Clamp(ratio, minScaleFactor, maxScaleFactor);
                    Vector3 newScale = initialScale * factor;

                    transform.localScale = newScale;
                }
            }

            // Finalizar el pinch si uno de los dedos se suelta
            if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended ||
                touch1.phase == TouchPhase.Canceled || touch2.phase == TouchPhase.Canceled)
            {
                isPinching = false;
            }
        }
        else
        {
            // Finalizar el pinch si no hay dos dedos en la pantalla
            isPinching = false;
        }
    }
}
