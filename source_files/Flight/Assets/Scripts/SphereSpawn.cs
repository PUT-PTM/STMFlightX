using UnityEngine;
using System.Collections;

public class SphereSpawn : MonoBehaviour
{

    GameObject  sphere;
    public int amountbject = 0;

    //Creating object instantiate...
    void Start()
    {
        amountbject++;
        if (amountbject < 30)
        {
            float x = Random.Range(50.0f, 400.0f);
            float y = Random.Range(50.0f, 200.0f);
            float z = Random.Range(50.0f, 400.0f);

            //var cube = GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
            var sphere = GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
        }
    }


    void Update()
    {

    }
}
