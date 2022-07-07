using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericActivate : MonoBehaviour
{
    public GameObject[] toActivate;
    // Start is called before the first frame update
    //nice thing about start, it is called when ever the GameObject is activated,
    //such that we can activate other game objects in response.

    public float delay = 0.5f;
    float timer = -1;

    void Start()
    {
        timer = Time.time;

    }
    private void Update()
    {
        if (Time.time - timer > delay && timer > 0 )
        {
            foreach (GameObject obj in toActivate)
            {
                obj.SetActive(true);

            }
            timer = -1;
            //maybe...
            this.enabled = false;
        }
        
    }
}
