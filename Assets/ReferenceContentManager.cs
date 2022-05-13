using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceContentManager : MonoBehaviour
{
    public int index;
    public void SetIndex(int indx)
    {
        index = indx;
        transform.GetChild(index).gameObject.SetActive(true);
    }

}
