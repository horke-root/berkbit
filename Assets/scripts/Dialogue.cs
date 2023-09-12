using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI thistext;
    public List<string> dialogues;
    public List<string> profiles;
    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public GameObject back;
    public AudioClip ShakeSound;
    private AudioSource source;
    private int counter=0;
    private bool canskip = false;

    public int GetCounter() { return counter; }


    IEnumerator ITypeText(string message)
    {
        Debug.Log(counter);
        canskip = false;
        thistext.text = profiles[counter];
        message = message.Substring(profiles[counter].Length);
        source.clip = typeSound1;
        source.loop = true;
        source.Play();
        

        foreach (char letter in message.ToCharArray())
        {
            thistext.text += letter;
            
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        
        source.Stop();
        source.loop = false;
        canskip = true;

    }
    IEnumerator ITypeTextExisting(string message)
    {
        Debug.Log(counter);
        canskip = false;
        source.clip = typeSound1;
        source.Play();
        source.loop = true;
        foreach (char letter in message.ToCharArray())
        {
            thistext.text += letter;

            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        source.loop = false;
        source.Stop();
        canskip = true;

    }
    public void TypeTextExisting(string imessage) { StartCoroutine(ITypeTextExisting(imessage)); }
    public void TypeText(string imessage) { StartCoroutine(ITypeText(imessage)); }


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.clip = typeSound1;
        thistext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&thistext.enabled&&canskip) {
            endDialogue();
            if (counter <= dialogues.Count) { startDialogue(); } }
        else { }
    }

    public void startDialogue() {
        string existphase = "[exist]";
        if (back != null) { back.SetActive(true); }
        if (dialogues[counter].Substring(dialogues[counter].Length - 7) == "[shake]")
        {
            string result = dialogues[counter].Remove(dialogues[counter].Length - 7, 7);
            if (result.Substring(result.Length - existphase.Length) == "[exist]") {
                source.clip = ShakeSound;
                source.Play();
                source.loop = false;
                thistext.text += result.Remove(result.Length - existphase.Length, existphase.Length);
                Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.05f);
                
            }
            else
            {
                source.clip = ShakeSound;
                source.Play();
                source.loop = false;
                StartCoroutine(ITypeText(dialogues[counter].Remove(dialogues[counter].Length - 7, 7)));
                Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.05f);
            }
            
        } else if (dialogues[counter].Substring(dialogues[counter].Length - existphase.Length) == "[exist]") { StartCoroutine(ITypeTextExisting(dialogues[counter].Remove(dialogues[counter].Length - existphase.Length, existphase.Length))); }

        else
        { StartCoroutine(ITypeText(thistext.text = dialogues[counter])); }
        counter++; thistext.enabled = true;
        Debug.Log(dialogues[counter]);
    }

    public void addExistAndShake(string text) { dialogues.Add(text + "[exist]" + "[shake]"); profiles.Add(""); }

    public void addExistingText(string text) { dialogues.Add(text + "[exist]");profiles.Add("");  }

    public void endDialogue() { if (back != null) { back.SetActive(false); } thistext.enabled = false; }

    public void addWithShake(string profile, string text) { dialogues.Add(profile.ToUpper() + "      " + text + "[shake]"); profiles.Add(profile.ToUpper()); }

    public void addDialogue(string profile, string text) {  dialogues.Add(profile.ToUpper() + "      " + text); profiles.Add(profile.ToUpper()); }
}
