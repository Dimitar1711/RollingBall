using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_spawner : MonoBehaviour
{
    public int wait = 1;
    private float elapcedtime = 0;
    public Rigidbody rb;
    public bool startcount = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startcount)
        {
            elapcedtime = elapcedtime + Time.deltaTime;
            if (elapcedtime >= wait)
            {
                if (rb.isKinematic)
                {
                    rb.isKinematic = false;
                }
            }
        }
        
    }   
}
