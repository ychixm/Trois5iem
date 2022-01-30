using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObstacleManager;

public abstract class Obstacle3D : MonoBehaviour, Observer {

    public Obstacle obstacle;
    public Vector3 dist, newPos;
    public GameObject car;
    public GameObject but;

    public void SetObstacle(Obstacle obstacle) {
        if (this.obstacle != null) {
            this.obstacle.Unregister(this);
        }

        this.obstacle = obstacle;

        if (this.obstacle != null) {
            this.obstacle.Register(this);
        }

        OnNotify();
    }

    public virtual void Track(Control control) {
        dist = new Vector3(this.transform.position.x - car.transform.position.x, 0, this.transform.position.z - car.transform.position.z);
        newPos = new Vector3(dist.x + this.transform.position.x, car.transform.position.y + 5, dist.z + this.transform.position.z);
        Vector3 offset = newPos - this.transform.position;
        but.transform.position = this.transform.position + Vector3.ClampMagnitude(offset, 2).normalized;
        but.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    public virtual void Untrack() {
        /* 
         
        Remove any visual tracking clues like colors, pings, displayed buttons ...

         */
    }

    public void Update() {

        Track(Control.A);

        /* 
         
        1) Get the player reference;
        2) Get the distance between player and obstacle;
        3) Ping the Obstacle Manager using "ObstacleManager.Instance.ProcessObstacle(this, distance)"

         */
    }

    public virtual void OnNotify() {
        this.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
        this.transform.Rotate(0f, ((int)obstacle.orientation) * 90.0f, 0f);
    }

}
