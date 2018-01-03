using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    // Use this for initialization
    void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        moveVector = lookAt.position + offset;

        // X - left/right
        moveVector.x = 0;

        // Y - up/down
        moveVector.y = Mathf.Clamp(moveVector.y, 2, 5);

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        } else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);

            transition += Time.deltaTime * 1 / animationDuration;
        }

	}
}
