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
                    tiles[row, col] = new Tile(seed, tiles[row + vertical, col + horizontal].HasPath(direction) ? new List<Direction> { DirectionHelper.GetOppositeDirection(direction) } : new List<Direction>(), null);
                    Debug.Log(String.Join(" || ", tiles[row, col].GetPaths().Select(dir => dir.ToString())));
                }
            }
        }       

        if (direction == Direction.EAST || direction == Direction.WEST) {
            int col = direction == Direction.EAST ? size - 1 : 0;
            for (int row = size; row >= 0; row--) {
                if (tiles[row, col].HasPath(direction) || tiles[row, col].HasPath(Direction.NORTH)) {
                    if (row > 0 && !tiles[row - 1, col].HasPath(DirectionHelper.GetOppositeDirection(direction))) {
                        float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (rand < 0.7f) {
                            tiles[row, col].AddPath(direction);
                        }
                        if (rand > 0.3f) {
                            tiles[row, col].AddPath(Direction.NORTH);
                            tiles[row - 1, col].AddPath(Direction.SOUTH);
                        }
                    } else {
                        tiles[row, col].AddPath(direction);
                    }
                }
            }
        } else if (direction == Direction.NORTH) {
            for (int diff = 0; diff <= (size - 1) / 2; diff++) {
                if (diff == 0) {
                    if (tiles[0, (size - 1) / 2].HasPath(Direction.SOUTH)) {
                        float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (rand < 0.7f) {
                            tiles[0, (size - 1) / 2].AddPath(direction);
                        }
                        if (rand > 0.3f) {
                            rand = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (rand < 0.7f && !tiles[0, ((size - 1) / 2) + 1].HasPath(Direction.SOUTH)) {
                                tiles[0, (size - 1) / 2].AddPath(Direction.EAST);
                                tiles[0, ((size - 1) / 2) + 1].AddPath(Direction.WEST);
                            } else if (rand > 0.3f && !tiles[0, ((size - 1) / 2) - 1].HasPath(Direction.SOUTH)) {
                                tiles[0, (size - 1) / 2].AddPath(Direction.WEST);
                                tiles[0, ((size - 1) / 2) - 1].AddPath(Direction.EAST);
                            } else {
                                tiles[0, 0].AddPath(Direction.NORTH);
                            }
                        }
                    }
                } else {
                    if (tiles[0, ((size - 1) / 2) + diff].HasPath(Direction.SOUTH) || tiles[0, ((size - 1) / 2) + diff].HasPath(Direction.WEST)) {
                        if (diff >= (size - 1) / 2 || !tiles[0, ((size - 1) / 2) + diff + 1].HasPath(Direction.SOUTH)) {
                            float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (rand > 0.3f) {
                                tiles[0, ((size - 1) / 2) + diff].AddPath(Direction.EAST);
                                if (diff < (size - 1) / 2) {
                                    tiles[0, ((size - 1) / 2) + diff + 1].AddPath(Direction.WEST);
                                }
                            }
                            if (rand < 0.7f) {
                                tiles[0, ((size - 1) / 2) + diff].AddPath(Direction.NORTH);
                            }
                        } else {
                            tiles[0, ((size - 1) / 2) + diff].AddPath(Direction.NORTH);
                        }
                    }
                    if (tiles[0, ((size - 1) / 2) - diff].HasPath(Direction.SOUTH) || tiles[0, ((size - 1) / 2) - diff].HasPath(Direction.EAST)) {
                        if (diff >= (size - 1) / 2 || !tiles[0, ((size - 1) / 2) - diff - 1].HasPath(Direction.SOUTH)) {
                            float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (rand > 0.3f) {
                                tiles[0, ((size - 1) / 2) - diff].AddPath(Direction.WEST);
                                if (diff < (size - 1) / 2) {
                                    tiles[0, ((size - 1) / 2) - diff - 1].AddPath(Direction.EAST);
                                }
                            }
                            if (rand < 0.7f) {
                                tiles[0, ((size - 1) / 2) - diff].AddPath(Direction.NORTH);
                            }
                        } else {
                            tiles[0, ((size - 1) / 2) - diff].AddPath(Direction.NORTH);
                        }
                    }
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
