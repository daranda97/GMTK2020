using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enem_wlk_enemy_wlaki_Animation_control : MonoBehaviour
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
        cur_animator.SetFloat("WalkSpeed", Mathf.Clamp(animated_model.GetComponent<NavMeshAgent>().velocity.magnitude,0,1));

        
    }
}
