using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Observable {

    public Obstacle obstacle;
    public List<Direction> paths;

    public int absoluteRow;
    public int absoluteCol;

    private bool generated = false;

    public Tile(int seed, int absoluteRow, int absoluteCol, List<Direction> directions) : this(seed, directions, null) {
        this.absoluteRow = absoluteRow;
        this.absoluteCol = absoluteCol;
    }

    public Tile(int seed, List<Direction> directions, Obstacle obstacle) {
        this.paths = directions;
        this.obstacle = obstacle;
        Notify();
    }

    public void SetGenerated(bool generated) {
        this.generated = generated;
    }

    public bool HasBeenGenerated() {
        return generated;
    }

    public void SetPaths(List<Direction> paths) {
        this.paths = paths;
        Notify();
    }

    public bool HasPath(Direction direction) {
        return paths.Contains(direction);
    }

    public void SetObstacle(Obstacle obstacle) {
        this.obstacle = obstacle;
        Notify();
    }

    public void AddPath(Direction path) {
        if (!paths.Contains(path)) {
            paths.Add(path);
        }
    }

}
