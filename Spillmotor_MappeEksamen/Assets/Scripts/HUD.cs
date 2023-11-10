using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text depthText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text speedText;

    private float depth = 0;
    private float time = 0;
    private float speed = 0;

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
        depth = PlayerController._depth;

        //speedText.text = speed.ToString("f0") + " km/h";
        //speed = PlayerController._speed; 
        // Might be able to showcase if the submarine is moving thorugh a boolean that is set to true or false under every movement statement in PlayerController
    }
}
