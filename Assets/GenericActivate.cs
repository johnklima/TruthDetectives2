using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericActivate : MonoBehaviour
{
    public GameObject[] toActivate;
    // Start is called before the first frame update
    //nice thing about start, it is called when ever the GameObject is activated,
    //such that we can activate other game objects in response.

    //pre-allocate array to avoid errors, now that it is an array and not a single value
    public float[] delay = { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f } ;
    float timer = -1;
    private int index = 0;

    void Start()
    {
        timer = Time.time;

    }
    private void Update()
    {
        if (Time.time - timer > delay[index] && timer > 0 )
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
