using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StillFader : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mouseScrollDelta.y != 0)
        {
            RawImage rend = GetComponent<RawImage>();
            Color color = rend.color;
            color.a += Input.mouseScrollDelta.y * 0.1f;
            if (color.a > 1)
                color.a = 1;
            if (color.a < 0)
                color.a = 0;

            rend.color = color;
        }
            
    }
 
}
