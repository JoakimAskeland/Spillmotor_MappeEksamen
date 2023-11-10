using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _speed = 1f;
    [SerializeField] private Rigidbody _rb;

    public static float _depth;

    // Update is called once per frame
    void Update()
    {
        // Use these controls when Camera1 is active
        if (CameraControl.activeCameraNr == 1)
        {
            var direction1 = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            _rb.velocity = direction1 * _speed;
        }
        else // Use these controls for the other Cameras
        {
            var direction2 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _rb.velocity = direction2 * _speed; 
        }
        
        // Descend using LeftShift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var descend = new Vector3(0, -1, 0);
            _rb.velocity += descend;
        }

        // Ascend using Space
        if (Input.GetKey(KeyCode.Space))
        {
            var ascend = new Vector3(0, 1, 0);
            _rb.velocity += ascend;
        }

        _depth = _rb.position.y;

        
    }
}
