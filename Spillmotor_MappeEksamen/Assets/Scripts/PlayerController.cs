using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _speed = 1f;
    [SerializeField] public float maxSpeed = 1f;
    [SerializeField] public float acceleration = 1f;
    [SerializeField] public float deceleration = 1f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] GameObject debris;
    [SerializeField] GameObject oceanFloor;
    [SerializeField] GameObject implosionText;

    // Sound
    [SerializeField] AudioSource _sonarAudioSource;
    [SerializeField] AudioSource _implosionAudioSource; 

    public static float _depth;
    public static float _speedHUD;
    float implosionToMenutimer = 5; 

    private void Awake()
    {
        debris.SetActive(false);
        oceanFloor.SetActive(false);
        implosionText.SetActive(false); 
    }

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

        // Updating _depth for using it in HUD.cs
        //_depth = _rb.position.y * 10; // multiplying it just to make the simulation of pressure go a bit faster.

        if (Menu.Steel)
        {
            HighGradeSteelSubmarine();
        }

        if (Menu.Titanium)
        { 
            TitaniumSubmarine();
        }

        if (Menu.Trieste)
        {
            TriesteSubmarine();
        }

        // Go back to menu
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMenu();
        }
    }

    // High Grade Steel called HY-100, which is meant to withstand up to 100 atmospheres, based on a Seawolf submarine. It has an estimated crush dept of about 730m. - https://www.allthescience.org/what-is-the-deepest-depth-a-submarine-can-go.htm 
    public void HighGradeSteelSubmarine()
    {
        // Updating _depth and _speedHUD for using it in HUD.cs
        _depth = _rb.position.y * 100; // multiplying it just to make the simulation of pressure go a bit faster.
        _speedHUD = -_rb.velocity.y * 100;

        // Maximum depth before implosion.
        if (_depth <= -1000)
        {
            Implosion();
        }
    }

    // Based on Soviet submarine "K-278 Komsomolets", with a hull made of titanium. It was designed to make trips as far down as 1300 meters below sea level. - https://www.allthescience.org/what-is-the-deepest-depth-a-submarine-can-go.htm 
    public void TitaniumSubmarine()
    {
        // Updating _depth and _speedHUD for using it in HUD.cs
        _depth = _rb.position.y * 100; // multiplying it just to make the simulation of pressure go a bit faster.
        _speedHUD = -_rb.velocity.y * 100;

        // Maximum depth before implosion.
        if (_depth <= -1300)
        {
            Implosion();
        }
    }

    // US Navy built a pressured sphere with steel walls 12.7cm thick. - https://www.allthescience.org/what-is-the-deepest-depth-a-submarine-can-go.htm 
    public void TriesteSubmarine()
    {
        var multiplyer = 1000;

        // Updating _depth and _speedHUD for using it in HUD.cs
        _depth = _rb.position.y * multiplyer; // multiplying it just to make the simulation of pressure go a bit faster.
        _speedHUD = -_rb.velocity.y * 100;

        oceanFloor.transform.position = new Vector3(0, (-12000 / multiplyer), 0);
        oceanFloor.SetActive(true);

        if (_depth <= -12000)
        {
            Debug.Log("You are below the bottom of the ocean, mate.");
            Debug.Log("Press Esc to go back to the menu.");
            // Debug.Log("rb position" + _rb.position.y);
        }
    }

    public void Implosion()
    {
        var objectPosition = _rb.position;
        gameObject.SetActive(false);

        // Replace the submarine with a sheet of metal, representing the implosion
        debris.SetActive(true);
        debris.transform.position = objectPosition;

        // Show text that explains to the user that the submarine has imploded.
        implosionText.SetActive(true);

        // Stops the sonar sound and plays the implosion sound.
        _sonarAudioSource.Stop();
        _implosionAudioSource.Play();

        // Load the Menu scene after a set amount of time.
        Invoke(nameof(LoadMenu), implosionToMenutimer);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
