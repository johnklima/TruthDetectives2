using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public GameObject Sat;

    public GameObject[] hideGuis;
    public GameObject[] showGuis;
    public Image StillFrame;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void loadGround()
    {

        Destroy(Sat);   
        
        for(int i = 0; i < hideGuis.Length; i++)
        {
            hideGuis[i].SetActive(false);
        }

        for (int i = 0; i < showGuis.Length; i++)
        {
            showGuis[i].SetActive(true);
        }

        //swap still frame background
        StillFrame.sprite = sprite;
        StillFrame.SetNativeSize();

        SceneManager.LoadSceneAsync("GroundScene", LoadSceneMode.Additive);

    }
}
