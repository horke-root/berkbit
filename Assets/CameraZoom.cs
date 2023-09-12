using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zoom(Vector3 mousePosition, float scaleFactor) {

        

        // change position
        
        transform.position = mousePosition;
        // do zoom
        GetComponent<Camera>().orthographicSize /= scaleFactor; // to zoom in, otherwise orthographic size *= scaleFactor
    }
}
