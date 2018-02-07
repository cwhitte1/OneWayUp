using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public bool gameStarted = false;
    public float score = 0f;

    public float numberShot;

    Text numShotText;
    Text scoreText;

	// Use this for initialization
	void Start () {
        numberShot = 0;

        numShotText = GameObject.FindGameObjectWithTag("HitsInt").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreFloat").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStarted)
        {
            if (numberShot < 10)
                transform.position = new Vector3(0f, transform.position.y + speed * Time.deltaTime, 0f);
            else
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
            }

            if (score < transform.position.y)
            {
                score = transform.position.y;
            }

            if(GetComponent<Rigidbody>().transform.position.y < -10f){
                SceneManager.LoadScene("MainScene");
                /*
                gameStarted = false;
                numberShot = 0;
                score = 0f;
                GetComponent<Rigidbody>().transform.position = new Vector3(0f,0f,0f);
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;
                */
            }
        }

        numShotText.text = (numberShot).ToString();
        scoreText.text = score.ToString();
	}

    public void IncrementScore(){
        numberShot += 1;
        //Debug.Log("increment called");
    }
}
