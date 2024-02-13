using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShapeChange : MonoBehaviour
{
    public GameObject Cylinder;
    public GameObject TriAngle;
    public GameObject Cube;
    public GameObject FiveAngle;
    public GameObject SixAngle;

    private GameObject currentshape;
    public Slider shapeslider;




    void Start()
    {
        shapeslider.value = 0.076f;
        
        currentshape = Instantiate(Cylinder, new Vector3(0,4,0), Quaternion.Euler(-90, 0, 0));
        shapeslider.onValueChanged.AddListener(delegate { OnShapesildervaluechange(); });

    }


    void Update()
    {
        if (PatternMove.Instance.restartfactor)
        {

            shapeslider.interactable = false;
        }

        OnShapesildervaluechange();
    }

    void switchshape(GameObject newshapeprefab)
    {
        Vector3 rotationEulerAngles = new Vector3(-90, 0, 0); 

        if (newshapeprefab == Cube)
        {
            rotationEulerAngles = new Vector3(-90, 45, 0);  
        }
        GameObject newshape = Instantiate(newshapeprefab, new Vector3(0, 4, 0), Quaternion.Euler(rotationEulerAngles));


        Destroy(currentshape);

        currentshape = newshape;
    }



    public void OnShapesildervaluechange()
    {
        float slidervalue = shapeslider.value;

        if (slidervalue < 0.2f && slidervalue >= 0)
        {
            switchshape(Cylinder);
            

        }
        else if (slidervalue < 0.4f && slidervalue > 0.2f)
        {
            switchshape(TriAngle);


        }
        else if (slidervalue < 0.6f && slidervalue > 0.4)
        {
            switchshape(Cube);


        }
        else if (slidervalue < 0.8f && slidervalue > 0.6f)
        {
            switchshape(FiveAngle);


        }
        else if (slidervalue <= 1f && slidervalue > 0.8f)
        {
            switchshape(SixAngle);


        }
    }



}
