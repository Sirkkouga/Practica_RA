using UnityEngine;

public class pinchToScale : MonoBehaviour
{
    public float minScaleFactor = 0.5f;   
    public float maxScaleFactor = 3.0f;

    private float initialDistance;
    private Vector3 initialScale;
    private bool isPinching = false;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if ((touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began) && !isPinching)
            {
                isPinching = true;

                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialScale = transform.localScale;
            }
            else if (isPinching && (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved))
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);

                if (initialDistance > 1f)
                {
                    float ratio = currentDistance / initialDistance;
                    Vector3 newScale = initialScale * ratio;

                    float factor = Mathf.Clamp(ratio, minScaleFactor, maxScaleFactor);

                    newScale = initialScale * factor;
                    transform.localScale = newScale;
                }
            }

            // Si uno de los dedos se suelta acabamos pinch
            if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended ||
                touch1.phase == TouchPhase.Canceled || touch2.phase == TouchPhase.Canceled)
            {
                isPinching = false;
            }
        }
        else
        {
            // Si en cualquier momento deja de haber 2 toques, cerramos el pinch
            isPinching = false;
        }
    }
}
