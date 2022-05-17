using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

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
    public RenderPipelineAsset rpasset;
    private void Awake()
    {
        //set correct quality settings
        
        QualitySettings.SetQualityLevel(0);
        QualitySettings.renderPipeline = rpasset;

    }

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
            
            Vector3 dir = prevMousePos - Input.mousePosition;
            //XY inverted in world space
            float x = dir.x;
            float y = dir.y;
            //fix direction
            dir.x = -y;
            dir.y = x;
            dir.Normalize();

            float z = Mathf.Abs(transform.position.z);

            
            //make a quick curve cause i'm too stupid to do the math
            if (z > 9.8f)
                z *= 0.20f ;
            if (z > 9.6f)
                z *= 0.15f;
            if (z > 9.4f)
                z *= 0.10f;
            if (z > 9.2f)
                z *= 0.05f;
            if (z > 9.0f)
                z *= 0.01f;
            if (z > 8.8f)
                z *= 0.005f;
            if (z > 8.6f)
                z *= 0.001f;
            if (z > 8.4f)
                z *= 0.0005f;
            if (z > 8.2)
                z *= 0.0001f;
            if (z > 8)
                z *= 0.0001f;
            
            float t =  z * Time.deltaTime ;
            rotator.Rotate(dir * t );

            

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

        
    }
}
