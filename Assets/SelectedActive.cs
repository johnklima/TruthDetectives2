using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedActive : MonoBehaviour
{

    public GameObject[] selectors;
    // Start is called before the first frame update
    public void onClick()
    {
        foreach(GameObject obj in selectors)
        {
            if (obj != transform.gameObject)
                obj.SetActive(false);
        }
        
    }    
}
