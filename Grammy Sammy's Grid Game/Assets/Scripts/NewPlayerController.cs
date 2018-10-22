using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

	private enum direction
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
	private direction orientation; 

	//check to see if the player is next to a wall, if it is, then do NOT run moveTowards 
	private bool isNear;
	private GameObject[] walls;


	// Use this for initialization
	void Start()
	{
		canMove = true;
		isMoving = false;
		speed = 5; 
		walls = GameObject.FindGameObjectsWithTag("Wall");
		orientation = direction.RIGHT;
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove)
		{
			towardsPos = transform.position;
			move();
		}

		if (isMoving)
		{
			//if the player has reached the next grid spot, they can move again
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
		if (Input.GetKey(KeyCode.UpArrow) && !Blocked(towardsPos += Vector3.up))
		{
			orientation = direction.UP;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow) && !Blocked(towardsPos += Vector3.down))
		{
			orientation = direction.DOWN;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.down;
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Blocked(towardsPos += Vector3.right))
		{
			orientation = direction.RIGHT;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && !Blocked(towardsPos += Vector3.left)) 
		{
			orientation = direction.LEFT;
			canMove = false;
			isMoving = true;
			towardsPos += Vector3.left;
		}
	}

	bool Blocked(Vector3 towardsPos)
	{
		foreach (GameObject wall in walls)
		{
			if (wall.transform.position == towardsPos)
			{
				Debug.Log("There is a wall so I cannot move");
				return true;
			}
		}

		return false;
	}

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

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Wall"))
		{
			Debug.Log("hit a wall, can't move!");
			canMove = false; 
		}
	}
}

//		Vector3 dir = (this.transform.position - transform.position).normalized;
//		float dot = Vector3.Dot(dir, transform.forward);

//	void caster(Vector2 center, float radius)
//	{
//		Collider2D[] walls = Physics2D.OverlapAreaAll();
//	}
//}