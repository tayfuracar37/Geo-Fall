using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundcolor : MonoBehaviour
{
    [SerializeField] private Camera cameraRef;
    [SerializeField] private Color[] colors;
    [SerializeField] private float colorcahngespeed;
    [SerializeField] private float time;

    private float currenttime;
    private int colorindex;

    private void Awake()
    {
        cameraRef = Camera.main;

    }

    private void Colorchange()
    {
        cameraRef.backgroundColor = Color.Lerp(cameraRef.backgroundColor, colors[colorindex], colorcahngespeed * Time.deltaTime);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Colorchange();
        colorchangetime();
    }

    private void colorchangetime()
    {
        if (currenttime <= 0)
        {
            colorindex++;
            checkcolorindex();
            currenttime = time;
        }
        else
        {
            currenttime -= Time.deltaTime;
        }
    }

    private void checkcolorindex()
    {
        if (colorindex >= colors.Length)
        {
            colorindex = 0;
        }
    }

    private void OnDestroy()
    {
        cameraRef.backgroundColor = colors[0];
    }
}
