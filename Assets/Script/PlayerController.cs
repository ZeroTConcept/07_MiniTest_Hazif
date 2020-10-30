using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float planeAabsLimits = 10.0f;
    float planeBabsLimits = 5.0f;

    float relzLimit;
    float relxLimit;

    int planeIndicator = 0;

    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Inputvertical = Input.GetAxis("Vertical");
        float Inputhorizontal = Input.GetAxis("Horizontal");


        if (planeIndicator == 0)
        {
            relzLimit = planeAabsLimits;
            relxLimit = planeAabsLimits;

            if (transform.position.z > relzLimit)
            {
                if (transform.position.x > -relxLimit / 2 && transform.position.x < relxLimit / 2)
                {
                    transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
                }
            }
            else if (transform.position.z < -relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
            }

            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Inputhorizontal * speed * Time.deltaTime);
            }
        }
        else
        {
            relzLimit = planeAabsLimits + 2 * planeBabsLimits;
            relxLimit = planeBabsLimits;

            if (transform.position.z < planeAabsLimits)
            {
                if (transform.position.x > -planeAabsLimits / 2 && transform.position.x < planeAabsLimits / 2)
                {
                    transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, planeAabsLimits);
                }
            }
            else if (transform.position.z > relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * Inputvertical * speed * Time.deltaTime);
            }
            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Inputhorizontal * speed * Time.deltaTime);
            }
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("In Plane A");
            planeIndicator = 0;
        }
        if (collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("In Plane B");
            planeIndicator = 1;
        }
    }
}
