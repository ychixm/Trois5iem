using UnityEngine;

public class Bollards3D : Actionnable3D {

    private Bollards bollards;

    private void Start() {
        transform.position = new Vector3(transform.position.x, bollards.activated ? 0.5f : 0.0f, transform.position.z);
    }

    private void Update() {
        if (bollards.activated && transform.position.y < 0.5f) {
            transform.Translate(Vector3.up * Time.deltaTime * 2f);
        } else if (transform.position.y > 0f) {
            transform.Translate(Vector3.down * Time.deltaTime * 2f);
        }
    }

    public override void Initialize(Obstacle obstacle) {
        this.bollards = (Bollards) obstacle;
    }

    public override void OnAction() {
        bollards.ExecuteAction();
    }

}