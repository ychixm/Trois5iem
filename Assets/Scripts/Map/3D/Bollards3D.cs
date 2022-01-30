using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bollards3D : Obstacle3D {

    private bool _isLifted;

    private void Start()
    {
        _isLifted = new Bollards(Direction.NORTH).activated;
    }

    private void Update()
    {
        if (_isLifted)
        {
            if (transform.position.y < 0.5f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 2f);
            }
        }
        else
        {
            if (transform.position.y > 0f)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 2f);    
            }
        }
    }

}