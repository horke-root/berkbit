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
    public GameObject cut1;
    public GameObject cut2;
    public GameObject cut3;
    public GameObject cut4;
    public GameObject cut5;
    public GameObject casca;

    public GameObject tobject;
    private Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = tobject.GetComponent<Dialogue>();
        StartCoroutine(AI());
    }

    // Update is called once per frame
    void Update()
    {
        if (hawk_go) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1.80f, transform.position.z), 0.001f);}
        if (minihawk_go) { gutsmini.transform.localPosition = Vector3.MoveTowards(gutsmini.transform.localPosition, new Vector3(-0.18f, 1.64f, gutsmini.transform.localPosition.z), 0.0003f); }
        if (miniguts_go) { gutsmini.transform.localPosition = Vector3.MoveTowards(gutsmini.transform.localPosition, new Vector3(0f, -2, gutsmini.transform.localPosition.z), 0.0005f); }
    }

    IEnumerator AI() { camera.transform.position = new Vector3(12, camera.transform.position.y, camera.transform.position.z);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(6);
        gutsmini.transform.localScale = new Vector3(gutsmini.transform.localScale.x+0.5f, gutsmini.transform.localScale.y + 0.5f, gutsmini.transform.localScale.z);
        minihawk_go = false;
        gutsmini.transform.localPosition = new Vector3(-0.30f, gutsmini.transform.localPosition.y, gutsmini.transform.localPosition.z);
        miniguts_go = true;
        yield return new WaitForSeconds(13);
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
            dialogue.addDialogue("   ", "He's and enemy, ain't he?");
            dialogue.addDialogue("   ", "That's nothing to us now...");
            
            dialogue.addDialogue("Corcus","But I bet his ");
            
            dialogue.addExistAndShake("POCKETS are well-lined.");
            dialogue.addDialogue("Corcus", "He's got the REWARD for killin' Basuzo.");
            dialogue.addDialogue("Corcus", "What once was LOST is FOUND y'know?");
            dialogue.addDialogue("Corcus", "How about it, GRIFFITH?");
            dialogue.addDialogue("......", "...........");
            dialogue.addDialogue("Griffith", "DO AS YOU WILL.");
            dialogue.addDialogue("   ", "   ");
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


;        }




        } 
}
