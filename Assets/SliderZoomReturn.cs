using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderZoomReturn : MonoBehaviour
{

    Slider slider;
    public bool onGround = false;
    public CameraGlobeController camglobe;

    public GameObject[] enables;
    public GameObject[] disables
        ;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= slider.maxValue && onGround)
        {
            //transition camera to return point
            Debug.Log("slider max return");
            onGround = false;
            camglobe.TransitionCameraSpecific(1);
            
            foreach (GameObject obj in enables)
                obj.SetActive(true);

            foreach (GameObject obj in disables)
                obj.SetActive(false);


        }
        
    }
}
