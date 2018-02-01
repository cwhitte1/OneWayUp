using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public Transform cube;
    public GameObject[] cubes;
    public int numberCubes;
    public float rad = 5f;

	// Use this for initialization
	void Start () {
        Vector3 center = Camera.main.gameObject.transform.position;
        for (int x = 0; x < numberCubes; x++){
            //Vector3 pos = RandomCircle(center, rad);
            float xcor = rad * Mathf.Cos(x * (360 / numberCubes));
            float ycor = rad * Mathf.Sin(x * (360 / numberCubes));
            Vector3 pos = new Vector3(xcor, 0f, ycor);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(cube, pos, rot);
        }
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
