using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{

    public Transform source;
    public GlobalState globalState;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform == source)
        {
            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("source is placed");
                globalState.loadGround();
            }
        }
    }
}
