using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : Observable {

    private int seed = -1;
    private int size;
    private Tile[,] tiles;

    public Map(int size) {
        this.size = size;
        Initialize();
    }

    public void Initialize() {
        tiles = new Tile[size,size];
        for (int row = 0 ; row < size; row++) {
            for (int col = 0 ; col < size; col++) {
                tiles[row,col] = new Tile(seed, new List<Direction>(), null);
            }
        }

        /* First 5 tiles on the center column are linear roads. */

        tiles[6, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[5, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[4, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[3, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[2, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[1, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });
        tiles[0, 3].SetPaths(new List<Direction> { Direction.NORTH, Direction.SOUTH });

    }

    public Tile GetTile(int row, int col) {
        return tiles[row,col];
    }

    public void Scroll(Direction direction) {

        int directionOrdinal = (int) direction;

        /* (NORTH [0] => 1 | EAST [1] => 0 | SOUTH [2] => -1 | WEST [3] => 0) */
        int vertical = directionOrdinal % 2 == 1 ? 0 : ((directionOrdinal * -1) + 1);

        /* (NORTH [0] => 0 | EAST [1] => 1 | SOUTH [2] => 0 | WEST [3] => -1) */
        int horizontal = directionOrdinal % 2 == 0 ? 0 : ((directionOrdinal * -1) + 2);

        Tile[,] temp = new Tile[size, size];
        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                if (IsValid(row + vertical, col + horizontal)) {
                    temp[row + vertical, col + horizontal] = tiles[row, col];
                }
            }
        }
        tiles = temp;

        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                if (tiles[row, col] == null) {
                    tiles[row, col] = new Tile(seed, new List<Direction>(), null);
                }
            }
        }

        if (direction == Direction.NORTH) {

            for (int col = 0; col < size; col++) {
                if (tiles[1, col].HasPath(Direction.NORTH)) {
                    tiles[0, col].AddPath(Direction.SOUTH);
                }

                float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                if (rand > 0.2f && rand < 0.6f && col != 0) {
                    tiles[0, col].AddPath(Direction.WEST);
                    tiles[0, col - 1].AddPath(Direction.EAST);
                } else {
                    tiles[0, col].AddPath(Direction.NORTH);
                }
                if (rand < 0.8f && rand > 0.4f && col != (size - 1)) {
                    tiles[0, col].AddPath(Direction.EAST);
                    tiles[0, col + 1].AddPath(Direction.WEST);
                } else {
                    tiles[0, col].AddPath(Direction.NORTH);
                }
            }

            for (int col = 0; col < size; col++) {
                if (tiles[0, col].paths.Count == 1) {
                    if (IsValid(0, col - 1)) {
                        tiles[0, col - 1].RemovePath(Direction.EAST);
                    }
                    if (IsValid(0, col + 1)) {
                        tiles[0, col + 1].RemovePath(Direction.WEST);
                    }
                    if (IsValid(1, col)) {
                        tiles[1, col].RemovePath(Direction.NORTH);
                    }
                    tiles[0, col].SetPaths(new List<Direction>());
                }
            }

            for (int col = 0; col < size; col++) {
                float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                if (tiles[0, col].HasPath(Direction.NORTH) && rand > 0.5f) {
                    tiles[0, col].SetObstacle(new Bollards(Direction.NORTH));
                }
            }
            
        }
        
        Notify();
    }

    public void SetSeed(int seed) {
        this.seed = seed;
    }

    public bool IsValid(int row, int col) {
        return (row >= 0 && row < size && col >= 0 && col < size);
    }

}
