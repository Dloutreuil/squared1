using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDeplacement : MonoBehaviour
{
    private Vector3 startPos, endPos;
    private bool isMoving = false;
    public float MoveTime = 2f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        //Debug.Log(x);
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (!isMoving && (x != 0 || z != 0)) StartCoroutine(MovePlayer(movement.normalized));
    }

    IEnumerator MovePlayer(Vector3 dir)
    {

        Debug.Log(dir);
        isMoving = true;
        float nextMove = 0f;
        startPos = transform.position;
        endPos = startPos + dir;
        Debug.Log(nextMove);
        Debug.Log(isMoving);

        if (nextMove < MoveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, MoveTime);
            nextMove += Time.deltaTime;
            Debug.Log("actif");
            yield return null;
        }
        else
        {
            print("non");
        }
        startPos = Vector3.zero;
        endPos = Vector3.zero;
        //return Vector3;
        isMoving = false;
    }
}
