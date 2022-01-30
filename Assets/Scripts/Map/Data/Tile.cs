using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Observable {

    public int id = Mathf.CeilToInt(UnityEngine.Random.Range(1000000.0f, 10000000.0f));

    public Obstacle obstacle;
    public List<Direction> paths;

    public Tile(int seed, List<Direction> directions, Obstacle obstacle) {
        this.paths = directions;
        this.obstacle = obstacle;
        Notify();
    }

    public void SetPaths(List<Direction> paths) {
        this.paths = paths;
        Notify();
    }

    public void AddPath(Direction path) {
        if (!paths.Contains(path)) {
            paths.Add(path);
            Notify();
        }
    }

    public void RemovePath(Direction path) {
        if (paths.Contains(path)) {
            paths.Remove(path);
        }
    }

    public List<Direction> GetPaths() {
        return paths;
    }

    public bool HasPath(Direction direction) {
        return paths.Contains(direction);
    }

    public void SetObstacle(Obstacle obstacle) {
        this.obstacle = obstacle;
        Notify();
    }

    public int GetPathFlag() {
        int flag = 0;

        if (paths.Contains(Direction.NORTH)) {
            flag += 1;
        }
        if (paths.Contains(Direction.EAST)) {
            flag += 2;
        }
        if (paths.Contains(Direction.SOUTH)) {
            flag += 4;
        }
        if (paths.Contains(Direction.WEST)) {
            flag += 8;
        }

        return flag;
    }

}
