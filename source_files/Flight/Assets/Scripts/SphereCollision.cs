using UnityEngine;
using System.Collections;
using System;

public class SphereCollision : MonoBehaviour {

    private string lastName = String.Empty; 

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Sphere"))
        {
            if (lastName != col.gameObject.name || lastName == String.Empty)
            {
                lastName = col.gameObject.name;
                ScoreCount.score += 10;
                var tmp = col.gameObject.transform.position;
                var sph = GameObject.Instantiate(GameObject.Find("Detonator-Insanity"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Destroy(col.gameObject);
            }
        }
    }
}
