using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerContoller : MonoBehaviour
{
    public VideoPlayer vid;
    public Image image;
    public Sprite offSprite;
    public GameObject videoPanel;
    public Button close;
    public GameObject dialogScroll;
    public GameObject dialogScrollFrame;

    void Start() 
    {
        image.sprite = offSprite;
        vid.loopPointReached += CheckOver;

        vid.Play();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //working for first video only, need a state
        
        print("Video Is Over");

        return;
        
        videoPanel.SetActive(false);
        dialogScrollFrame.SetActive(true);
        dialogScroll.SetActive(true);

    }


}
