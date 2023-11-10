using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] GameObject Camera3;

    public Transform target;
    public Vector3 Camera1_offset; // Sideview  | X: 5.57, Y: 1, Z: 0               | same
    public Vector3 Camera2_offset; // Telescope | X: -1.67, Y: 3.38, Z: 0           | X: 0, Y: 3.38, Z: 0
    public Vector3 Camera3_offset; // Birdview  | X: -1.609, Y: 7.632, Z: -2.195    | X: 0, Y: 6, Z: -1.23

    // I use this variable to change horizontal and vertical movement in the PlayerController script
    public static int activeCameraNr = 1;

    private void Start()
    {
        CameraOne();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position + offset;

        if (Input.GetKeyDown("1"))
        {
            CameraOne();
            activeCameraNr = 1;
        }

        if (Input.GetKeyDown("2"))
        {
            CameraTwo();
            activeCameraNr = 2;
        }

        if (Input.GetKeyDown("3"))
        {
            CameraThree();
            activeCameraNr = 3;
        }

        Camera1.transform.position = target.position + Camera1_offset;
        Camera2.transform.position = target.position + Camera2_offset;
        Camera3.transform.position = target.position + Camera3_offset;
    }

    void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
    }

    void CameraTwo()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        Camera3.SetActive(false);
    }

    void CameraThree()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(true);
    }
}
