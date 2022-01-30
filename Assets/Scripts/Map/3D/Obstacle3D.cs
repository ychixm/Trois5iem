using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ObstacleManager;

public class Obstacle3D : MonoBehaviour, Observer {

    public Obstacle obstacle;
    public GameObject obstacleObject;

    public Vector3 dist, newPos;
    public GameObject but;

    public void SetObstacle(Obstacle obstacle) {
        if (this.obstacle != null) {
            this.obstacle.Unregister(this);
            Destroy(obstacleObject);
        }

        this.obstacle = obstacle;

        if (this.obstacle != null) {
            this.obstacle.Register(this);
            GameObject prefabObstacle = PrefabManager.Instance.GetObstacle(this.obstacle.type);
            obstacleObject = Instantiate(prefabObstacle, this.transform, false);
        }

        OnNotify();
    }

    public virtual void Track(Control control) {
        GameObject car = GameObject.FindWithTag("Car");
        dist = new Vector3(this.transform.position.x - car.transform.position.x, 0, this.transform.position.z - car.transform.position.z);
        newPos = new Vector3(dist.x + this.transform.position.x, car.transform.position.y + 5, dist.z + this.transform.position.z);
        Vector3 offset = newPos - this.transform.position;
        but.transform.position = this.transform.position + Vector3.ClampMagnitude(offset, 2).normalized;
        but.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    public virtual void Untrack() {
        /* 
         
        Remove any visual tracking clues like colors, pings, displayed buttons ...

         */
    }

    public void Update() {
        /* 
         
        1) Get the player reference;
        2) Get the distance between player and obstacle;
        3) Ping the Obstacle Manager using "ObstacleManager.Instance.ProcessObstacle(this, distance)"

         */
    }

    public void OnNotify() {
        if (obstacle != null) {
            obstacleObject.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
            obstacleObject.transform.Rotate(0f, ((int) obstacle.orientation) * 90.0f, 0f);
        }
    }

    [CustomEditor(typeof(Obstacle3D))]
    public class Obstacle3DEditor : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            Obstacle3D obs = (Obstacle3D) target;
            if (GUILayout.Button("Debug Direction")) {
                Debug.Log("Obstacle orientation : " + obs.obstacle.orientation.ToString() + " | Rotation = " + obs.transform.rotation);
            }
        }
    }

}
