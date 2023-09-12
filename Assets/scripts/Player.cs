using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    public float wSpeed = 1;
    public float rSpeed = 2;
    float speed = 1;
    Rigidbody2D rbody;
    SpriteRenderer srender;
    public Animator anim;
    public bool dontmove = false;
    public bool nomove = false;
    public bool canattack = true;

    public bool MovingTowards = false;

    private Vector3 endpos;
    private float timeMulti;

    public bool triggerEnter = false;
    public AudioClip attack;
    public AudioClip walk;
    private AudioSource source;
    public Collider2D currentCollider;
    public bool currentattack = false;

    private bool fire = false;

    private Vector2 movement_vector;
    public bool noattack=false;
   
    // Use this for initialization
    void Start()
    {
        movement_vector = Vector2.zero;
        source = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        srender = GetComponent<SpriteRenderer>();
        speed = wSpeed;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEnter = true;
        currentCollider = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerEnter = false;
        currentCollider = null;
    }

    public void AttackSound() { source.clip = attack; source.loop = false; source.Play(); }

    public void WalkSound() { source.clip = walk; source.loop = true; source.Play(); }

    public void MoveTo(Vector3 position, float timeM) { MovingTowards = true; anim.SetBool("iswalking", true); timeMulti = timeM; endpos = position; }

    void FixedUpdate()
    {

        

        if (MovingTowards) { transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * timeMulti); if (transform.position.x == endpos.x) { MovingTowards = false;anim.SetBool("iswalking", false); } }
        /*Vector2 movement_vector = Vector2.zero;
        if (altmove_vector == Vector2.zero) {
            movement_vector = altmove_vector * speed * Time.fixedDeltaTime;
        } else {
            movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.fixedDeltaTime;
        }*/

        //GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse); }

        if (/* fire */ Input.GetMouseButtonDown(0) && canattack && !noattack) { anim.SetBool("isattack", true); currentattack = true; }
        else if (Input.GetMouseButtonUp(0) && canattack && !noattack) { anim.SetBool("isattack", false); currentattack = false; }

        if (!dontmove && !nomove)
        {
            /*if (Input.GetMouseButtonDown(0)&&canattack) { anim.SetBool("isattack", true); currentattack = true; }
            else if (Input.GetMouseButtonUp(0) && canattack) { currentattack = false; }*/

            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("iswalking", true);
                if (movement_vector.x > 0) { srender.flipX = false; }
                else { srender.flipX = true; }
                if (Input.GetKeyDown(KeyCode.LeftShift)) { anim.SetBool("isrunning", true); speed = rSpeed; }
                else { anim.SetBool("isrunning", false); speed = wSpeed; }
            }
            else
            {
                source.Stop();
                anim.SetBool("iswalking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector);
        }
        else { anim.SetBool("isattack", false); if (!MovingTowards) { anim.SetBool("iswalking", false); } }
        
            //Debug.Log(movement_vector);
            //rbody.velocity = new Vector2(movement_vector.x*10*speed, rbody.position.y);

            /*public float speed = 5f;
            private float direction = 0f;
            private Rigidbody2D player;


            // Start is called before the first frame update
            void Start()
            {
                player = GetComponent<Rigidbody2D>();
            }

            // Update is called once per frame
            void Update()
            {

                direction = Input.GetAxis("Horizontal");

                if (direction > 0f)
                {
                    player.velocity = new Vector2(direction * speed, player.velocity.y);
                }
                else if (direction < 0f)
                {
                    player.velocity = new Vector2(direction * speed, player.velocity.y);
                }
                else
                {
                    player.velocity = new Vector2(0, player.velocity.y);
                }


            }
            */

    }
    //IEnumerator fired() { if (fire) { yield return new WaitForSeconds(1); fire = false; } }
    //public void OnFire() { StartCoroutine(fired()); fire = true; }
    public void OnMove(InputAction.CallbackContext ctx) { Debug.Log("Work Move()"); movement_vector = ctx.ReadValue<Vector2>() * speed * Time.fixedDeltaTime; Debug.Log(movement_vector); }
}