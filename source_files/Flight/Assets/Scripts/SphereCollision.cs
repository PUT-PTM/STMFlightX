using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Sphere"))
        {
            Destroy(col.gameObject);
            ScoreCount.score += 10;
        }
    }
}
