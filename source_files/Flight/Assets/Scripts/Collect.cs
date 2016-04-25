using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	void OnTriggerEnter(Collider Playerinfo)
    {
        if(Playerinfo.name=="PlaneWhole")
        {
            Destroy(gameObject);
        }
    }
}
