using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 3;
    private bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
         // gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("dieAlready");

    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0 && !isdead)
        {
            SoundManager.Instance.PlayClip(1);
            isdead = true;
   //         if (!PlayerController.isFirstScore)
                PlayerController.score += 1;
          //  PlayerController.isFirstScore = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("dieAlready");
            //Debug.LogWarning(gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().GetInteger("health"));
            Destroy(gameObject, 1);
        }

        }

    void Attacked(int damage)
    {
        GameManager.instance.SendMessage("StartShake");
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogWarning(collision.gameObject.name);
        // Destroy(collision.gameObject); // good enough for now

        if (collision.gameObject.name == "Player" ) 
        {
            Destroy(gameObject);
            collision.gameObject.SendMessage("Attacked", 1);
        }

    }


}
