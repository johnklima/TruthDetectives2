using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGlobeController : MonoBehaviour
{

    public bool transition = false;
    public Camera camera;
    Quaternion camQ;
    Vector3 camD;
    float t = 0;
    public Quaternion[] goalQs;
    public Vector3[] goalDs;
    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3(-0.589999974, 0.49000001, -0.469999999)
        //Quaternion(0.0903404206, -0.484166563, 0.702216804, -0.514113724)
    }
    //Vector3(0.0430000015,0,3.102)

    // Update is called once per frame
    void Update()
    {
        if(transition)
        {
            t += Time.deltaTime;
            //Quaternion newrot = Quaternion.Slerp(camQ, goalQs[index], t);
            //transform.rotation = newrot;
            Vector3 newPos = Vector3.Slerp(camD, goalDs[index], t);
            camera.transform.localPosition = newPos;
            if(t > 1)
            {
                transition = false;

            }
        }
    }

    public void TransitionCamera()
    {
        index++;
        if (index > goalDs.Length)
            index = -1;

        camD = camera.transform.localPosition;
       
        t = 0;
        transition = true;
        

    }
}
