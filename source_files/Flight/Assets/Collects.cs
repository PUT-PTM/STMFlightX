using UnityEngine;
using System.Collections;

public class Collects : MonoBehaviour
{

    void OnTriggerEnter(Collider Playerinfo)
    {
        if (Playerinfo.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
