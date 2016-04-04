using UnityEngine;
using System.Collections;

public class WallPlacementScript : MonoBehaviour {

    [SerializeField]
    Transform wall;
    [SerializeField]
    Transform mazeWalls;

    Vector3[] wallRotations;
    bool spawn;
    int spawnNumber;

	// Use this for initialization
	void Start () {
        wallRotations = new Vector3[2];

        while (transform.position.z > -50)
        {
            float randomValue = Random.Range(0f, 4f);

            //Using randomValue pick one of 3 possible rotations or no wall.
            //If we are at x value 50 or -50 don't add a parallel wall to it.
            if (randomValue < 1f )
            {
                wallRotations[0] = new Vector3(0, 0, 0);
                spawn = true;
                spawnNumber = 1;
            }
            else if (randomValue < 2f && transform.position.x < 50)
            {
                wallRotations[0] = new Vector3(0, 90, 0);
                spawn = true;
                spawnNumber = 1;
                if(randomValue < 1.2f)
                {
                    wallRotations[1] = new Vector3(0, 0, 0);
                    spawnNumber = 2;
                }
            }
            else if (randomValue < 3f && transform.position.x < 50)
            {
                wallRotations[0] = new Vector3(0, -90, 0);
                spawn = true;
                spawnNumber = 1;
                if (randomValue < 2.2f)
                {
                    wallRotations[1] = new Vector3(0, 0, 0);
                    spawnNumber = 2;
                }
            }
            else
            {
                spawn = false;
            }

            //If we need to spawn a wall, spawn it.
            if (spawn)
            {
                for(int i = 0; i < spawnNumber; i++)
                {
                    Transform temp = Instantiate(wall, transform.position, Quaternion.Euler(wallRotations[i])) as Transform;
                    temp.transform.parent = mazeWalls;
                }
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
