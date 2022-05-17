using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    Vector3 prevMousePos;
    bool dragging = false;

    public Transform lookTool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //click
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log("HIT " + objectHit.tag);
                if(objectHit.tag == "Rotator")
                    dragging = true;

            }

        }
        if (Input.GetMouseButton(0) && dragging)
        {
            //drag
            doDrag();

        }
        if (Input.GetMouseButtonUp(0) )
        {
            //drop
            dragging = false;
        }

    }

    void doDrag()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 3;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            transform.LookAt(hit.point); 
           
        }




    }
}
