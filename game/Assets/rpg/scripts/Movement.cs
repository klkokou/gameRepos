using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack
}
public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 change;
    public float speed;
    public PlayerState currentState;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = PlayerState.walk;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        else if (currentState == PlayerState.walk) UpdateAnimationAndMove();

    }

    IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }


    //private void OnTriggerEnter2d(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("enemy"))
    //    {
    //        Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
    //        if (enemy != null)
    //        {
    //            enemy.isKinematic = false;
    //            Vector2 dif = enemy.transform.position - transform.position;
    //            dif = dif.normalized * thrust;
    //            enemy.AddForce(dif, ForceMode2D.Impulse);
    //            enemy.isKinematic = true;
    //        }
    //    }
    //}
}
