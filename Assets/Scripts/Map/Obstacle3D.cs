using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObstacleManager;

public abstract class Obstacle3D : MonoBehaviour, Observer {

    public Obstacle obstacle;

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
        /* 
         
         */
    }

    public virtual void Untrack() {
        /* 
         
        Remove any visual tracking clues like colors, pings, displayed buttons ...

         */
    }

    public void Update() {
        /* 
         
        1) Get the player reference;
        2) Get the distance between player and obstacle;
        3) Ping the Obstacle Manager using "ObstacleManager.Instance.ProcessObstacle(this, distance)"

         */
    }

    public abstract void OnNotify();

}
