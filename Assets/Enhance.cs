using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enhance : MonoBehaviour
{
    public Texture[] textures;
    public RawImage rawImage;
    public int index;
    public void setIndex(int indx)
    {
        index = indx;
    }
    public void OnClick()
    {
        rawImage.texture = textures[index];

    }

}
