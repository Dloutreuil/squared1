using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    public Vector3 desiredPosition;

    private void Update()
    {
        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left*2;
        if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right*2;
        if (swipeControls.SwipeUp)
            desiredPosition += Vector3.forward*2;
        if (swipeControls.SwipeDown)
            desiredPosition += Vector3.back*2;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
    }
}
