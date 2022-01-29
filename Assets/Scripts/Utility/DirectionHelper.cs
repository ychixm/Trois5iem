using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHelper {

    public static Direction GetOppositeDirection(Direction direction) {
        switch (direction)
        {
            case Direction.NORTH:
                return Direction.SOUTH;
            case Direction.WEST:
                return Direction.EAST;
            case Direction.SOUTH:
                return Direction.NORTH;
            case Direction.EAST:
                return Direction.WEST;
        }
    }

    public static Direction GetLeftTurnDirection(Direction direction) {
        return Direction.NORTH;
    }

    public static Direction GetRightTurnDirection(Direction direction) {
        return Direction.NORTH;
    }

}
