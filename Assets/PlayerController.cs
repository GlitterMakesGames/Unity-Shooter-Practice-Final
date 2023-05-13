using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TMPro.TextMeshPro statusText;
    public int moveSpeed = 15;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public Weapon weapon;
    Vector2 moveDirection;
    Vector2 mousePosition;
    public Camera cam;
    public int health = 10;
    public static int score=0;
    GameObject instance;
    GameManager gm;
    private bool isdead = false;
 //   public static bool isFirstScore = true;  // Not sure why, but Attacked gets calls twice on first contact with first monster.


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        if (instance == null) instance = gameObject;
        if (instance != gameObject) Destroy(instance);
        gm = GameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //Get inputted movement
        float moveY = Input.GetAxisRaw("Vertical");


        if (Input.GetMouseButtonDown(0)) {
            weapon.Fire();
           // health -= 1;   //test death animation
          //  Debug.LogWarning(health);
          //  if (health == 0) animator.SetTrigger("isDead");
        }

        moveDirection = new Vector2(moveX, moveY).normalized;    // calculate movedirection
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        statusText.text = "LIVES: " + health.ToString() + "   SCORE: " + score.ToString();
        if (health == 0 && !isdead)
        {
            //Debug.LogWarning("death");
            isdead = true;
            SoundManager.Instance.PlayClip(3);
            gameObject.GetComponent<Animator>().SetTrigger("dieAlready");
            Destroy(gameObject, 1);
            GameManager.Instance.score = score;
 //          gm.StartPause();
  //          SceneManager.LoadScene(2);
  //Aparently you can pause after death or you can display the death animation, but there seems no way to do one, then the other.

        }
    }




     void Attacked(int damage)
    {

            health -= damage;
            SoundManager.Instance.PlayClip(4);

    }

    private void FixedUpdate()
    {

            // Set velocity of player
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            if (moveDirection.x + moveDirection.y == 0)
                animator.SetBool("isMoving", false);
            else
                animator.SetBool("isMoving", true);

        //Debug.LogWarning(moveDirection.x);
        // Calculate aim angle based on mouseposition
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = mousePos - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        //Debug.LogWarning(aimAngle);

        if (aimAngle <-100) // Curde attempt at keeping player upright.
            sr.flipY = true;
        else 
            sr.flipY =false;
    }

    void NextLevelAfterWait()
    {
        // gm.StartPause();
        Thread.Sleep(4500);
        //SceneManager.LoadScene(2);
       GameManager.Instance.onDeath();
    }


}
 