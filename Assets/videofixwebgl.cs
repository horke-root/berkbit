using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videofixwebgl : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "teenintro.mp4");
        videoPlayer.isLooping = true;
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
