using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class policeEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter(Collider info)
    {
        if(info.name == "P_PoliceCar")
        {
            Debug.Log("Coucou");
        }
    }
}
