using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{

	private bool boxInGoal;
	
	// Use this for initialization
	void Start ()
	{
		boxInGoal = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Box"))
		{
			Debug.Log(boxInGoal);
			boxInGoal = true;
		}
	}

	public bool GetGoalStatus()
	{
		return boxInGoal; 
	}
}
