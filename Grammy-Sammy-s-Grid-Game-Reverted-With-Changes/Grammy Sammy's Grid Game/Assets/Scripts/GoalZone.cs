using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalZone : MonoBehaviour
{
	[HideInInspector]public bool boxInGoal;
	private GameObject mainCamera;
	private LevelManager levelScript;
	
	// Use this for initialization
	void Start ()
	{
		boxInGoal = false;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		levelScript = mainCamera.GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
//		levelScript.goalsInPlace = -1;
//		Debug.Log(levelScript.goalsInPlace);
	}


	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.gameObject.CompareTag("Player"))
		{
			Debug.Log("Box has entered trigger zone!");
			Debug.Log("There is a box in the goal!");
			boxInGoal = true;
			levelScript.goalsInPlace++;
			Debug.Log(levelScript.goalsInPlace);
		} 
	}

//	void OnTriggerExit2D(Collider2D otherObj)
//	{
//		if (otherObj.gameObject.CompareTag("Box"))
//		{
//			Debug.Log("Box has entered trigger zone!");
//			Debug.Log("There is a box in the goal!");
//			boxInGoal = true;
//			levelScript.goalsInPlace--;
//			Debug.Log(levelScript.goalsInPlace);
//		} 
//	}
	
//	void OnTriggerEnter2D(Collider2D otherObj)
//	{
//		if (otherObj.gameObject.CompareTag("Box"))
//		{
//			Debug.Log("Box has entered trigger zone!");
//			Debug.Log("There is a box in the goal!");
//			boxInGoal = true;
//			levelScript.goalsInPlace++;
//			Debug.Log(levelScript.goalsInPlace);
//		} 
//	}
//
//	void OnTriggerExit2D(Collider2D otherObj)
//	{
//		levelScript.goalsInPlace--;
//		Debug.Log(levelScript.goalsInPlace);
//	}
	
	/*
	 * why. tf. is. this. not. working. how. stupid. am. i. w. t. f.
	 */
	
//	void OnTriggerExit2D(Collider2D otherObj)
//	{
//		if (otherObj.gameObject.CompareTag("Box"))
//		{
//			//trigger is working properly, this boolean is flipping to true here, but how come the FirstLevel
//			//script can't see that the boolean has changed? 
//			Debug.Log("Box exiting trigger zone");
//			boxInGoal = false;
//		} 
//	}
//	
//	void OnTriggerEnter2D(Collider2D otherObj)
//	{
//		if (otherObj.gameObject.CompareTag("Box"))
//		{
//			boxInGoal = true;
//			levelScript.goalsInPlace++;
//			Debug.Log(levelScript.goalsInPlace);
//			//Debug.Log(boxInGoal);
////			levelScript.goalsInPlace++;
////			Debug.Log(levelScript.goalsInPlace);
//		} 
//	}
//
//	public bool getGoalStatus()
//	{
//		return boxInGoal;
//	}
}
