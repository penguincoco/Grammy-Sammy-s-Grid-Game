using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

	private bool canMove = true;
	private bool moving = false;
	private int speed = 5;
	private int buttonCooldown = 0;
	private Vector3 pos;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		buttonCooldown--;
		
		if (canMove)
		{
			pos = transform.position;
			move(); 
		}

		if (moving)
		{
			if (transform.position == pos)
			{
				moving = false;
				canMove = true;

				move();
			}

			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		}
	}

	private void move()
	{
		if (buttonCooldown <= 0)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				canMove = false;
				moving = true;
				pos += Vector3.up;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				canMove = false;
				moving = true;
				pos += Vector3.down;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				canMove = false;
				moving = true;
				pos += Vector3.right;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				canMove = false;
				moving = true;
				pos += Vector3.left;
			}
		}
	}
}
