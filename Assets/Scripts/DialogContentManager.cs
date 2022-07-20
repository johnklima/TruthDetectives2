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
        timer = -1;
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
        //check timer first - important on the ground level
        if (timer > 0 && Time.time - timer > (interval[index] ))
        {
            Debug.Log("index " + index);
            Debug.Log("interval " + interval[index]);
            if (index == pauseIndex)
            {               


                timer = -1; //pause
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
