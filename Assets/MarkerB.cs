using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MarkerB : MonoBehaviour
{
    public CameraGlobeController cameraGlobeController;
    public GameObject patchEnable;
    public GameObject patchDisable;
    public GameObject mediaSroll;
    public int camIndex;
    public Slider slider;
    public GameObject toolBot;
    public bool goodToGo = false;
    
    public GameObject mapLocationA;            // changed by Raphael
    public GameObject mapLocationB;            // changed by Raphael
    public GameObject map2Locations;             // changed by Raphael

    public Rotator[] toAllow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log("HIT " + objectHit.name);
                if (objectHit.name == "markerHitB" && goodToGo)
                {
                    //turn on make models visible function on level transition
                    foreach (Rotator rot in toAllow)
                    {
                        rot.AllowEnable();
                    }


                    cameraGlobeController.TransitionCameraSpecific(camIndex);
                    cameraGlobeController.setGlobeRotation(); //todo, params
                    patchDisable.SetActive(false);
                    patchEnable.SetActive(true);
                    mediaSroll.SetActive(false);
                    toolBot.SetActive(true);
                    
                    mapLocationA.SetActive(false);  // Raphael
                    mapLocationB.SetActive(true);   // Raphael
                    map2Locations.SetActive(false); // Raphael

                    //this needs to be better resolved

                    slider.minValue = 9.0f;
                    slider.maxValue = 9.3f;
                    slider.value = 9.25f;

                    slider.GetComponent<SliderZoomReturn>().onGround = true;

                }

            }



        }

    }
}
