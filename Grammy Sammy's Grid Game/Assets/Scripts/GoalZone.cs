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
		Debug.Log(boxInGoal);
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		Debug.Log("Something has entered goal's trigger zone");
		if (otherObj.gameObject.CompareTag("Box"))
		{
			Debug.Log("There is a box in the goal!");
			Debug.Log(boxInGoal);
			boxInGoal = true;
		}
	}

	public bool GetGoalStatus()
	{
		return boxInGoal; 
	}
}
