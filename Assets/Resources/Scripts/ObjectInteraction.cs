using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteraction : MonoBehaviour {

    public float gazeTime = 2f;

    private float timer = 0f;

    private bool gazedAt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gazedAt){
            timer += Time.deltaTime;

            if(timer >= gazeTime){
                ExecuteEvents.Execute(gameObject,new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().AddForce(new Vector3(0f,100f,-100f));

                Behaviour halo = (Behaviour)GetComponent("Halo");
                halo.enabled = false;

            }
        }
        //Debug.Log(timer);
		
	}

    public void PointerEnter(){
        //Debug.Log("Pointer Enter");
        gazedAt = true;
    }

    public void PointerExit()
    {
        //Debug.Log("Pointer Exit");
        gazedAt = false;
    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
    }
}
