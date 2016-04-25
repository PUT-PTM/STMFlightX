using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {
    float speed = 90.0f; //speed variable
	void Start () {
	
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
        speed -= transform.forward.y * Time.deltaTime* 50.0f;

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
        }
        //back wall collision
        if(terrainHeightWhereWeAre > transform.position.x)
        {
            transform.position = new Vector3(terrainHeightWhereWeAre, transform.position.y, transform.position.z);
        }
        //left wall collision
        if (terrainHeightWhereWeAre > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, terrainHeightWhereWeAre);
        }
        //right wall collision
        if (transform.position.z>500)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 500);
        }
        //front wall collision
        if (transform.position.x>500)
        {
            transform.position = new Vector3(500, transform.position.y, transform.position.z);
        }


    }
}
