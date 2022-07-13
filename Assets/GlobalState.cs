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
    public int placedCount = 0;
    public DialogueCamera dcam;
    public float loadTimer = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            placedCount = 5;
            loadGround();
        }
        if (loadTimer > 0 && Time.time-loadTimer > 3)
        {
            TimerLoad();
        }



    }

    private void TimerLoad()
    {
        Destroy(Sat);

        for (int i = 0; i < hideGuis.Length; i++)
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

        SceneManager.LoadSceneAsync("GroundScene", LoadSceneMode.Single);
    }
    public void loadGround()
    {
        placedCount++;
        
        //have we placed 3 of 4 buildings? 4 out of 4?
        if (placedCount < 4)
            return;

        loadTimer = Time.time;

        

    }
    
    //for ground level
    public GameObject videoThumbnail;
    public int groundCount = 0;
    public void ShowVideo()
    {
        
        groundCount++;
        if (groundCount >= 3)
            videoThumbnail.SetActive(true);
    }
    public void DisableDialogueCamera()
    {
        if (dcam)
            dcam.DisableDialogueCamera();
    }
}
