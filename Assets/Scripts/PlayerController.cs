using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float constraint_f = 5;
    private float yPos_f = 0.5f;
    private Rigidbody player_rb;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position;

        // Player movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.position = new Vector3(transform.position.x - 1, yPos_f, transform.position.z + 1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.position = new Vector3(transform.position.x + 1, yPos_f, transform.position.z - 1);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - 1, yPos_f, transform.position.z - 1);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + 1, yPos_f, transform.position.z + 1);

        // Constraint player position
        if (Mathf.Abs(transform.position.x) > constraint_f || Mathf.Abs(transform.position.z) > constraint_f)
            transform.position = startPosition;
    }
}
