using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float boardConstraint_f = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);

        // Player movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveVector = new Vector3(1, 0, 1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            moveVector = new Vector3(-1, 0, -1);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveVector = new Vector3(-1, 0, 1);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            moveVector = new Vector3(1, 0, -1);

        // Board constraint
        if (IsOutsideBoard(moveVector))
            moveVector = new Vector3(0, 0, 0);
        // Collision with another man
        else
        {
            GameObject[] mansOnBoard = GameObject.FindGameObjectsWithTag("Man");
            if (IsManThere(mansOnBoard, moveVector))
            {
                Vector3 manPosition = transform.position + moveVector;
                moveVector *= 2;
                if (IsOutsideBoard(moveVector) || IsManThere(mansOnBoard, moveVector))
                    moveVector = new Vector3(0, 0, 0);
                else
                    TakeMan(mansOnBoard, manPosition);
            }
        }

        transform.position += moveVector;
    }

    private bool IsOutsideBoard(Vector3 moveVector)
    {
        return Mathf.Abs((transform.position + moveVector).x) > boardConstraint_f ||
            Mathf.Abs((transform.position + moveVector).z) > boardConstraint_f;
    }

    private bool IsManThere(GameObject[] mans, Vector3 moveVector)
    {
        foreach (GameObject man in mans)
        {
            if (man.name == name) continue;
            if (man.transform.position.Equals(transform.position + moveVector))
                return true;
        }
        return false;
    }

    private void TakeMan(GameObject[] mans, Vector3 position)
    {
        foreach (GameObject man in mans)
        {
            if (man.transform.position.Equals(position))
            {
                Destroy(man);
                break;
            }
        }
    }
}
