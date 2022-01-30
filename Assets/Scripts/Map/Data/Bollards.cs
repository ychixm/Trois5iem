using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bollards : Obstacle {

    public bool activated;

    public Bollards(Direction orientation) : base(orientation) {
        activated = UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f;
    }

    public override void ExecuteAction() {
        activated = !activated;
        Notify();
    }

}
