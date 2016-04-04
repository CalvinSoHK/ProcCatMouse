using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{
    public Transform death;
    GameManagerScript GameManager;
    //AudioSource audio;
    //float audioTimer = 0;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GameManager.catList.Add(transform);
    }

    void OnDestroy()
    {
        GameManager.catList.Remove(transform);
    }

    void Update()
    {
        //audioTimer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform mouse in GameManager.mouseList)
        {
            Vector3 directionToMouse = mouse.position - transform.position;
            if (Vector3.Angle(transform.forward, directionToMouse) < 45f)
            {
                Ray catRay = new Ray(transform.position, directionToMouse);
                RaycastHit catRayHitInfo = new RaycastHit();
                Debug.DrawRay(transform.position, transform.forward * 100);
                if (Physics.Raycast(catRay, out catRayHitInfo, 100f))
                {
                    //Debug.Log(catRayHitInfo.collider.tag);
                    if (catRayHitInfo.collider.tag == "Mouse" && catRayHitInfo.distance < 70f)
                    {
                        /*
                        if (audioTimer > 2f)
                        {
                            audio.Play();
                        }*/
                        if (catRayHitInfo.distance < 8f)
                        {
                            Destroy(catRayHitInfo.collider.gameObject);
                            Instantiate(death, transform.position + transform.forward * 8, Quaternion.identity);
                        }
                        else
                        {
                            GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
                        }
                    }
                }
            }
        }
    }
}
