using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    CharacterController controller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                anim.SetInteger("Move",1);
                anim.SetBool("Running",true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("Attack",2);
            anim.SetBool("Attacking",true);
        }
    }
}
