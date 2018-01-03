using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;
    private float speed = 8.0f;
    private Vector3 moveVector;

    private bool isDead = false;

    private float animationDuration = 3.0f;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if(isDead)
        {
            return;
        }

        // Restrict moving left or right during the animation
        if (Time.timeSinceLevelLoad < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        // X - Left and Right
        //moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.x = Input.acceleration.x * 10.0f;

        // Y - Up and Down
        moveVector.y = 0;

        // Z - Forward and Backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
        transform.position.Set(transform.position.x, 0, transform.position.z);
	}

    public void SetSpeed(int modifier)
    {
        speed = 8.0f + modifier * 3;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.z > transform.position.z + controller.radius/2)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().onDeath();
    }
}
