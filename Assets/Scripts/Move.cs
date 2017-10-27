using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        speed += 0.00001f;
        float moveForward = 1.0f;
        float moveSideways = Input.GetAxis("Horizontal") * 3;

        Vector3 movement = new Vector3(moveSideways, 0.0f, moveForward * speed);

        rb.AddForce(movement);
    }
}