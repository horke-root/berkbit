using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenYoutubeBackground() { Application.OpenURL("https://www.youtube.com/@AstroPixel"); }

    public void OpenURL(string link) { Application.OpenURL(link); }
}
