using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState : MonoBehaviour
{
    public GameObject Sat;

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
        
        SceneManager.LoadSceneAsync("GroundScene", LoadSceneMode.Additive);

    }
}
