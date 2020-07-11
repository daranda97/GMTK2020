using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_walk_animiation_walking_control : MonoBehaviour
{

 
    Animator cur_animator;
    public GameObject animated_model;


    // Start is called before the first frame update
    void Start()
    {
        cur_animator = animated_model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cur_animator.SetFloat("WalkSpeed", new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);
    }
}
