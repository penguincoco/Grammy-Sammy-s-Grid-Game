using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
	[HideInInspector]public bool boxInGoal;
	private GameObject mainCamera;
	private FirstLevel levelScript;
	
	// Use this for initialization
	void Start ()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		levelScript = mainCamera.GetComponent<FirstLevel>();
	}
	
	// Update is called once per frame
	void Update () {
//		levelScript.goalsInPlace = -1;
//		Debug.Log(levelScript.goalsInPlace);
	}

	void OnTriggerExit2D(Collider2D otherObj)
	{
		//levelScript.goalsInPlace--;
		boxInGoal = false; 
	}
	
	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.gameObject.CompareTag("Box"))
		{
			boxInGoal = true;
			//Debug.Log(boxInGoal);
//			levelScript.goalsInPlace++;
//			Debug.Log(levelScript.goalsInPlace);
		} 
	}

	public bool getGoalStatus()
	{
		Debug.Log(boxInGoal);
		return boxInGoal;
	}
	
}
