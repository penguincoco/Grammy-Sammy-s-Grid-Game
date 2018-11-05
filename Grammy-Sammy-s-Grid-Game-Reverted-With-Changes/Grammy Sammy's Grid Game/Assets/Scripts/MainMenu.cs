using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Alpha1))
		{
			SceneManager.LoadScene("Level1");
		}
		
		if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Level2");
		}
	}
}
