using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {

    private int seed = -1;

    public int horizontalSize = 5;
    public int verticalSize = 5;

    public Tile[][] tiles;
    
    public void Initialize() {
        if (seed == -1) {
            SetSeed(new System.Random().Next());
        }

        for (int row = 0 ; row < verticalSize ; row++) {
            tiles[row] = new Tile[horizontalSize];
            for (int col = 0 ; col < horizontalSize ; col++) {
                tiles[row][col] = new Tile(seed, int.MaxValue/2 + row, int.MaxValue/2 + col);
            }
        }

        /* First 5 tiles on the center column are linear roads. */

        tiles[4][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });
        tiles[3][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });
        tiles[2][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });
        tiles[1][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });
        tiles[0][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });

    }

    public void Scroll(Direction direction) {
        int directionOrdinal = (int) direction;

        /* (NORTH [0] => 1 | EAST [1] => 0 | SOUTH [2] => -1 | WEST [3] => 0) */
        int vertical = directionOrdinal % 2 == 1 ? 0 : ((directionOrdinal * -1) + 1);

        /* (NORTH [0] => 0 | EAST [1] => 1 | SOUTH [2] => 0 | WEST [3] => -1) */
        int horizontal = directionOrdinal % 2 == 0 ? 0 : ((directionOrdinal * -1) + 2);

        Tile[][] temp = tiles;
        for (int row = 0 ; row < tiles.Length ; row++) {
            for (int col = 0 ; col < tiles[row].Length ; col++) {
                if (IsValid(row - vertical, col - horizontal)) {
                    tiles[row][col] = temp[row - vertical][col - horizontal];
                } else {
                    tiles[row][col] = new Tile(seed, tiles[row][col], vertical, horizontal);
                }
            }
        }
    }

    public void SetSeed(int seed) {
        this.seed = seed;
    }

    public bool IsValid(int row, int col) {
        return (row >= 0 && row < verticalSize && col >= 0 && col < horizontalSize);
    }

}
