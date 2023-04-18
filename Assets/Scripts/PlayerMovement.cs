using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float rotationSpeed;
    public GameObject hitBox;
    public Health health;
    public bool inControl = true;
    public int damage;
    private bool isAttacking = false;

    public AudioSource swordSound;

    public GameObject loseScreen;
    public Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inControl) { 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetFloat("Speed", 1);
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetFloat("Speed", 1);
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetFloat("HSpeed", 1);
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetFloat("HSpeed", 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                anim.SetFloat("HSpeed", 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(Attacking());
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                pause.PauseMenu();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        }

        if (health.isDead) 
        {
            inControl = false;
            anim.SetTrigger("Dead");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            loseScreen.SetActive(true);
        }
    }


    IEnumerator Attacking()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.33f);
        hitBox.SetActive(true);
        swordSound.Play();
        yield return new WaitForSeconds(1.067f);
        hitBox.SetActive(false);
        anim.SetBool("Attack", false);
        isAttacking = false;
    }
}
