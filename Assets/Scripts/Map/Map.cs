using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private int seed = -1;

    public int size = 5;

    public Tile[][] tiles;

    public void Start() {
        Initialize();
        Scroll(Direction.NORTH);
        Scroll(Direction.NORTH);
        Scroll(Direction.NORTH);
        Scroll(Direction.NORTH);
        Scroll(Direction.NORTH);
    }

    public void Initialize() {
        if (seed == -1) {
            SetSeed(new System.Random().Next());
        }

        for (int row = 0 ; row < size; row++) {
            tiles[row] = new Tile[size];
            for (int col = 0 ; col < size; col++) {
                tiles[row][col] = new Tile(seed, int.MaxValue/2 + row, int.MaxValue/2 + col, new List<Direction>());
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

        Tile[] toBeGenerated = new Tile[size];

        Tile[][] temp = tiles;
        for (int row = 0 ; row < tiles.Length ; row++) {
            for (int col = 0 ; col < tiles[row].Length ; col++) {
                if (IsValid(row - vertical, col - horizontal)) {
                    tiles[row][col] = temp[row - vertical][col - horizontal];
                } else {
                    tiles[row][col] = new Tile(seed, tiles[row][col].absoluteRow, tiles[row][col].absoluteCol, tiles[row][col].HasPath(direction) ? new List<Direction> { direction } : new List<Direction>());
                    toBeGenerated[vertical != 0 ? (vertical == 1 ? row : size - 1 - row) : (horizontal == 1 ? col : size - 1 - col)] = tiles[row][col];
                }
            }
        }

        if (vertical == 1) {
            for (int i = 0 ; i < size / 2 ; i++) {
                if (i == 0) {
                    if (new System.Random().NextDouble() < 0.4f && !toBeGenerated[(size / 2) - 1].HasPath(Direction.SOUTH)) {
                        toBeGenerated[size / 2].AddPath(Direction.WEST);
                        toBeGenerated[(size / 2) - 1].AddPath(Direction.EAST);
                    }
                    if (new System.Random().NextDouble() < 0.4f && !toBeGenerated[(size / 2) + 1].HasPath(Direction.SOUTH)) {
                        toBeGenerated[size / 2].AddPath(Direction.EAST);
                        toBeGenerated[(size / 2) - 1].AddPath(Direction.WEST);
                    }
                    if ((!toBeGenerated[size / 2].HasPath(Direction.WEST) && !toBeGenerated[size / 2].HasPath(Direction.EAST)) || new System.Random().NextDouble() < 0.4f) {
                        toBeGenerated[size / 2].AddPath(Direction.NORTH);
                    }
                } else {
                    double rand = new System.Random().NextDouble();
                    if (toBeGenerated[(size / 2) + i].HasPath(Direction.SOUTH) || toBeGenerated[(size / 2) + i].HasPath(Direction.WEST)) {
                        if (((size / 2) + i + 1) >= size || !toBeGenerated[(size / 2) + i + 1].HasPath(Direction.SOUTH)) {
                            if (rand < 0.6f) {
                                toBeGenerated[(size / 2) + i].AddPath(Direction.EAST);
                                if (((size / 2) + i + 1) < size) {
                                    toBeGenerated[(size / 2) + i].AddPath(Direction.WEST);
                                }
                            }
                        }
                        if (rand > 0.4f || !toBeGenerated[(size / 2) + i].HasPath(Direction.EAST)) {
                            toBeGenerated[(size / 2) + i].AddPath(Direction.NORTH);
                        }
                    }

                    double rand2 = new System.Random().NextDouble();
                    if (toBeGenerated[(size / 2) - i].HasPath(Direction.SOUTH) || toBeGenerated[(size / 2) - i].HasPath(Direction.EAST)) {
                        if (((size / 2) - i - 1) >= size || !toBeGenerated[(size / 2) - i - 1].HasPath(Direction.SOUTH)) {
                            if (rand < 0.6f) {
                                toBeGenerated[(size / 2) - i].AddPath(Direction.WEST);
                                if (((size / 2) - i - 1) < size) {
                                    toBeGenerated[(size / 2) - i].AddPath(Direction.EAST);
                                }
                            }
                        }
                        if (rand > 0.4f || !toBeGenerated[(size / 2) - i].HasPath(Direction.WEST)) {
                            toBeGenerated[(size / 2) - i].AddPath(Direction.NORTH);
                        }
                    }
                }
            }
        } else if (horizontal == 1) {
            for (int i = size; i >= 0; i--) {
                if (toBeGenerated[i].HasPath(Direction.SOUTH) || toBeGenerated[i].HasPath(Direction.WEST)) {
                    double rand = new System.Random().NextDouble();
                    if (rand > 0.4f) {
                        toBeGenerated[i].AddPath(Direction.NORTH);
                        if (i != 0) {
                            toBeGenerated[i - 1].AddPath(Direction.SOUTH);
                        }
                    } 
                    if (rand < 0.6f) {
                        toBeGenerated[i].AddPath(Direction.EAST);
                    }
                }
            }
        } else if (horizontal == -1) {
            for (int i = 0 ; i < size ; i++) {
                if (toBeGenerated[i].HasPath(Direction.SOUTH) || toBeGenerated[i].HasPath(Direction.EAST)) {
                    double rand = new System.Random().NextDouble();
                    if (rand > 0.4f) {
                        toBeGenerated[i].AddPath(Direction.NORTH);
                        if (i != (size - 1)) {
                            toBeGenerated[i + 1].AddPath(Direction.SOUTH);
                        }
                    } 
                    if (rand < 0.6f) {
                        toBeGenerated[i].AddPath(Direction.WEST);
                    }
                }
            }
        }

        String debug = "";
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                int flag = (tiles[i][j].HasPath(Direction.NORTH) ? 1 : 0) + (tiles[i][j].HasPath(Direction.NORTH) ? 2 : 0) + (tiles[i][j].HasPath(Direction.NORTH) ? 4 : 0) + (tiles[i][j].HasPath(Direction.NORTH) ? 8 : 0);
                debug = " - " + flag;
            }
            debug = debug + "\n";
        }
        Debug.Log(debug);
    }

    public void SetSeed(int seed) {
        this.seed = seed;
    }

    public bool IsValid(int row, int col) {
        return (row >= 0 && row < size && col >= 0 && col < size);
    }

}
