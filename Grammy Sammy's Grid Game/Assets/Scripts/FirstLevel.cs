﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class FirstLevel : MonoBehaviour {

	//This is what will display level 1
	//map a 2D matrix
	//based on what is living on a certain index, spawn that. 
	//So, for example, if there's an x in [row][column], instantiate a box at that location.

	/*
	 * Key
	 * "#" = brick/wall
	 * "b" = box
	 * "p" =  player
	 * "0" = goal
	 * " " = blank spot
	 */

	public GameObject wall;
	public GameObject box;
	public GameObject player;
	public GameObject goal;
	public GameObject blankSpot;

	public int row;
	public int col;

	public string[,] levelMap; //rows first, then inner array is column
	
	// Use this for initialization
	void Start ()
	{
		row = 9;
		col = 9; 
		
		levelMap = new string[,]
//		{
//			{"#", "#", "#", "#", "#", " ", " ", " ", " "},
//			{"#", "p", " ", " ", "#", " ", " ", " ", " "},
//			{"#", " ", "b", "b", "#", " ", "#", "#", "#"},
//			{"#", " ", "b", " ", "#", " ", "#", "0", "#"},
//			{"#", "#", "#", " ", "#", "#", "#", "0", "#"},
//			{" ", "#", "#", " ", " ", " ", " ", "0", "#"},
//			{" ", "#", " ", " ", " ", "#", " ", " ", "#"},
//			{" ", "#", " ", " ", " ", "#", "#", "#", "#"},
//			{" ", "#", "#", "#", "#", "#", " ", " ", "#"},
//		};
		
		{
			{" ", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", "#", "#", " ", " ", "p", "#"},
			{"#", " ", " ", "#", "#", "b", "b", " ", "#"},
			{"#", " ", " ", " ", " ", " ", "b", " ", "#"},
			{"#", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", " ", "#", " ", " ", " ", " "},
			{" ", "#", " ", " ", "#", "#", "#", " ", " "},
			{" ", "#", " ", "0", "0", "0", "#", " ", " "},
			{" ", "#", "#", "#", "#", "#", "#", " ", " "}
		}; 
		

		for (int i = 0; i < row; i++)
		{
			Debug.Log("i = " + i);
			
			for (int j = 0; j < col; j++)
			{
				Debug.Log(levelMap[i, j]);
				if (levelMap[i, j] == "#")
				{
					Instantiate(wall, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
				else if (levelMap[i, j] == "b")
				{
					Instantiate(box, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
				else if (levelMap[i, j] == "p")
				{
					Instantiate(player, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}