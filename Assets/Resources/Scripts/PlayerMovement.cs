using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public bool gameStarted = false;
    public float score = 0f;

    public float numberShot;

    Text numShotText;
    Text scoreText;

	// Use this for initialization
	void Start () {
        numberShot = 1; // start at one for logic right now

        numShotText = GameObject.FindGameObjectWithTag("HitsInt").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreFloat").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStarted)
        {
            if(numberShot < 8)
            transform.position = new Vector3(0f, transform.position.y + speed * Time.deltaTime, 0f);
            else GetComponent<Rigidbody>().useGravity = true;

            /*
            if ((transform.position.y/10f)>numberShot)
            {
                GetComponent<Rigidbody>().useGravity = true;
            } else {
                GetComponent<Rigidbody>().useGravity = false;
                //transform.position = new Vector3(0f, transform.position.y + speed * Time.deltaTime, 0f);
            }
            */

            if (score < transform.position.y)
            {
                score = transform.position.y;
            }
        }

        numShotText.text = (numberShot-1).ToString();
        scoreText.text = score.ToString();


        //Debug.Log(numberShot - 1);
	}

    public void IncrementScore(){
        numberShot += 1;
        //Debug.Log("increment called");
    }
}
