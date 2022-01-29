using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : Singleton<PrefabManager> {

    public GameObject emptyRoad;
    public GameObject straightRoad;
    public GameObject angleRoad;
    public GameObject threewayRoad;
    public GameObject crossRoad;

    public GameObject GetRoad(int flag) {
        if (flag == 5 || flag == 10) {
            return straightRoad;
        } else if (flag == 9 || flag == 3 || flag == 6 || flag == 12) {
            return angleRoad;
        } else if (flag == 7 || flag == 14 || flag == 13 || flag == 11) {
            return threewayRoad;
        } else if (flag == 15) {
            return crossRoad;
        } else {
            return emptyRoad;
        }
    }

}
