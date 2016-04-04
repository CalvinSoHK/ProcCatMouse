using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [HideInInspector] public List<Transform> Cats; 
    [HideInInspector] public List<Transform> Mice;

    [SerializeField] Transform cat;
    [SerializeField] Transform mouse;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseRayHit = new RaycastHit();

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mouseRay, out mouseRayHit, 1000f))
            {
                if(mouseRayHit.collider.tag == "Floor")
                {
                    Transform temp = Instantiate(cat, mouseRayHit.point, Quaternion.identity) as Transform;
                    Cats.Add(temp);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(mouseRay, out mouseRayHit, 1000f))
            {
                if (mouseRayHit.collider.tag == "Floor")
                {
                    Transform temp = Instantiate(mouse, mouseRayHit.point, Quaternion.identity) as Transform;
                    Mice.Add(temp);
                }
            }
        }
    }
}
