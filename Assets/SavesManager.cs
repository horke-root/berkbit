using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavesManager : MonoBehaviour
{

    // Start is called before the first frame update
    public TextMeshProUGUI text;
    private string Iname;
    void Start()
    {
        PlayerPrefs.SetInt("mobileControls", 0); ;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetCurrentName(string sname) { Iname = sname; }
    public void SetPrefsInt(int i) { PlayerPrefs.SetInt(Iname, i); }
    public void IntTrigger() { int curInt = PlayerPrefs.GetInt(Iname); if (curInt == 0) { PlayerPrefs.SetInt(Iname, 1); }
        else if (curInt == 1) { PlayerPrefs.SetInt(Iname, 0); }
        else { PlayerPrefs.SetInt(Iname, 0); }
        text.text = "Mobile Input = " + PlayerPrefs.GetInt(Iname).ToString();
        Debug.Log(Iname + PlayerPrefs.GetInt(Iname)); }
}
