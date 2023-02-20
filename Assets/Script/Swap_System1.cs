using UnityEngine;

public class Swap_System1 : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;

    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            // Detect swipe direction
            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDown = touch.position;
                DetectSwipe();
            }

            // Detect swipe direction only after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {
        // Check if the swipe distance is greater than the threshold
        if (Vector2.Distance(fingerDown, fingerUp) > SWIPE_THRESHOLD)
        {
            float angle = Mathf.Atan2(fingerDown.y - fingerUp.y, fingerUp.x - fingerDown.x) * Mathf.Rad2Deg;

            if (angle > 45 && angle < 135)
            {
                Debug.Log("Swipe Up");
            }

            if (angle < -45 && angle > -135)
            {
                Debug.Log("Swipe Down");
            }

            if (angle > 135 || angle < -135)
            {
                Debug.Log("Swipe Left");
            }

            if (angle < 45 && angle > -45)
            {
                Debug.Log("Swipe Right");
            }

            fingerUp = fingerDown;
        }
    }
}
