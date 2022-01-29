using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObstacleManager;

public class Obstacle3D : MonoBehaviour {
    public GameObject car;
    public GameObject but;
    public Vector3 dist , newPos;
    public Control A;
    public virtual void Track(Control control) {
        dist = new Vector3(this.transform.position.x - car.transform.position.x, 0, this.transform.position.z - car.transform.position.z);
        newPos = new Vector3(dist.x + this.transform.position.x, car.transform.position.y+5, dist.z + this.transform.position.z);
        Vector3 offset = newPos - this.transform.position;
        but.transform.position = this.transform.position + Vector3.ClampMagnitude(offset,2).normalized;
        but.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    public virtual void Untrack() {
        /* 
         
        Remove any visual tracking clues like colors, pings, displayed buttons ...

         */
    }

    public void Start()
    {
    }
    public void Update()
    {
        Track(A);
    }

}
