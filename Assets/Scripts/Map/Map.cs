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
                tiles[row][col] = new Tile();
            }
        }

        tiles[4][2].SetPaths(new List<Direction> { Direction.SOUTH, Direction.NORTH });
    }

    public void SetSeed(int seed) {
        this.seed = seed;
    }

}
