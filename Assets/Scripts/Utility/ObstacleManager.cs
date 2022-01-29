using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleManager : Singleton<ObstacleManager> {

    private Dictionary<Obstacle3D, double> obstacles = new Dictionary<Obstacle3D, double>();
    public Dictionary<Control, Obstacle3D> tracked = new Dictionary<Control, Obstacle3D>();

    public void ProcessObstacle(Obstacle3D obstacle, double distance) {
        obstacles.Add(obstacle, distance);
        
        foreach (Control control in Enum.GetValues(typeof(Control)) {
            if (!tracked.ContainsKey(control)) {
                tracked.Add(control, obstacle);
                obstacle.Track(control);
                break;
            }
        }


        
            

    }

    public enum Control {

        A,
        B,
        X,
        Y

    }

}
