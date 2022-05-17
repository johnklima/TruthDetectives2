using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public GameObject Sat;

    public GameObject[] hideGuis;
    public GameObject[] showGuis;
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

        SceneManager.LoadSceneAsync("GroundScene", LoadSceneMode.Additive);

    }
}
