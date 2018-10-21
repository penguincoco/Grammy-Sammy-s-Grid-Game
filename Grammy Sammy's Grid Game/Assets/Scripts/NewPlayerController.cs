using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

	private bool canMove = true;
	private bool isMoving = false;
	private int speed = 5;
	private Vector3 towardsPos;
 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		//buttonCooldown--;
		
		if (canMove)
		{
			towardsPos = transform.position;
			move(); 
		}

		if (isMoving)
		{
			if (transform.position == towardsPos)
			{
				isMoving = false;
				canMove = true;

				move();
			}

			transform.position = Vector3.MoveTowards(transform.position, towardsPos, Time.deltaTime * speed);
		}
	}

	private void move()
	{
		//if (buttonCooldown <= 0)
		//{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				canMove = false;
				isMoving = true;
				towardsPos += Vector3.up;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				canMove = false;
				isMoving = true;
				towardsPos += Vector3.down;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				canMove = false;
				isMoving = true;
				towardsPos += Vector3.right;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				canMove = false;
				isMoving = true;
				towardsPos += Vector3.left;
			}
		
	}
}