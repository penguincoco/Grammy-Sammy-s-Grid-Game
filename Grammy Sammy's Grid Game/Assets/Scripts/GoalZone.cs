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
		boxInGoal = false;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		levelScript = mainCamera.GetComponent<FirstLevel>();
	}
	
	// Update is called once per frame
	void Update () {
//		levelScript.goalsInPlace = -1;
//		Debug.Log(levelScript.goalsInPlace);
	}


	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.gameObject.CompareTag("Box"))
		{
			Debug.Log("Box has entered trigger zone!");
			Debug.Log("There is a box in the goal!");
			boxInGoal = true;
			levelScript.goalsInPlace++;
			Debug.Log(levelScript.goalsInPlace);
		} 
	}

//	private void OnTriggerExit2D(Collider2D otherObj)
//	{
//		levelScript.goalsInPlace--;
//		Debug.Log(levelScript.goalsInPlace);
//	}
}
