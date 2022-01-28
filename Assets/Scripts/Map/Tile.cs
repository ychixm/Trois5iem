using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Observable {

    public Obstacle obstacle;
    public List<Direction> paths;

    public Tile() : this(new List<Direction>(), null) {

    }

    public Tile(List<Direction> directions, Obstacle obstacle) {
        this.paths = directions;
        this.obstacle = obstacle;
        Notify();
    }

    public void SetPaths(List<Direction> paths) {
        this.paths = paths;
        Notify();
    }

    public void SetObstacle(Obstacle obstacle) {
        this.obstacle = obstacle;
        Notify();
    }

}
