using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContentManager : MonoBehaviour
{
    public float timer = -1;
    public float[] interval;
    public Transform child;
    public int index = 0;
    public Transform toolBot;
    public int pauseIndex = 2;

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
        float rnd = Random.Range(0, interval[index] * 0.5f);
        if (Time.time - timer > (interval[index] + rnd) && timer > 0)
        {
            if (index == pauseIndex)
            {
                
                //this happens only occasionally
                if (toolBot)
                {
                    toolBot.gameObject.SetActive(true);
                    toolBot = null;
                }
                

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
