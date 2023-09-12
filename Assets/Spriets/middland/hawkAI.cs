using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hawkAI : MonoBehaviour
{
    public Camera camera;
    public GameObject gutsmini;
    private bool hawk_go = true;
    private bool miniguts_go = false;
    private bool minihawk_go = true;
    private bool casca_go = false;
    public GameObject cut1;
    public GameObject cut2;
    public GameObject cut3;
    public GameObject cut4;
    public GameObject cut5;
    public GameObject casca;

    public GameObject tobject;
    private Dialogue dialogue;

    public AudioClip cascaLaugh;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = tobject.GetComponent<Dialogue>();
        source = GetComponent<AudioSource>();
        StartCoroutine(AI());
    }

    // Update is called once per frame
    void Update()
    {
        if (hawk_go) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1.80f, transform.position.z), 0.001f);}
        if (minihawk_go) { gutsmini.transform.localPosition = Vector3.MoveTowards(gutsmini.transform.localPosition, new Vector3(-0.18f, 1.64f, gutsmini.transform.localPosition.z), 0.0003f); }
        if (miniguts_go) { gutsmini.transform.localPosition = Vector3.MoveTowards(gutsmini.transform.localPosition, new Vector3(0f, -2, gutsmini.transform.localPosition.z), 0.0005f); }
        if (casca_go) { casca.transform.position = Vector3.MoveTowards(casca.transform.position, new Vector3(casca.transform.position.x, -1.8f, casca.transform.position.z), Time.deltaTime*0.2f); }
    }

    IEnumerator AI() { camera.transform.position = new Vector3(12, camera.transform.position.y, camera.transform.position.z);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(6);
        gutsmini.transform.localScale = new Vector3(gutsmini.transform.localScale.x+0.5f, gutsmini.transform.localScale.y + 0.5f, gutsmini.transform.localScale.z);
        minihawk_go = false;
        gutsmini.transform.localPosition = new Vector3(-0.30f, gutsmini.transform.localPosition.y, gutsmini.transform.localPosition.z);
        miniguts_go = true;
        yield return new WaitForSeconds(13);
        source.Stop();
        hawk_go = false;
        transform.position = new Vector3(30, transform.position.y, transform.position.z);
        cut1.transform.position = new Vector3(12, 0, cut1.transform.position.z);
        dialogue.addDialogue("   ", "OH!");
        dialogue.addDialogue("   ", "Hey, somebody's comin'!");
        dialogue.addDialogue("   ", "!");
        dialogue.startDialogue();
        while (dialogue.GetCounter() != 3)
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (dialogue.GetCounter() == 3)
        {
            dialogue.endDialogue();
            cut1.active = false;
            cut2.transform.position = new Vector3(12, 0, cut2.transform.position.z);


            dialogue.addDialogue("   ", "O! Look, it's the ");
            dialogue.addExistAndShake("GUY WHO KILLED BASUZO yesterday!!");
            dialogue.addDialogue("   ", "He's are enemy, ain't he?");
            dialogue.addDialogue("   ", "That's nothing to us now...");
            
            dialogue.addDialogue("Corkus","But I bet his ");
            
            dialogue.addExistAndShake("POCKETS are well-lined.");
            dialogue.addDialogue("Corkus", "He's got the REWARD for killin' Basuzo.");
            dialogue.addDialogue("Corkus", "What once was LOST is FOUND y'know?");
            dialogue.addDialogue("Corkus", "How about it, GRIFFITH?");
            dialogue.addDialogue("......", "...........");
            dialogue.addDialogue("Griffith", "DO AS YOU WILL.");
            dialogue.addDialogue("Corkus", "...........");

            dialogue.addDialogue("Corkus", "He-heh");
            dialogue.addDialogue("Corkus", "Alright, you guys, come with me.");
            dialogue.addDialogue("    ", "OH. To go kill him, Corkus?");

            dialogue.addDialogue("casca", "ha-ha");
            dialogue.addWithShake("corkus", "What's so funny, CASCA?");
            dialogue.addDialogue("Casca", "You aren't up to killing him, CORKUS");

            dialogue.addDialogue("corcus", "........");
            dialogue.addDialogue("corkus", "ha..we'll see about that.");
            dialogue.addDialogue("corkus", "I was plannin'on killing BASUZO ang gettin' famous MYSELF one of these days.");

            dialogue.addDialogue("Casca", "You will die.");

            dialogue.addDialogue("Corcus", "......");
            dialogue.addDialogue("Corcus", ".....Well.....");
            dialogue.addDialogue("Corcus", "...Just WATCH.");


            dialogue.startDialogue();
            while (dialogue.GetCounter() !=8)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 8) {
                cut2.active = false;
                cut3.transform.position = new Vector3(12, 0, cut3.transform.position.z);
                
            }
            while (dialogue.GetCounter() != 12)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 12)
            {
                cut3.active = false;
                cut4.transform.position = new Vector3(12, 0, cut4.transform.position.z);

            }
            while (dialogue.GetCounter() != 13)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 13)
            {
                
                cut4.transform.position = new Vector3(12.5f, 0, cut4.transform.position.z);
                cut4.transform.localScale = new Vector3(1.5f, 1.5f, cut4.transform.localScale.z);


            }
            while (dialogue.GetCounter() != 15)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 15)
            {
                
                cut4.active = false;
                cut5.transform.position = new Vector3(12, 0, cut4.transform.position.z);

            }
            while (dialogue.GetCounter() != 18)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 18)
            {
                source.clip = cascaLaugh;
                source.Play();
                

            }

            while (dialogue.GetCounter() != 19)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 19)
            {
                source.Stop();
                cut5.active = false;
                casca.transform.position = new Vector3(12, 1.1f, cut4.transform.position.z);
                casca_go = true;

            }

            while (dialogue.GetCounter() != 26)
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (dialogue.GetCounter() == 26)
            {
                casca_go = false;
                cut5.active = true;
                casca.active = false;
               

            }




        }




        } 
}
