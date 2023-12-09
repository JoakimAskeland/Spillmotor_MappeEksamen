using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text depthText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text pressureText;
    [SerializeField] private TMP_Text speedText;

    private float depth = 0;
    private float atmospheres = 0.1f;
    private float psi = 14.7f;
    private float time = 0;
    //private float speed = 0;

    public Color black => Color.black;
    public Color red => Color.red; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Showing time in 2 decimals
        timeText.text = "Time: " + time.ToString("f2");
        time += Time.deltaTime;

        // Showing the submarines depth
        depthText.text = "Depth: " + depth.ToString("f2");
        DepthCalculations();

        // Showing the pressure levels, calculated from the depth of the submarine
        pressureText.text = "Atmospheres: " + atmospheres.ToString("f1") + "\n" + "psi: " + psi.ToString("f1");
        // if pressure is critical, show txt as red or have warnings flash over the screen
        if (atmospheres > 1)
        {
            pressureText.color = WarningFlash(black, red, 5);
        }
        else
        {
            pressureText.color = black;
        }

        //speedText.color = Color.red; 
        //speedText.text = speed.ToString("f0") + " km/h";
        //speed = PlayerController._speed; 
        // Might be able to showcase if the submarine is moving through a boolean that is set to true or false under every movement statement in PlayerController
    }

    public void DepthCalculations()
    {
        // In meters
        depth = PlayerController._depth; 

        if (depth != 0)
        {
            // In atmospheres. A rule of thumb is that atmospheres go up by one per 10 meters of depth in the ocean.
            atmospheres = -depth / 10;

            // In psi (pressure per pound per square inch)
            psi = atmospheres * 14.7f;
        }

        //Debug.Log("Atmospheres: " + atmospheres + " | psi: " + psi);
    }

    // Changing color of text to give player a warning.
    public Color WarningFlash(Color first,  Color second, float speed) => Color.Lerp(first, second, Mathf.Sin(Time.time * speed));
}
