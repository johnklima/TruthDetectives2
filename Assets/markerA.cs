using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class markerA : MonoBehaviour
{
    public CameraGlobeController cameraGlobeController;
    public GameObject patchEnable;
    public GameObject patchDisable;
    public int camIndex;
    public Slider slider;
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
                    patchDisable.SetActive(false);
                    patchEnable.SetActive(true);
                    //this needs to be better resolved
                    slider.value = 9.0f;

                }
               
            }



        }
        
    }


}
