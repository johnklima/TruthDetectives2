using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContentManager : MonoBehaviour
{
    public float timer = -1;
    public float interval = 0.5f;
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

    public void KickOffTimer()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float rnd = Random.Range(0, 0.5f);
        if (Time.time - timer > (interval + rnd) && timer > 0)
        {
            if (index == pauseIndex)
            {
                if (toolBot)
                {
                    toolBot.gameObject.SetActive(true);                    
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
