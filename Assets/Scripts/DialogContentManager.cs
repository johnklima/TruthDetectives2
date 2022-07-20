using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContentManager : MonoBehaviour
{
    public float timer = 1;
    public float[] interval;
    public Transform child;
    public int index = 0;    
    public int pauseIndex = 1; 

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
        child = transform.GetChild(index);
    }

    public void KickOffTimer(int pause)
    {
        timer = Time.time;
        pauseIndex = pause;
    }
    public void SetInterval(float intrv)
    {
        interval[index] = intrv;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Time.time - timer > (interval[index] ) && timer > 0)
        {
            Debug.Log("index " + index);
            Debug.Log("interval " + interval[index]);
            if (index == pauseIndex)
            {               


                timer = 1; //pause
                return;
            }

            Debug.Log("play chat");
            child.gameObject.SetActive(true);

            if (index < transform.childCount)
            {
                child = transform.GetChild(index);
                index++;
                timer = Time.time;

            }            
            else
            {
                timer = -1; //end of list
            }
                
        }
    }
}
