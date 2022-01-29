using UnityEngine;
using Random = UnityEngine.Random;

public class Bitts3D : MonoBehaviour
{
    private bool _isLifted;

    private void Start()
    {
        int value = Random.Range(0, 2);
        
        if (value == 0)
        {
            _isLifted = false;
        }
        else
        {
            _isLifted = true;
        }
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
