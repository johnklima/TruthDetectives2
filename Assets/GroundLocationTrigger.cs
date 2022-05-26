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
    public Transform player;
    public Transform quadPos;
    public GlobalState global;

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
            player = other.transform;
            Camera.main.transform.GetComponent<CameraContoller>().lockMovement = true;
            player.GetComponent<PlayerController>().enabled = false;
            player.position = transform.position;
            playPos = player.position;
            camPos.z = playPos.z;

            playQuat = Camera.main.transform.rotation;

            // set off the timer
            t = Time.deltaTime; 

        }

    }



    private void Update()
    {
        //to place the images in design at runtime       
        //camQuat = transform.rotation;
        //camPos = transform.position;
        

        if (placed && t <= 1 && t > 0)
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

            //free player movement
            player.GetComponent<PlayerController>().enabled = true;
            //increment the global placed count to show video
            global.ShowVideo();
            
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
           
            t += Time.deltaTime * 0.5f;

            //for placing at runtime design
            //t = 0.999999f;

            if (t>1)
            {
                //unchild, move and show the sprite
                Transform sprt = transform.GetChild(0);
                Vector3 pos = Camera.main.transform.GetChild(0).position;
                Quaternion rot = Camera.main.transform.GetChild(0).rotation;

               
                sprt.position = pos;
                sprt.rotation = rot;
                
                
                
                //show human
                transform.GetChild(1).SetParent(null);
                //detach sprite
                sprt.SetParent(null);
                sprt.localScale = new Vector3(1.75f, 1.0f, 1.0f);
                //use sprite? not sure
                sprt.gameObject.SetActive(true);


                //reset the timer for slerp back
                placed = true;
                t = -1; 
            }

        }
    }

    public void resetT()
    {
        t = Time.deltaTime;
    }
}
