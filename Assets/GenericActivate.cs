using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericActivate : MonoBehaviour
{
    public GameObject[] toActivate;
    // Start is called before the first frame update
    //nice thing about start, it is called when ever the GameObject is activated,
    //such that we can activate other game objects in response.
    void Start()
    {
        foreach(GameObject obj in toActivate)
        {
            obj.SetActive(true);
        }
    }

}
