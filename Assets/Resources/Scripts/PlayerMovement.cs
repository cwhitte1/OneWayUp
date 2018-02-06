using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public bool gameStarted = false;
    public float score = 0f;

    public float numberShot;

	// Use this for initialization
	void Start () {
        numberShot = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStarted)
        {
            transform.position = new Vector3(0f, transform.position.y + speed * Time.deltaTime, 0f);

            if ((transform.position.y/10f)>numberShot)
            {
                GetComponent<Rigidbody>().useGravity = true;
            } else {
                GetComponent<Rigidbody>().useGravity = false;
            }

            if (score < transform.position.y)
            {
                score = transform.position.y;
            }
        }
	}
}
