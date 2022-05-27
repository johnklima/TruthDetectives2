using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GroundLocationActivator : MonoBehaviour
{
    public Transform location;
    public Transform allLocations;
    public GlobalState global;
    public void showLocation()
    {
        //turn them all off
        foreach (Transform child in allLocations)
        {
            child.gameObject.SetActive(false);
        }
        global.dcam = location.GetComponent<DialogueCamera>();
        location.gameObject.SetActive(true);
    }
}
