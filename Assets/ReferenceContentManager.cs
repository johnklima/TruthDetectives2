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
    public GameObject enhanceButton;
    public MarkerB markB;
    public markerA markA;


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
            //there is an extra that appears on ground scene
            if (count >= transform.childCount - 1) 
            {
                
                navTool.SetActive(true);
                locations.SetActive(true);
                stillFrame.SetActive(false);
                enhanceButton.SetActive(false);
                markA.goodToGo = true;
                markB.goodToGo = true;

                dialog.KickOffTimer(7); //find a better way

            }
        }
    }
 
    private void Update()
    {

        
        

    }

}
