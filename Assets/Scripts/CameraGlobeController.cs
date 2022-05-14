using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGlobeController : MonoBehaviour
{

    public bool transition = false;
   
    //public Camera camera;
    Quaternion camQ;
    Vector3 camD;
    float t = 0;
    public Vector3[] goalEs;
    public Vector3[] goalDs;
    int index = -1;
    Vector3 prevMousePos;
    public bool panning;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3(-0.589999974, 0.49000001, -0.469999999)
        //Quaternion(0.0903404206, -0.484166563, 0.702216804, -0.514113724)
        TransitionCamera();
    }
    //Vector3(0.0430000015,0,3.102)

    // Update is called once per frame
    void Update()
    {
        if(transition)
        {
            t += Time.deltaTime;
            //Quaternion newrot = Quaternion.Slerp(camQ, goalEs[index], t);
            //transform.rotation = newrot;
            Vector3 newPos = Vector3.Slerp(camD, goalDs[index], t);
            transform.localPosition = newPos;
            Quaternion q = new Quaternion();
            q.eulerAngles = goalEs[index];
            Quaternion rot = Quaternion.Slerp(camQ, q, t);
            transform.localRotation = rot;

            if(t > 1)
            {
                transition = false;

            }
        }

        if (panning)
        {
            Transform rotator = transform.parent;
            float t = (1.0f / transform.position.z) / Time.deltaTime;

            Vector3 dir = prevMousePos - Input.mousePosition;
            //XY inverted in world space
            float x = dir.x;
            float y = dir.y;

            dir.x = y;
            dir.y = x;
            dir.Normalize();

            rotator.Rotate(dir * Time.deltaTime);

            

        }
    }

    public void TransitionCamera()
    {
        index++;
        if (index > goalDs.Length-1)
        {
            index = -1;
            return;
        }


        camD = transform.localPosition;
        camQ = transform.localRotation;

        t = 0;
        transition = true;
        

    }
    public void TransitionCameraSpecific(int indx)
    {
        
        if (indx > goalDs.Length - 1)
        {
            Debug.Log("Cam transition index out of bounds");
            return;
        }

        index = indx;

        camD = transform.localPosition;
        camQ = transform.localRotation;

        t = 0;
        transition = true;


    }
    public void Zoom(Slider slider)
    {

        float value = slider.value;
        Vector3 newPos = transform.position;
        newPos.z = -value;
        transform.position = newPos;
       
    }
    public void Pan(bool pan)
    {

        panning = pan;
        prevMousePos = Input.mousePosition;

        prevMousePos = Input.mousePosition;
    }
}
