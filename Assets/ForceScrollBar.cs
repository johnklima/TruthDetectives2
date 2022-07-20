using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForceScrollBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public Scrollbar scrollbar;
    void Start()
    {
        timer = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 0.5f)
        {
            scrollbar.value = 0;
            this.enabled = false;
        }
            
    }
}
