using UnityEngine;
public class MobileInput : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private const float DEADZONE = 13.0f;

    public static MobileInput Instance { get; set; }

    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }

    void Awake()
    {
        Instance = this;
    }
    void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        //reseting all the booleans
        tap = swipeDown = swipeLeft = swipeRight = swipeUp = false;

        //lets check for inputs
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //calculate distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (startTouch != Vector2.zero)
            {
                //lets check with mobile
                if (Input.touches.Length > 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
                //lets check with standalone
                else if (Input.GetMouseButton(0))
                {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }
            }
        }

        //did  we cross the deadzone?
        if (swipeDelta.magnitude > DEADZONE)
        {
            //which direction
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //up or down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }

            }
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
