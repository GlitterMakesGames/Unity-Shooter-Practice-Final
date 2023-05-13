using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // good enough for now
       // Debug.LogWarning(collision.gameObject.name);
        if (collision.gameObject.name=="Enemy" || collision.gameObject.name == "Enemy(Clone)")
        {
            collision.gameObject.SendMessage("Attacked", 1);
            SoundManager.Instance.PlayClip(0);
        }
        else SoundManager.Instance.PlayClip(2);


    }
}
