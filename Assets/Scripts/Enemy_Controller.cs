using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 1;
    public int SpeedLim = 30;
    private Rigidbody rb;
    public GameObject GameOver;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(x: Random.Range(5, 10), y: 0, z: Random.Range(5, 10));
        rb.AddForce(movement * speed);
        GameOver.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(x:0, y: 0, z:0);
        rb.AddForce(movement * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, SpeedLim);
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("wall"))
        {
            rb = GetComponent<Rigidbody>();
            if (SpeedLim < rb.velocity.magnitude)
            {
                Vector3 movement = rb.velocity.normalized;

                rb.velocity = rb.velocity;
                //rb.AddForce(movement * speed);
            }
            else
            {

            }
            
            /*
            Vector3 t = rb.velocity;
            Debug.Log(t);
            t = t * -150;
            rb.AddForce(t,ForceMode.Impulse);
            */

        }
        /*if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.SetActive(false);
            GameOver.SetActive(true);
            
        }*/
    }

}
