﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour { // this isn't functioning as an object pool anymore, more as object spawning script for now

    public Transform cube;
    public GameObject[] cubes;
    public int numberCubes;
    public float rad = 5f;

    public bool rainbowMode = false;

    // will add Enum for this too
    public Transform redCube; // 0
    public Transform orangeCube; // 1
    public Transform yellowCube; // 2
    public Transform greenCube; // 3
    public Transform blueCube; // 4
    public Transform darkpurpleCube; // 5
    public Transform magentapurpleCube; // 6

    ArrayList Colors = new ArrayList();


	// Use this for initialization
	void Start () {


        Colors.Add(redCube);
        Colors.Add(orangeCube);
        Colors.Add(yellowCube);
        Colors.Add(greenCube);
        Colors.Add(blueCube);
        Colors.Add(darkpurpleCube);
        Colors.Add(magentapurpleCube);

        Vector3 center = Camera.main.gameObject.transform.position;

        if(rainbowMode){
            for(int x = 0; x < numberCubes; x++){
                //Vector3 pos = RandomCircle(center, rad);
                float xcor = rad * Mathf.Cos(x * (360 / numberCubes));
                float ycor = rad * Mathf.Sin(x * (360 / numberCubes));
                Vector3 pos = new Vector3(xcor, (x * 8f + 8), ycor);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                Transform temp = (Transform) Colors[x % 7];
                Instantiate(temp, pos, rot);
            }
            
        } else {
            for(int x = 0; x < numberCubes; x++){
                //Vector3 pos = RandomCircle(center, rad);
                float xcor = rad * Mathf.Cos(x * (360 / numberCubes));
                float ycor = rad * Mathf.Sin(x * (360 / numberCubes));
                Vector3 pos = new Vector3(xcor, (x * 8f + 8), ycor);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                Instantiate(cube, pos, rot);
            }
        }


        /*Vector3 center = Camera.main.gameObject.transform.position;
        for (int x = 0; x < numberCubes; x++){
            //Vector3 pos = RandomCircle(center, rad);
            float xcor = rad * Mathf.Cos(x * (360 / numberCubes));
            float ycor = rad * Mathf.Sin(x * (360 / numberCubes));
            Vector3 pos = new Vector3(xcor, (x * 8f + 8), ycor);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(cube, pos, rot);
        } */
	}
	
	// Update is called once per frame
	void Update () {
	}

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
