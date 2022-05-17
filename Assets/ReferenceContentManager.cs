using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceContentManager : MonoBehaviour
{
    public int index;
    public GameObject navTool;
    public GameObject stillFrame;
    public GameObject locations;
    public DialogContentManager dialog;
    public GameObject toolBot;
    public void SetIndex(int indx)
    {
        index = indx;
        transform.GetChild(index).gameObject.SetActive(true);

        int count = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                count++;
            }
            if (count >= transform.childCount)
            {
                //toolBot.SetActive(true);
                navTool.SetActive(true);
                locations.SetActive(true);
                stillFrame.SetActive(false);
                

                dialog.KickOffTimer(8);

            }
        }
    }

    private void Update()
    {

        
        

    }

}
