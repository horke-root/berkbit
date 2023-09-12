using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuzuGriffithAI : MonoBehaviour
{
    public bool MovingTowards=false;
    public Animator anim;
    private float timeMulti;
    private Vector3 endpos;


    public void MoveTo(Vector3 position, float timeM) { MovingTowards = true; anim.SetBool("iswalking", true); timeMulti = timeM; endpos = position; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingTowards) { transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * timeMulti); if (transform.position.x == endpos.x) { anim.SetBool("isturn", true); MovingTowards = false; anim.SetBool("iswalking", false); anim.SetBool("isturn", true); } }


    }
}
