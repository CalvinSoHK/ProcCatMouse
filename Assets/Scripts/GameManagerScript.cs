using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public List<Transform> mouseList;
    public List<Transform> catList;

	// Use this for initialization
	void Start () {
        mouseList = new List<Transform>();
        catList = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
