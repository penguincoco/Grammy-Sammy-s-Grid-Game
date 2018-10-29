using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

	private bool canMove;
	private bool isMoving;
	private int speed = 5;
	private Vector3 towardsPos;
	private Vector3 towardsPosCheck;

	//private int walls;

	//check to see if the player is next to a wall, if it is, then do NOT run moveTowards 
	private bool isNear;
	private GameObject[] walls;
	private GameObject[] boxes;
	[HideInInspector]public String direction;


	// Use this for initialization
	void Start()
	{
		direction = "right";
		canMove = true;
		isMoving = false;
		speed = 5;
		walls = GameObject.FindGameObjectsWithTag("Wall");
		boxes = GameObject.FindGameObjectsWithTag("Box");
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(Vector3.left);
		if (canMove && !isMoving)
		{
			towardsPos = transform.position;
			towardsPosCheck = transform.position;
			Move();
		}

		if (isMoving)
		{
			//if the player has reached the next grid spot, they can move again
			if (transform.position == towardsPos)
			{
				isMoving = false;
				canMove = true;
				//Move();
			}

			transform.position = Vector3.MoveTowards(transform.position, towardsPos, Time.deltaTime * speed);
		}
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.UpArrow) && !Blocked(towardsPosCheck += Vector3.up))
		{
			direction = "up";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow) && !Blocked(towardsPosCheck += Vector3.down))
		{
			direction = "down";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.down;
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Blocked(towardsPosCheck += Vector3.right))
		{
			direction = "right";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && !Blocked(towardsPosCheck += Vector3.left))
		{
			direction = "left"; 
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.left;
		}
	}

	bool Blocked(Vector3 towardsPosCheck)
	{
		foreach (GameObject wall in walls)
		{
			if (towardsPosCheck.x <= (wall.transform.position.x + 0.5f) &&
			    towardsPosCheck.x >= (wall.transform.position.x - 0.5f) &&
			    towardsPosCheck.y >= (wall.transform.position.y - 0.5f) &&
			    towardsPosCheck.y <= (wall.transform.position.y + 0.5f)
			    )
			//if (wall.transform.position == towardsPosCheck)
			{
				Debug.Log("there is a wall so therefore i cannot move");
				return true;
			}
		}
		return false;  
	}

//	private void OnTriggerEnter2D(Collider2D otherObj)
//	{
//		if (otherObj.gameObject.CompareTag("Box"))
//		{
//			
//		}
//	}
}

//		
//		foreach (GameObject wall in walls)
//		{
//			if (wall.transform.position == towardsPosCheck)
//			{
//				Debug.Log("there is a wall so therefore i cannot move");
//				return true;
//			}
//		}
//
//		return false;
//	}
