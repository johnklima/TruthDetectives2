using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScroll : MonoBehaviour
{

    public float timer = -1;    
    public Transform child;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start scroll");
        timer = Time.time;
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 0.5f && timer > 0)
        {

            Debug.Log("start chat");
            
            child.gameObject.SetActive(true);
            
            if(child.childCount > 0)
            { 
                child = child.GetChild(0);
                timer = Time.time;

            }
            else 
            {
                timer = -1;
            }    
    
        }
    }
}
