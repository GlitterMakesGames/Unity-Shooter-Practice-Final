using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onQuitClick()
    {
        Application.Quit();
    }

    public void onPlayClick()
    {
        SceneManager.LoadScene(1);
    }
}
