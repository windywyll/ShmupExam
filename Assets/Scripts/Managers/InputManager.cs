using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private Player player;

    private KeyCode up, upAlt;
    private KeyCode left, leftAlt;
    private KeyCode right, rightAlt;
    private KeyCode down, downAlt;

    private Vector2 movement;

	// Use this for initialization
	void Awake () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        up = KeyCode.Z;
        left = KeyCode.Q;
        right = KeyCode.D;
        down = KeyCode.S;

        upAlt = KeyCode.UpArrow;
        leftAlt = KeyCode.LeftArrow;
        rightAlt = KeyCode.RightArrow;
        downAlt = KeyCode.DownArrow;
    }
	
	// Update is called once per frame
	void Update () {
        movement = Vector2.zero;

        CheckMovement();

        player.Move(movement);

	}

    private void CheckMovement()
    {
        if(Input.GetKey(up) || Input.GetKey(upAlt))
        {
            movement.y += 1;
        }

        if (Input.GetKey(down) || Input.GetKey(downAlt))
        {
            movement.y -= 1;
        }

        if (Input.GetKey(left) || Input.GetKey(leftAlt))
        {
            movement.x -= 1;
        }

        if (Input.GetKey(right) || Input.GetKey(rightAlt))
        {
            movement.x += 1;
        }
    }
}
