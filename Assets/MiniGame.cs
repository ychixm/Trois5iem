using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0,-2f*Time.deltaTime);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
       if(collisionInfo.collider.name == "P_Car_Other_04")
       {
           Debug.Log("Loose");
       }
    }
}
