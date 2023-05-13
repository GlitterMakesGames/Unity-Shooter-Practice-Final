using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public void onPlayagainClick()
    {

        SceneManager.LoadScene(0);
    }

    public void onPlayClick()
    {

        SceneManager.LoadScene(1);
    }
}
