using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private NewPlayerController playerScript;
    private String playerDirection;
    private Vector3 currentPos;
    private Vector3 moveTowards;
    private Vector3 moveTowardsCheck;
    private int speed;

    private bool canBePushed;
    private bool isBeingPushed;

    [HideInInspector]public bool isBlocked;

    private GameObject[] walls;
    private GameObject[] boxes;
    private GameObject[] goalZones;

    private GoalZone goalScript;
    private FirstLevel levelScript;
    private int inGoals;
    
    void Start()
    {
        isBlocked = false;
        canBePushed = false;
        isBeingPushed = false;
        currentPos = transform.position;
        playerDirection = "";
        speed = 5;
        walls = GameObject.FindGameObjectsWithTag("Wall");
        boxes = GameObject.FindGameObjectsWithTag("Box");
        goalZones = GameObject.FindGameObjectsWithTag("Goal");
    }

    void Update()
    {
        if (!canBePushed && !isBeingPushed)
        {
            moveTowards = transform.position;
            moveTowardsCheck = transform.position;
            MoveBox();
        }

        if (isBeingPushed)
        {
            //Debug.Log("box is mid movement");
            transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * speed);
            //if the player has reached the next grid spot, they can move again
            if (transform.position == moveTowards)
            {
                Debug.Log("You have arrived at your destination");
                isBeingPushed = false;
                canBePushed = true;
                
            }
        }

        foreach (GameObject goal in goalZones)
        {
            goalScript = goal.gameObject.GetComponent<GoalZone>();
            
            if (transform.position.x <= (goal.transform.position.x + 0.5f) &&
                transform.position.x >= (goal.transform.position.x - 0.5f) &&
                transform.position.y >= (goal.transform.position.y - 0.5f) &&
                transform.position.y <= (goal.transform.position.y + 0.5f)
            )
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //Debug.Log("Player has collided with me, ya boi, a box");
        if (otherObj.gameObject.CompareTag("Player"))
        {
            playerScript = otherObj.gameObject.GetComponent<NewPlayerController>();
            playerDirection = playerScript.direction;
            canBePushed = false;
            isBeingPushed = false;
        }
    }

    void MoveBox()
    {
        if (playerDirection.Equals("right") && !BoxBlocked(moveTowardsCheck + Vector3.right))
        {
            moveTowards += Vector3.right;
        }
        else if (playerDirection == "left" && !BoxBlocked(moveTowardsCheck + Vector3.left))
        {
            moveTowards += Vector3.left;
        }
        else if (playerDirection == "up"  && !BoxBlocked(moveTowardsCheck + Vector3.up))
        {
            moveTowards += Vector3.up;
        }
        else if (playerDirection == "down" && !BoxBlocked(moveTowardsCheck + Vector3.down))
        {
            moveTowards += Vector3.down;
        }

        //Debug.Log("Move being run");
        canBePushed = false;
        isBeingPushed = true;
//        Debug.Log("Is being pushed status: " + isBeingPushed);
//        Debug.Log("Can be pushed status: " + canBePushed);
        //transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * speed);
    }

    public bool BoxBlocked(Vector3 moveTowardsCheck)
    {
        foreach (GameObject wall in walls)
        {
            if (moveTowardsCheck.x <= (wall.transform.position.x + 0.5f) &&
                moveTowardsCheck.x >= (wall.transform.position.x - 0.5f) &&
                moveTowardsCheck.y >= (wall.transform.position.y - 0.5f) &&
                moveTowardsCheck.y <= (wall.transform.position.y + 0.5f)
                )
                //if (wall.transform.position == towardsPosCheck)
            {
                //Debug.Log("there is a wall so therefore i, ya boxy boi, cannot move");
                isBlocked = true;  
                return true;
            }
        }
        
        foreach (GameObject box in boxes)
        {
            if (moveTowardsCheck.x <= (box.transform.position.x + 0.5f) &&
                moveTowardsCheck.x >= (box.transform.position.x - 0.5f) &&
                moveTowardsCheck.y >= (box.transform.position.y - 0.5f) &&
                moveTowardsCheck.y <= (box.transform.position.y + 0.5f)
                )
                //if (wall.transform.position == towardsPosCheck)
            {
                //Debug.Log("there is a wall so therefore i, ya boxy boi, cannot move");
                isBlocked = true;  
                return true;
            }
        }
        return false;  
    }
}