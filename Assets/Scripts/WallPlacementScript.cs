using UnityEngine;
using System.Collections;

public class WallPlacementScript : MonoBehaviour {

    [SerializeField]
    Transform wall;
    [SerializeField]
    Transform mazeWalls;

    Vector3 wallRotation;
    bool spawn;

	// Use this for initialization
	void Start () {
        while (transform.position.z > -50)
        {
            float randomValue = Random.Range(0f, 3.99999f);

            //Using randomValue pick one of 3 possible rotations or no wall.
            //If we are at x value 50 or -50 don't add a parallel wall to it.
            if (randomValue < 1f )
            {
                wallRotation = new Vector3(0, 0, 0);
                spawn = true;
            }
            else if (randomValue < 2f && transform.position.x < 50)
            {
                wallRotation = new Vector3(0, 90, 0);
                spawn = true;
            }
            else if (randomValue < 3f && transform.position.x < 50)
            {
                wallRotation = new Vector3(0, -90, 0);
                spawn = true;
            }
            else
            {
                spawn = false;
            }

            //If we need to spawn a wall, spawn it.
            if (spawn)
            {
                Transform temp = Instantiate(wall, transform.position, Quaternion.Euler(wallRotation)) as Transform;
                temp.transform.parent = mazeWalls;
            }

            transform.position -= new Vector3(10, 0, 0);

            if (transform.position.x <= -50)
            {
                transform.position += new Vector3(100f, 0, -10);
            }
        }
        Destroy(gameObject);
    }
}
