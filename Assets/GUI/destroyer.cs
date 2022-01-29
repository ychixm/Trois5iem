using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject spherePrefab;
    public int but;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,-5);
        but = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -50)
        {
            Destroy(this.gameObject);
        }   
    }
}
