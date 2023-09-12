using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlsEnabler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mobileControls") == 1) { gameObject.active = true; }
        else if (PlayerPrefs.GetInt("mobileControls") == 0) { gameObject.active = false; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
