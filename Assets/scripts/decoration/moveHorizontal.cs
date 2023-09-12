using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHorizontal : MonoBehaviour
{
    private bool allow = true;
    private Vector3 startpos;
    private Vector3 endpos;
    public float range1; //recomend -1
    public float range2; //recomend 1
    public float timeMultiplayer = 1;
    [Header("Moving direction, random?")]
    public bool RandomRule = true;
    [Header("Rule is move direction")]
    public bool rule;
    // Start is called before the first frame update
    void Start()
    {
        if (RandomRule) { rule = Berk.RandomBool(); } 
        


        startpos = new Vector3(transform.position.x + range1, transform.position.y, transform.position.y);
        endpos = new Vector3(transform.position.x + range2, transform.position.y, transform.position.y);


    }

    // Update is called once per frame
    void Update()
    {
        if (rule == true && transform.position == startpos) { rule = false; }
        if (rule == false && transform.position == endpos) { rule = true; }

        if (rule == true) { transform.position = Vector3.MoveTowards(transform.position, startpos, Time.deltaTime * timeMultiplayer); }
        else if (rule == false) { transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * timeMultiplayer); }

    }
}
