using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class basuzuAI : MonoBehaviour
{
    public bool Basuzu_attackend = false;
    public GameObject basuzutext;

    public TextMeshProUGUI timerUI;

    private Dialogue dialogue;
    public BasuzuGriffithAI griffithAI;


    [Header("CameraShake preferences:")]
    public float duration=1;
    public float magnitude=2;

    private bool getScenary = false;
    [Header("Preferences:")]
    private Vector3 endpos;
    Animator anim;
    public TextMeshProUGUI textGame;
    public Slider bar;
    public Camera mainCamera;
    private int counterl = 0;
    public float distance = 0.5f;
    public float speed = 1;
    [Header("Player Preferences:")]
    public GameObject player;
    public float speedPlayer;
    public float destinationPlayer;

    public AudioClip startbattle;
    public AudioClip boinkAttack;
    public AudioClip deathslash;

    public GameObject end;


    public float lastTime;
    private float bpm;

    public float bpmSetting = 60f;
    
    public float winbpm;

    private int attackcounter = 0;
    private float attackblock = 0;

    public float losetimer = 5;

    private bool canwin = true;

    private bool playagain=false;
    private int winc = 0;
    private bool canlose = false;
    private bool canclicker = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = basuzutext.GetComponent<Dialogue>();
        player.GetComponent<Player>().nomove = true;
        anim = GetComponent<Animator>();
        endpos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        if (((player.GetComponent<Player>().triggerEnter == true && player.GetComponent<Player>().currentCollider.name == "clicker") || playagain ) && canclicker)
        {
            player.GetComponent<Player>().noattack = false;
            textGame.gameObject.SetActive(true);
            player.GetComponent<Player>().nomove = true;
            if (attackcounter == 0) { StartCoroutine(Lose()); }
            if (Input.GetMouseButtonDown(0))
            {
                
                attackcounter++;
                mainCamera.GetComponent<CameraShake>().Shake(0.1f,0.01f);
                Animator pl_anim=player.GetComponent<Animator>();
                if (attackcounter > Random.Range(3, 5)) { attackblock += Random.Range(0.1f, 0.3f);  }
                if (attackcounter > 3) { canlose = true; }
                pl_anim.SetBool("iswalking", false);
                pl_anim.SetBool("isattack", true);
                float currentTime = Time.time;
                float diff = currentTime - lastTime;
                lastTime = currentTime;
                bpm = (bpmSetting / diff)-attackblock;
                Debug.Log(bpm);
                bar.value = (bpm);
                
                Debug.Log("attackcounter" + attackcounter);
                Debug.Log("attackblock" + attackblock);
            }
            
        }

        if (bpm > winbpm && canwin) { if (winc == 0) { textGame.text = "Blocked!"; StartCoroutine(Win()); canwin = false; } else { textGame.text = "Win Battle!"; StartCoroutine(Win2()); canwin = false; }  }
        
        if (getScenary == true) {
            StartCoroutine(GutsWalking());
            dialogue.addDialogue("basuzu", "No one`s gonna get past me!!");
            dialogue.addDialogue("basuzu", "Anyone who wants their heads smashed in ");
            dialogue.addExistAndShake("STEP RIGHT UP!!");
            dialogue.addDialogue("    ", "Who`s can defeat him");
            dialogue.addDialogue("Guts", "How much coins?");
            dialogue.addDialogue("    ", "...Are you saying");
            dialogue.addExistAndShake(" YOU`LL defeat basuzo?");
            dialogue.addDialogue("Guts", "Ten coins.");
            dialogue.addWithShake("   ", "SEVEN gold coins!! And not one more!");
            dialogue.addDialogue("    ", " GO ");
            dialogue.startDialogue();
            getScenary = false;
        }

        if (Basuzu_attackend)
        {
            Debug.Log(endpos);
            if (counterl == 0) { anim.SetBool("walk", true); transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed); if (transform.position.x >= endpos.x) { anim.SetBool("walk", false); counterl++; Basuzu_attackend = false; Debug.Log(counterl); getScenary = true; /*StartCoroutine(Scenery());*/ } }
            else if (counterl == 1) {  }
            else { anim.SetBool("death", true); counterl++; Basuzu_attackend = false; }
        }

        
    }

    

    IEnumerator GutsWalking() {
        while (dialogue.GetCounter() != 4)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(0.5f);

        if (dialogue.GetCounter() == 4)
        {
            player.GetComponent<Player>().MoveTo(new Vector3(player.transform.position.x + destinationPlayer, player.transform.position.y, player.transform.position.y), speedPlayer);
            GetComponent<AudioSource>().clip = startbattle;
            GetComponent<AudioSource>().Play();
        }

        while (dialogue.GetCounter() != 10)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(1);

        if (dialogue.GetCounter() == 10)
        {
            player.GetComponent<Player>().attack = boinkAttack;
            dialogue.back.SetActive(false);
            dialogue.gameObject.SetActive(false);
            player.GetComponent<Player>().nomove = false;
        }

        Debug.Log("GutsWalking end");

    }

    /*IEnumerator Scenery()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Scenery() at timestamp : " + Time.time);
        
        basuzutext.text = "No one`s gonna get past me!!";

        yield return new WaitForSeconds(5);

        basuzutext.text = "Anyone who wants their heads smashed in ";

        yield return new WaitForSeconds(1);

        

        basuzutext.text = "Anyone who wants their heads smashed in STEP RIGHT UP!!";

        mainCamera.GetComponent<CameraShake>().Shake(duration, magnitude);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);



        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Scenery() at timestamp : " + Time.time);
    }*/


    IEnumerator Win2() {
        canclicker = false;
        end.active = true;
        GetComponent<AudioSource>().clip = deathslash;
        GetComponent<AudioSource>().Play();
        bar.gameObject.active = false;
        anim.Play("death");
        mainCamera.GetComponent<CameraZoom>().Zoom(new Vector3(1.50f, 1.50f, mainCamera.transform.position.z), 2);
        yield return new WaitForSeconds(0.3f);
        mainCamera.gameObject.transform.localPosition = new Vector3(1.50f, 1, mainCamera.gameObject.transform.localPosition.z);
        yield return new WaitForSeconds(10);
            
          
            
            end.active = false;
            bar.gameObject.active = true;
            canlose = false;
            
            canlose = true;
            canclicker = true;
        
            
            SceneManager.LoadScene(3);
        
        counterl++;
    }
    IEnumerator Lose() { int a = 0; while (a < losetimer) { timerUI.text = "0" + a.ToString(); a++; yield return new WaitForSeconds(1); } if (canlose) {  yield return new WaitForSeconds(6); Debug.Log(canlose); SceneManager.LoadScene(1);  } canlose = false; }
    IEnumerator Win() {
        canclicker = false;
        end.active = true;
        canlose = false;
        GetComponent<AudioSource>().clip = boinkAttack;
        GetComponent<AudioSource>().Play();
        bar.gameObject.active = false;
        
        yield return new WaitForSeconds(3);
        bpm = 0;

        griffithAI.MoveTo( new Vector3(1.50f, griffithAI.transform.position.y, griffithAI.transform.position.z), speed);

        lastTime = 0;
        attackcounter = 0;
        attackblock = 0;
        end.active = false;
        bar.gameObject.active = true;
        
        canclicker = true;
        playagain = true;
        winc++;
        counterl++;
        canwin = true;
    }
}
