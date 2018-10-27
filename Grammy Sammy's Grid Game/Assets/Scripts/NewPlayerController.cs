using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

	public enum direction
	{
		RIGHT,
		LEFT,
		UP,
		DOWN
	};

	private bool canMove;
	private bool isMoving;
	private int speed = 5;
	private Vector3 towardsPos;
	private Vector3 towardsPosCheck;
	private direction orientation;

	//private int walls;

	//check to see if the player is next to a wall, if it is, then do NOT run moveTowards 
	private bool isNear;
	private GameObject[] walls;
	private GameObject[] boxes;


	// Use this for initialization
	void Start()
	{
		//walls = 8;
		canMove = true;
		isMoving = false;
		speed = 5;
		walls = GameObject.FindGameObjectsWithTag("Wall");
		boxes = GameObject.FindGameObjectsWithTag("Box");
		orientation = direction.RIGHT;
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove && !isMoving)
		{
			towardsPos = transform.position;
			towardsPosCheck = transform.position;
			move();
		}

		if (isMoving)
		{
			//if the player has reached the next grid spot, they can move again
			if (transform.position == towardsPos)
			{
				isMoving = false;
				canMove = true;
				//move();
			}

			transform.position = Vector3.MoveTowards(transform.position, towardsPos, Time.deltaTime * speed);
		}
	}

	private void move()
	{
		if (Input.GetKey(KeyCode.UpArrow) && !Blocked(towardsPosCheck += Vector3.up))
		{
			orientation = direction.UP;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow) && !Blocked(towardsPosCheck += Vector3.down))
		{
			orientation = direction.DOWN;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.down;
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Blocked(towardsPosCheck += Vector3.right))
		{
			orientation = direction.RIGHT;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && !Blocked(towardsPosCheck += Vector3.left))
		{
			orientation = direction.LEFT;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.left;
		}
	}

	bool Blocked(Vector3 towardsPosCheck)
	{
		foreach (GameObject wall in walls)
		{
			if (wall.transform.position == towardsPosCheck)
			{
				Debug.Log("there is a wall so therefore i cannot move");
				return true;
			}
		}

		//return false;

//		foreach (GameObject box in boxes)
//		{
//			if (box.GetComponent<Box>().BoxBlocked())
//			{
//				Debug.Log("there is a box behind the box so I cannot push it");
//				return true;
//			}
//		}
		return false;
	}

	private void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.gameObject.CompareTag("Box"))
		{
			otherObj.GetComponent<Box>().MoveBox();
		}
	}
}

//	bool Blocked(Vector3 towardsPosCheck)
//	{
//		Vector2 positionCheck = new Vector2(towardsPosCheck.x, towardsPosCheck.y);
//
//		Collider2D overlap = Physics2D.OverlapPoint(positionCheck, walls, 0, 0);
//		Debug.Log(overlap);
//		
//		if (overlap != null)
//		{
//			Debug.Log(overlap);
//			return true; 
//		}
//		
//		return false;
//	}
//}




//	void checkInFront()
//	{
//		if (orientation == direction.LEFT)
//		{
//			Collider2D wall = Physics2D.OverlapArea(
//				new Vector2(transform.position.x + 1, transform.position.y + 0.5f),
//				new Vector2(transform.position.x + 1, transform.position.y - 0.5f));
//
//			if (wall != null)
//			{
//				canMove = false;
//			}
//		}
//
//		
//	}

//		if (otherObj.CompareTag("Wall"))
//		{
//			Debug.Log("hit a wall, can't move!");
//			canMove = false; 
//		}
//	}
//}

//		Vector3 dir = (this.transform.position - transform.position).normalized;
//		float dot = Vector3.Dot(dir, transform.forward);

//	void caster(Vector2 center, float radius)
//	{
//		Collider2D[] walls = Physics2D.OverlapAreaAll();
//	}
//}
