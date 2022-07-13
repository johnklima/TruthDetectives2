using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DecalLineHandler : MonoBehaviour
{

    public TargetTrigger[] FromTo;
    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
            return;

        int count = 0;
        foreach(TargetTrigger targ in FromTo)
        {
            if (targ.done)
                count++;
        }
        if (count == FromTo.Length)
        {

            transform.GetComponent<DecalProjector>().enabled = true;
            done = true;
            this.enabled = false; //no need anymore, right?
        }
    }
}
