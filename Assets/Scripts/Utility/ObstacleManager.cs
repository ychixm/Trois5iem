using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : Singleton<ObstacleManager> {

    private Dictionary<Obstacle3D, double> obstacles = new Dictionary<Obstacle3D, double>();

    public Obstacle3D obstacleA;
    public Obstacle3D obstacleB;
    public Obstacle3D obstacleX;
    public Obstacle3D obstacleY;

    public void ProcessObstacle(Obstacle3D obstacle, double distance) {
        obstacles.Add(obstacle, distance);
        
        if (obstacleA == null) {
            obstacleA = obstacle;
        } else if (obstacleB == null) {
            obstacleB = obstacle;
        } else if (obstacleX == null) {
            obstacleX = obstacle;
        } else if (obstacleY == null) {
            obstacleY = obstacle;
        }

        IEnumerable<KeyValuePair<Obstacle3D, double>> closestObstacles = obstacles.OrderBy(pair => obstacles[pair.Key]).Take(4);


    }

}
