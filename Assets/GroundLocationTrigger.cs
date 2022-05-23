using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLocationTrigger : MonoBehaviour
{
    
    public Quaternion camQuat;
    public Vector3 camPos;
    public Vector3 playPos;
    public Quaternion playQuat;
    public float t = -1;
    public bool placed = false;

    private void Start()
    {
        camPos = transform.position;
        camQuat = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (placed)
            return;

        if (other.tag == "Player")
        {

            Debug.Log("Player entered");            
            Camera.main.transform.GetComponent<CameraContoller>().lockMovement = true;
            other.GetComponent<PlayerController>().enabled = false;
            playPos = other.transform.position;
            playQuat = Camera.main.transform.rotation;

            // set off the timer
            t = Time.deltaTime; 

        }

    }

    private void Update()
    {

        camQuat = transform.rotation;

        if (placed && t < 1)
        {
            Camera.main.transform.rotation = Quaternion.Slerp(camQuat, playQuat, t);
            t += Time.deltaTime * 0.5f;
        }
        else if (placed && t > 1)
        {
            CameraContoller cc = 
                Camera.main.transform.GetComponent<CameraContoller>();
            //cc.pitch = Camera.main.transform.eulerAngles.x;
            //cc.yaw = Camera.main.transform.eulerAngles.y;
            //cc.SetPitchYaw();

            cc.lockMovement = false;
            //were done.
            this.enabled = false;

        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (placed)
        {           
            return;
        }
        

        if (other.tag == "Player" && t > 0)
        {
            Camera.main.transform.rotation = Quaternion.Slerp(playQuat, camQuat, t);
            other.transform.position = Vector3.Lerp(playPos, camPos, t);
            //t = 0.9999f;
            t += Time.deltaTime * 0.8f;
            if(t>1)
            {
              
                //show the sprite
                transform.GetChild(0).gameObject.SetActive(true);
                //free olayer movement
                other.GetComponent<PlayerController>().enabled = true;
                //reset the timer for slerp back
                placed = true;
                t = 0; 
            }

        }
    }
}