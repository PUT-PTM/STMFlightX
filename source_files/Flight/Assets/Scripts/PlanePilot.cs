using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {
    float speed = 50.0f; //speed variable
    public Transform ExplosionPrefab;
	void Start () {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(50, 25, 100);
        //cube.AddComponent<Rigidbody>();
	}

    IEnumerator i()
    {
        float a = 5;
        yield return new WaitForSeconds(a);
        //Application.LoadLevel(Application.loadedLevel);
    }

	void Update () {

        //chase cam
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f; //chase cam
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position*bias+ moveCamTo * (1.0f- bias); //chase cam calculations 
        Camera.main.transform.LookAt(transform.position+transform.forward*30.0f); 

        //plane speed
        transform.position += transform.forward * Time.deltaTime * speed; 

        //acceleration during falling
        speed -= transform.forward.y * Time.deltaTime* 5.0f;

        if(speed<35.0f)
        {
            speed = 35.0f;
        }

        //plane steering - up/down/right/left
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        //terrain collision variable
        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
        
       

        //collider conditions
        //terrain collision
        if(terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);
            //checking plane name and destroying it when collision with terrain occurs
            if (gameObject.name.Contains("PlaneWhole"))
            {
                Destroy(gameObject);
                var plane = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(i());  //delay
               Application.LoadLevel(Application.loadedLevel);
            }
        }
        //back wall collision
        if(terrainHeightWhereWeAre > transform.position.x)
        {
            transform.position = new Vector3(terrainHeightWhereWeAre, transform.position.y, transform.position.z);
            if (gameObject.name.Contains("PlaneWhole"))
            {
                Destroy(gameObject);
                var plane = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(i());
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        //left wall collision
        if (terrainHeightWhereWeAre > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, terrainHeightWhereWeAre);
            if (gameObject.name.Contains("PlaneWhole"))
            {
                Destroy(gameObject);
                var plane = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(i());
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        //right wall collision
        if (transform.position.z>500)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 500);
            if (gameObject.name.Contains("PlaneWhole"))
            {
                Destroy(gameObject);
                var plane = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(i());
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        //front wall collision
        if (transform.position.x>500)
        {
            transform.position = new Vector3(500, transform.position.y, transform.position.z);
            if (gameObject.name.Contains("PlaneWhole"))
            {
                Destroy(gameObject);
                var plane = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Application.LoadLevel(Application.loadedLevel);
            }
        }


    }
}
