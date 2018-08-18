using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour
{
    // height is numberRings * spaceBetweenRings I believe

    public bool rainbowMode = false;

    [Range(3, 360)]
    public int segments = 3;
    public float innerRadius = 0.7f;
    public float thickness = 0.5f;
    public Material ringMaterial;

    // will make colors into Enum once I am off plane and can check syntax lol
    public Material redMaterial; // 0
    public Material orangeMaterial; // 1
    public Material yellowMaterial; // 2
    public Material greenMaterial; // 3
    public Material blueMaterial; // 4
    public Material darkpurpleMaterial; // 5
    public Material magentapurpleMaterial; // 6


    GameObject ring;
    Mesh ringMesh;
    MeshFilter ringMF;
    MeshRenderer ringMR;

    public int numberRings = 8;
    public float spaceBetweenRings = 8f;

    void Start(){
        //will be enum once I can check syntax, on plane to san diego
        ArrayList Colors = new ArrayList();
        /*Colors[0] = redMaterial;
        Colors[1] = orangeMaterial;
        Colors[2] = yellowMaterial;
        Colors[3] = greenMaterial;
        Colors[4] = blueMaterial;
        Colors[5] = darkpurpleMaterial;
        Colors[6] = magentapurpleMaterial; */

        Colors.Add(redMaterial);
        Colors.Add(orangeMaterial);
        Colors.Add(yellowMaterial);
        Colors.Add(greenMaterial);
        Colors.Add(blueMaterial);
        Colors.Add(darkpurpleMaterial);
        Colors.Add(magentapurpleMaterial);

        // will the below be instantiated in GameManager prior to hitting this start? maybe use other method that builds upon compilation
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().;

        if (rainbowMode)
        {
            for (int i = 0; i < numberRings; i++){
                Material temp = (Material)Colors[i%7];
                ConstructColorRing(i * spaceBetweenRings, temp);
            }
        }
        else
        {
            for (int i = 0; i < numberRings; i++)
            {
                ConstructRing(i * spaceBetweenRings);
            }
        }
        
    }
	
	void ConstructRing(float height) {

        ring = new GameObject(name + "Ring");
        ring.transform.parent = transform;
        ring.transform.localScale = Vector3.one;
        ring.transform.localPosition = new Vector3(0f, height, 0f); //Vector3.zero; // change y here
        ring.transform.localRotation = Quaternion.identity;
        ringMF = ring.AddComponent<MeshFilter>();
        ringMesh = ringMF.mesh;
        ringMR = ring.AddComponent<MeshRenderer>();
        ringMR.material = ringMaterial;

        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2];
        int[] triangles = new int[segments * 6 * 2];
        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2];
        int halfway = (segments + 1) * 2;

        for(int i = 0; i < segments + 1; i++){
            float progress = (float)i / (float)segments;
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius + thickness);
            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius;
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f);

            if(i != segments){
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1 + halfway;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
            }
        }

        ringMesh.vertices = vertices;
        ringMesh.triangles = triangles;
        ringMesh.uv = uv;
        ringMesh.RecalculateNormals();
	}

    void ConstructColorRing(float height, Material coloredRingMaterial)
    {

        ring = new GameObject(name + "Ring");
        ring.transform.parent = transform;
        ring.transform.localScale = Vector3.one;
        ring.transform.localPosition = new Vector3(0f, height, 0f); //Vector3.zero; // change y here
        ring.transform.localRotation = Quaternion.identity;
        ringMF = ring.AddComponent<MeshFilter>();
        ringMesh = ringMF.mesh;
        ringMR = ring.AddComponent<MeshRenderer>();
        ringMR.material = coloredRingMaterial;

        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2];
        int[] triangles = new int[segments * 6 * 2];
        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2];
        int halfway = (segments + 1) * 2;

        for (int i = 0; i < segments + 1; i++)
        {
            float progress = (float)i / (float)segments;
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius + thickness);
            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius;
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f);

            if (i != segments)
            {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1 + halfway;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
            }
        }

        ringMesh.vertices = vertices;
        ringMesh.triangles = triangles;
        ringMesh.uv = uv;
        ringMesh.RecalculateNormals();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
