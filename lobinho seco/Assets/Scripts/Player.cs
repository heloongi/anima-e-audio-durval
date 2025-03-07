using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;
    private bool isAttacking;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
{
    if (Input.GetButtonDown("Jump") && !isJumping)
    {
        StartCoroutine(PerformJump());
    }
}

    IEnumerator PerformJump()
{
    anim.SetBool("jump", true); // Ativa a animação de pulo (incluindo a preparação)
    
    yield return new WaitForSeconds(2.3f); // Espera a animação de preparação terminar

    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); // Executa o pulo real
    isJumping = true;
}

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isJumping = false;
        anim.SetBool("jump", false);
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isJumping = true;
    }
}

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
