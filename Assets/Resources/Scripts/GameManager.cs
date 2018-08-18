using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Handles hits, misses, speed, and height to create game play
    // Control levels & rainbow
    // makes sure cubes and rings are set to same height

    // numCubes -> height = numCubes * 8f + 8
    // numRings -> height = numRings * 8f

    // Master values

    public float hits;
    public float misses;
    public float speed;
    public float levelHeight;
    public float climbLeft;
    public int level;

    public int numRings; // determined via levelHeight
    public int numCubes; // determined via levelHeight
	// Use this for initialization
	void Start () {
        level = 1;

        numRings = levelHeight / 8f; // <- left off figuring out for number of rings and number of cubes within certain height level
        // see equations above
	}
	
	// Update is called once per frame
	void Update () {
        hits = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerMovement>().numberShot;
        climbLeft = levelHeight - GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerMovement>().transform.position.y;

        if(climbLeft < 0f) { // successfully climbed entire level
            level += 1;
        }

        Debug.Log(misses);
	}
}
