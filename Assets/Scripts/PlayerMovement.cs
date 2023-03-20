using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("Speed", 1);
            transform.Translate(0, 0, speed * Time.deltaTime);
        } 
        else if(Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("Speed", -1);
            transform.Translate(0, 0, -speed * Time.deltaTime);
        } else
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("HSpeed", 1);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        } else if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("HSpeed", -1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            anim.SetFloat("HSpeed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        } else
        {
            anim.SetBool("Jump", false);
        }
    }
}
