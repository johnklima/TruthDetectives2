using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    Vector3 prevMousePos;
    bool dragging = false;
    public Transform target;
    public bool allow = false;
    public void AllowEnable()
    {
        allow = true;
    }

    // Start is called before the first frame update
    public void checkEnable()
    {
        if (allow == false)
            return;

        // Bit shift the index of the layer (3) to get a bit mask
        int layerMask = 1 << 3;


        RaycastHit hit;
        Vector3 pos = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        Ray ray = Camera.main.ScreenPointToRay(pos);

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            transform.LookAt(hit.point);

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //click
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                Transform objectHit = hit.transform;
                Debug.Log("HIT " + objectHit.name);
                if(objectHit == target)
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
        // Bit shift the index of the layer (3) to get a bit mask
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
