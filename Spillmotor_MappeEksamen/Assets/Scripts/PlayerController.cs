using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody _rb;

    // Update is called once per frame
    void Update()
    {
        if (CameraControl.activeCameraNr == 1)
        {
            var direction1 = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            _rb.velocity = direction1 * _speed;
        }
        else
        {
            var direction2 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _rb.velocity = direction2 * _speed; 
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var descend = new Vector3(0, -1, 0);
            _rb.velocity = descend * _speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ascend = new Vector3(0, 1, 0);
            _rb.velocity = ascend * _speed;
        }
    }
}
