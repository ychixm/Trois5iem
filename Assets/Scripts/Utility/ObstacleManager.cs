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
        
        foreach (Control control in Enum.GetValues(typeof(Control))) {
            if (!tracked.ContainsKey(control)) {
                tracked.Add(control, obstacle);
                obstacle.Track(control);
                return;
            }
        }

        IEnumerable<KeyValuePair<Obstacle3D, double>> closestObstacles = obstacles.OrderBy(pair => obstacles[pair.Key]).Take(4).Reverse();
        foreach (KeyValuePair<Obstacle3D, double> pair in closestObstacles) {
            if (pair.Value * 1.1 > distance) {
                pair.Key.Untrack();
                Control control = tracked.Where(p => p.Value == pair.Key).First().Key;
                tracked.Add(control, obstacle);
                obstacle.Track(control);
            }
        }
    }

    public void OnAction(Control control) {
        if (tracked.ContainsKey(control)) {
            tracked[control].OnAction();
        }
    }

    public enum Control {

        A,
        B,
        X,
        Y

    }

}
