using UnityEngine;
using System.Collections;

public class CheckSpawn : MonoBehaviour {

    float touching = 0;
	// Use this for initialization
	void Update () {
	    if(touching >= 2)
        {
            Destroy(gameObject);
        }
	}
	
    void OnCollisionStay() 
    {
        Debug.Log("Stuff Touching");
        touching++;
    }
}
