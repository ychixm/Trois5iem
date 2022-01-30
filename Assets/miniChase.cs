using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniChase : MonoBehaviour
{
    public Animation explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(0,0,1);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        
    }
}
