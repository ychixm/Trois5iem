using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Observable {

    public Obstacle obstacle;
    public List<Direction> paths;

    public int absoluteRow;
    public int absoluteCol;

    public Tile(int seed, Tile source, int vertical, int horizontal) : this(seed, new List<Direction>(), null) {
        this.absoluteRow = source.absoluteRow - vertical;
        this.absoluteCol = source.absoluteCol - horizontal;

        List<Direction> generatedPaths = 
    }

    public Tile(int seed, List<Direction> directions, Obstacle obstacle) {
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
