using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMPro.TextMeshPro statusText;
    public static GameManager instance;
    public int score;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    public void StartShake()
    {
        Camera.main.SendMessage("StartShake");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    public void onPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void onDeath()
    {
        SceneManager.LoadScene(2);
     }



    public void StartPause()
    {
        // how many seconds to pause the game
        StartCoroutine(PauseGame(25f));
    }
    public IEnumerator PauseGame(float pauseTime)
    {
        Debug.Log("Inside PauseGame()");
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        Debug.Log("Done with my pause");
        PauseEnded();
    }

    public void PauseEnded()
    {
        SceneManager.LoadScene(2);
    }
}

