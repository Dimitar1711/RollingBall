using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x:15,y:30,z:45)*Time.deltaTime);
    }
}
