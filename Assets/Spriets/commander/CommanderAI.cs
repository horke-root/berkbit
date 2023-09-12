using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommanderAI : MonoBehaviour
{
    public GameObject GiveObject;
    public GameObject Player;
    public Camera mainCamera;
    private Animator anim;
    public AudioClip Slap;
    public AudioClip Coins;
    private AudioSource source;
    private Dialogue dialogue;
    public TextMeshProUGUI textMesh;
    public GameObject cutscene;

   


    private int givecounter = 0;

 

    public void Give() { if (givecounter == 0) { Player.GetComponent<Player>().nomove = true;  GiveObject.active = true; givecounter++; StartCoroutine(FirstGive()); } else {  } }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        dialogue = textMesh.gameObject.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator FirstGive() {
        yield return new WaitForSeconds(1);
        anim.Play("Idle");
        GiveObject.active = false;
        dialogue.addDialogue("Commander", "You were fabulous, thought… Luck or not,To Think that a young man like you agansist that bazuso….");
        source.clip = Coins;
        source.Play();
        dialogue.addDialogue("Commander", "Count it yourself.");
        dialogue.addDialogue("Commander", "Here’s half a year’s wages and the rewards for this battle.");
        dialogue.addDialogue("Commander", "H-how now. Would you like to try seeing me officially?I wouldn’t mislead you.I’ll pay you three times what I’ve Already paid you and,If you with, even promote to SQUIRE.");
        dialogue.addDialogue("Commander", "Surely there’s never been a mere MERC the likes you?How about it ? ");
        dialogue.addWithShake("Guts", "The contracts UP today right?");
        dialogue.addWithShake("Guts", "Looks like the fighting around here’s a done ANYWAY.");
        dialogue.addWithShake("commander", "Oh no HOLD ON..");
        dialogue.addWithShake("commander", "What about status, money, and security?! Please, at least stay as my GUEST!!");
        dialogue.addWithShake("commander", "Why keep throwing yourself into dangerous battlefields??!");
        dialogue.addDialogue("Guts", "I go now");
        dialogue.startDialogue();

        while (dialogue.GetCounter() != 11)
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (dialogue.GetCounter() == 11) {
            Player.GetComponent<SpriteRenderer>().flipX = true;
            source.loop = false;
            source.Stop();
            
            yield return new WaitForSeconds(1);
            Player.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(1f);
            anim.Play("Give");
            yield return new WaitForSeconds(1f);
            Player.GetComponent<SpriteRenderer>().flipX = true;
            source.clip = Slap;
            source.Play();
            anim.Play("Idle");
            yield return new WaitForSeconds(0.5f);
            cutscene.SetActive(true);



            dialogue.addWithShake("Guts", "Don’t touch me!!");
            dialogue.addWithShake("guts", "Dont you..");
            dialogue.addExistAndShake("…EVER TOUCH ME!!");
            dialogue.addDialogue("Guts", "->FEH!<-");
            dialogue.addWithShake("Commander", "Go and die like a dog on some Battlefield then!!!".ToUpper());
            dialogue.startDialogue();

            yield return new WaitForEndOfFrame();
            while (dialogue.GetCounter() != 15)
            {
                Debug.Log("work");
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 15) { cutscene.SetActive(false); Player.GetComponent<SpriteRenderer>().flipX = false; Debug.Log("Getcounter(13)"); Player.GetComponent<Player>().MoveTo(new Vector3(Player.transform.position.x+10, Player.transform.position.y, Player.transform.position.z),0.3f); ; yield return new WaitForSeconds(12); SceneManager.LoadScene(4); }
        }
    }
}
