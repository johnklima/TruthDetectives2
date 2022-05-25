using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{

    public Transform source;
    public GlobalState globalState;
    public bool done = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (done)
            return;

        if(other.transform == source)
        {
            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("source is placed");

                //counts up till all are placed, then loads
                globalState.loadGround();

                //turn me off
                done = true;
            }
        }
    }
}
