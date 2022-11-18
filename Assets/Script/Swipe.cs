using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;

    private void Update()
    {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region standalone inputs
        if(Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
            isDraging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input

        if(Input.touches.Length>0)
        {
            if(Input.touches[0].phase==TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;
                isDraging = true;
            }
            else if(Input.touches[0].phase==TouchPhase.Ended || Input.touches[0].phase==TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        if(swipeDelta.magnitude>125)
        {
            float X = swipeDelta.x;
            float Y = swipeDelta.y;
            if(Mathf.Abs(X)>Mathf.Abs(Y))
            {
                if (X < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (Y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
