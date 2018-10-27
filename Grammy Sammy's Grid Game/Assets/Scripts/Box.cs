using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

	private bool canMove;
	private bool isMoving;
	private int speed = 5;
	private Vector3 towardsPos;
	private Vector3 towardsPosCheck;

	private GameObject[] walls;
	private GameObject[] boxes;

	void Start()
	{
		//walls = 8;
		canMove = true;
		isMoving = false;
		speed = 5;
		walls = GameObject.FindGameObjectsWithTag("Wall");
		boxes = GameObject.FindGameObjectsWithTag("Box");
	}

	// Update is called once per frame
	void Update()
	{
//		if (canMove && !isMoving)
//		{
//			towardsPos = transform.position;
//			towardsPosCheck = transform.position;
//			MoveBox();
//		}
//
//		if (isMoving)
//		{
//			//if the player has reached the next grid spot, they can move again
//			if (transform.position == towardsPos)
//			{
//				isMoving = false;
//				canMove = true;
//			}
//
//			transform.position = Vector3.MoveTowards(transform.position, towardsPos, Time.deltaTime * speed);
//		}
	}
	
	public void MoveBox()
	{
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

	public bool BoxBlocked()
	{
		foreach (GameObject box in boxes)
		{
			if (Input.GetKey(KeyCode.UpArrow) && this.transform.position == box.transform.position)
			{
				return true;
			}
			else if (Input.GetKey(KeyCode.DownArrow) && this.transform.position == box.transform.position)
			{
				return true;
			}
			else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position == box.transform.position)
			{
				return true;
			}
			else if (Input.GetKey(KeyCode.LeftArrow) &&this.transform.position == box.transform.position)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		return false; 
	}
}
