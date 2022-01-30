using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PrefabManager;

public abstract class Obstacle : Observable {

    public ObstacleType type;
    public Direction orientation = Direction.NORTH;

    public Obstacle(Direction orientation) {
        this.orientation = orientation;
    }

    public abstract void ExecuteAction();

}
