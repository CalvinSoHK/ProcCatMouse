using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed + Physics.gravity;
        //Debug.Log(GetComponent<Rigidbody>().velocity);

        //Debug.DrawRay(transform.position, transform.forward * 5);
        Ray moveRay = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(moveRay, 3f, 3.5f))
        {
            //Debug.Log("Turn");
            float randNum = Random.value;
            if (randNum < 0.5f)
            {
                transform.Rotate(0, 90, 0);
            }
            else
            {
                transform.Rotate(0, -90, 0);
            }
        }
    }
}