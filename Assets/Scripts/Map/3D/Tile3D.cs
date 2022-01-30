using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile3D : MonoBehaviour, Observer {

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public Obstacle3D obstacle;
    public Map3D map3D;
    private Tile tile;

    public int row;
    public int col;

    public void SetTile(Tile tile) {
        if (this.tile != null) {
            this.tile.Unregister(this);
        }

        this.tile = tile;

        if (this.tile != null) {
            this.tile.Register(this);
        }

        OnNotify();

        obstacle.SetObstacle(this.tile.obstacle);
    }

    public Tile GetTile() {
        return tile;
    }

    public void OnNotify() {
        GameObject prefab = PrefabManager.Instance.GetRoad(tile.GetPathFlag());
        meshFilter.mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.material = prefab.GetComponent<MeshRenderer>().sharedMaterial;

        int flag = tile.GetPathFlag();
        transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        if (flag == 11 || flag == 5 || flag == 3) {
            transform.Rotate(0, 90, 0);
        } else if (flag == 7 || flag == 6) {
            transform.Rotate(0, 180, 0);
        } else if (flag == 14 || flag == 12) {
            transform.Rotate(0, 270, 0);
        }
    }

}

[CustomEditor(typeof(Tile3D))]
public class Tile3DEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Tile3D tile = (Tile3D) target;
        if (GUILayout.Button("Debug current state")) {
            Debug.Log("Current Path Flag : " + tile.GetTile().GetPathFlag() + " | Paths : " + String.Join(" & ", tile.GetTile().GetPaths().Select(direction => direction.ToString())));
        }
    }
}
