using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
