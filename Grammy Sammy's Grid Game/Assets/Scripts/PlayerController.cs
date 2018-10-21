using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private float speed;
	private Vector3 pos;

	private Rigidbody2D thisRigidbody;

	// Use this for initialization
	void Start()
	{
		pos = transform.position;
		speed = 2.0f;
		thisRigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * 0.1f);
		}
		
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector2.up * -0.1f);
		}
		
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * 0.1f);
		}
		
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector2.right * -0.1f);
		}
		


		/*
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			thisRigidbody.MovePosition(new Vector2(transform.position.x + 1, transform.position.y));
			//thisRigidbody.velocity = new Vector3(1, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			thisRigidbody.MovePosition(new Vector2(transform.position.x - 1, transform.position.y));
			//thisRigidbody.velocity = new Vector3(-1, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			thisRigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y + 1));
			//thisRigidbody.velocity = new Vector3(0, 1, 0);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			thisRigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y - 1));
			//thisRigidbody.velocity = new Vector3(0, -1, 0);
		}



		if (!Input.anyKey)
		{
			thisRigidbody.velocity = new Vector3(0, 0, 0);
		}
		 
		*/
	}
/*
	private void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Box"))
		{
			Debug.Log("Collided with a box");
			otherObj.transform.parent = this.transform;
			otherObj.transform.position = new Vector3(this.transform.position.x + 1f,
				this.transform.position.y + 1f,
				this.transform.position.z);
		}
	}*/
}