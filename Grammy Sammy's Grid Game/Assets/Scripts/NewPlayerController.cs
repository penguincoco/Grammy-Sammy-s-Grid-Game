using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
	//player characteristics: their ability to move, if they are moving, speed, where they're trying to go, step count
	public bool canMove;
	public bool isMoving;
	private int speed = 5;
	private Vector3 towardsPos;
	private Vector3 towardsPosCheck;
	[HideInInspector]public int steps;
	
	//private int walls;

	//check to see if the player is next to a wall, if it is, then do NOT run moveTowards 
	private bool isNear;
	private GameObject[] walls;
	private GameObject[] boxes;
	[HideInInspector]public String direction;

	private bool isBlocked;

	public int coolDown; 
	
	// Use this for initialization
	void Start()
	{
		coolDown = 0;
		steps = 0;
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
		
		//Debug.Log(Vector3.left);
		if (canMove && !isMoving)
		{
			coolDown = 5;
			towardsPos = transform.position;
			towardsPosCheck = transform.position;
			Move();
		}

		if (!isMoving)
		{
			coolDown--;
			if (coolDown <= 0)
			{
				canMove = true;
				coolDown = 5;
			}
		}
		
		if (isMoving)
		{
			//if the player has reached the next grid spot, they can move again
			if (transform.position == towardsPos)
			{
				isMoving = false;				

//				if (isMoving) 
//				{
//					coolDown = 5;
//				}
				//Move();
			}

			transform.position = Vector3.MoveTowards(transform.position, towardsPos, Time.deltaTime * speed);
			StepCounter();
		}
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.UpArrow) && !Blocked(towardsPosCheck += Vector3.up) && !BlockedForBox(towardsPosCheck, "up"))
		{
			direction = "up";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow) && !Blocked(towardsPosCheck += Vector3.down) && !BlockedForBox(towardsPosCheck, "down"))
		{
			direction = "down";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.down;
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Blocked(towardsPosCheck += Vector3.right) && !BlockedForBox(towardsPosCheck, "right"))
		{
			direction = "right";
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && !Blocked(towardsPosCheck += Vector3.left) && !BlockedForBox(towardsPosCheck, "left"))
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
			{
				//Debug.Log("there is a wall so therefore i cannot move");
				return true;
			}
		}
		return false;  
	}
	
	bool BlockedForBox(Vector3 towardsPosCheck, String direction)
	{
		Vector3 secondPosCheck = Vector3.zero;
		foreach (GameObject box in boxes)
		{
			if (towardsPosCheck.x <= (box.transform.position.x + 0.5f) &&
			    towardsPosCheck.x >= (box.transform.position.x - 0.5f) &&
			    towardsPosCheck.y >= (box.transform.position.y - 0.5f) &&
			    towardsPosCheck.y <= (box.transform.position.y + 0.5f)
				)
			{
				//Debug.Log("there is a box in front of me");
				if (direction == "right")
				{
					secondPosCheck = towardsPosCheck + Vector3.right;
				}
				else if (direction == "left")
				{
					secondPosCheck = towardsPosCheck + Vector3.left;
				}
				else if (direction == "up")
				{
					secondPosCheck = towardsPosCheck + Vector3.up;
				}
				else if (direction == "down")
				{
					secondPosCheck = towardsPosCheck + Vector3.down;
				}
				
				
				if (box.GetComponent<Box>().BoxBlocked(secondPosCheck))
				{
					return true;
				}
			}
		}
		return false;  
	}
	
	private void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.gameObject.CompareTag("Box"))
		{
			isBlocked = otherObj.GetComponent<Box>().isBlocked;
		}
	}
	
	private void StepCounter()
	{
		steps++;
	}
}
