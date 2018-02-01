using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0f,transform.position.y + speed * Time.deltaTime, 0f);

        if(transform.position.y >= 60){
            GetComponent<Rigidbody>().useGravity = true;
        }
	}
}
