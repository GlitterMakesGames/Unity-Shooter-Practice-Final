using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{

    public GameObject enemy;
    public GameObject target;
    public GameManager gm;
    public float spawnRate = 2;
    private float timer = 0;
    private float gametimer = 0;
    public float heightOffset = 5;
    public float lastheight = 0;
    GameObject instance;
//    public TextMeshProUGUI statusText;



    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = gameObject;
        if (instance != gameObject) Destroy(instance);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += (Time.deltaTime * 2);
        }
        else
        {
            spawn();
            timer = 0;
            gametimer += 1;
         //   if (gametimer > 145)
           // {
         //       SceneManager.LoadScene(2);
        //    }
        }




    }

    public void SetStatus(string statusMsg)
    {
     //   statusText.text = statusMsg;
   //     SetTextToFullAlpha(statusText);
    }


    void spawn()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        lastheight = transform.position.y;
        enemy.GetComponent<Pathfinding.AIDestinationSetter>().target=target.transform;
        Instantiate(enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }


    public void FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        // i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        if (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - 0.002f);

        }

    }

}
