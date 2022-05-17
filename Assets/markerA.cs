using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class markerA : MonoBehaviour
{
    public CameraGlobeController cameraGlobeController;
    public GameObject patchEnable;
    public GameObject patchDisable;
    public GameObject mediaSroll;
    public int camIndex;
    public Slider slider;
    public GameObject toolBot;
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
                if(objectHit.name == "markerHit")
                {
                    cameraGlobeController.TransitionCameraSpecific(camIndex);
                    cameraGlobeController.setGlobeRotation(); //todo, params
                    patchDisable.SetActive(false);
                    patchEnable.SetActive(true);
                    mediaSroll.SetActive(false);
                    toolBot.SetActive(true);
                    //this needs to be better resolved
                    slider.value = 9.0f;

                }
               
            }



        }
        
    }


}
