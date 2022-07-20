using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericActivate : MonoBehaviour
{
    public GameObject[] toActivate;
    // Start is called before the first frame update
    //nice thing about start, it is called when ever the GameObject is activated,
    //such that we can activate other game objects in response.

    public float[] delay  ;
    public float timer = -1;
    private int index = 0;

    void Start()
    {
        //ODD: had to change this to realtimeSinceStartup as you cant get
        //time on the first frame of level load? returns 0??
        Time.timeScale = 1.0f;
        Debug.Log("start " + Time.realtimeSinceStartup);
        timer = Time.realtimeSinceStartup;

    }
    private void Update()
    {
        
        if (timer > 0 && Time.realtimeSinceStartup - timer > delay[index]  )
        {

            GameObject obj = toActivate[index];
            obj.SetActive(true);

            index++;

            if(index == toActivate.Length)
            {
                timer = -1;
                this.enabled = false;
            }
            else
                timer = Time.time;
            
        }
        
    }
}
