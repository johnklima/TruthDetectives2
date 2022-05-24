using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightRotator : MonoBehaviour
{
    public Quaternion minQ = new Quaternion(-0.455836654f, 0.389251888f, -0.795029819f, 0.0928619578f);
    public Quaternion maxQ = new Quaternion(-0.316004694f, 0.881581247f, -0.0800254494f, -0.341396511f);
    public Transform lght; 
    public void setXrotation()
    {
        float value = transform.GetComponent<Slider>().value;
        lght.rotation = Quaternion.Slerp(minQ, maxQ, value);
    }
}
