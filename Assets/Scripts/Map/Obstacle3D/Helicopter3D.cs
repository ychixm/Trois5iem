using Controller;
using UnityEngine;

public class Helicopter3D : Obstacle3D
{
    #region Properties

    public Vector3 cameraTransform = new Vector3(0,15,0);
    public float malusValue;
    public bool isSlowingRunner;
    public bool isLightOn;
    
    private SphereCollider _sphereCollider;
    private Collider _runner;
    private float _defaultMoveSpeed;
    
    #endregion
    
    void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (isSlowingRunner)
        {
            _runner.gameObject.GetComponent<Runner>().moveSpeed = malusValue;
        }

        if (isLightOn)
        {
            if(transform.position.y >= cameraTransform.y)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.up * Time.deltaTime * 2f);
        }
        else
        {
            if (transform.position.y > 5)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 2f);
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && transform.position.y <= 5)
        {
            isLightOn = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            _defaultMoveSpeed = other.gameObject.GetComponent<Runner>().moveSpeed;
            isSlowingRunner = true;
            _runner = other;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            isSlowingRunner = false;
            _runner.gameObject.GetComponent<Runner>().moveSpeed = _defaultMoveSpeed;
            _runner = null;
        }
    }
}
