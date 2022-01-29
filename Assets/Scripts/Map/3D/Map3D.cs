using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3D : MonoBehaviour, Observer {

    [Header("Prefab")]
    public GameObject tile3DPrefab;

    [Header("Map properties")]
    public int size = 7;
    public Map map;
    public Tile3D[][] tiles3D;

    public void Awake() {
        map = new Map(size);
        map.Register(this);

        tiles3D = new Tile3D[size][];
        for (int i = 0; i < size; i++) {
            tiles3D[i] = new Tile3D[size];
            for (int j = 0; j < size; j++) {
                GameObject newTile3D = Instantiate(tile3DPrefab);
                newTile3D.transform.SetPositionAndRotation(new Vector3(i * 10, 0, j * 10), Quaternion.identity);

                tiles3D[i][j] = newTile3D.GetComponent<Tile3D>();
                tiles3D[i][j].row = i;
                tiles3D[i][j].col = j;
                tiles3D[i][j].SetTile(map.GetTile(i, j));
            }
        }

        StartCoroutine(testScroll());
    }

    public IEnumerator testScroll() {
        while (true) {
            yield return new WaitForSeconds(1f);
            map.Scroll(Direction.NORTH);
            string debug = "";
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    debug = debug + " | " + tiles3D[i][j].GetTile().id;
                }
                debug = debug + "\n";
            }
            Debug.Log(debug);
        }
    }

    public void OnNotify() {
        for (int i = 0; i < tiles3D.Length; i++) {
            for (int j = 0; j < tiles3D[i].Length; j++) {
                tiles3D[i][j].SetTile(map.GetTile(i, j));
            }
        }
    }

}
