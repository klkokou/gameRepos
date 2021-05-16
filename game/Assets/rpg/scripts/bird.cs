using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class bird : Crow
{
    // private Rigidbody2D myRB;
    public GameObject projectile;
    public Animator anim;
    public Transform target;
    public float chaseRadius;
    public Transform homePosition;
    public float peckTime;
    bool flazhok = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = EnemyState.flying;
        FindTarget();
        
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
      //  direction = (target.transform.position - transform.position).normalized;
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                target.position, moveSpeed * Time.deltaTime);
            FindDirection();
        }

        if (Vector3.Distance(target.position, transform.position) == 0)
        {
            ChangeState(EnemyState.idle);
            anim.SetBool("sittingOnBin", true);

            StartCoroutine(TakeTheLitter());

            if (flazhok)
            {                
                flazhok = false;              
                FindNewTarget();
                FindDirection();
                StartCoroutine(ThrowTheLitter(target.transform.position - transform.position));
            }

            ChangeState(EnemyState.flying);
        }
    }

    void FindDirection()
    {
        if (transform.position.x <= target.transform.position.x)
        {
            anim.SetBool("MovingRight", true);
        }
        else if (transform.position.x > target.transform.position.x)
        {
            anim.SetBool("MovingRight", false);
        }
    }

    IEnumerator ThrowTheLitter(Vector3 temp)
    {
        yield return new WaitForSeconds(1);
        FindDirection();
        GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
        current.GetComponent<RubbishProjectile>().Launch(temp);
        
    }

    IEnumerator TakeTheLitter()
    {      
        ChangeState(EnemyState.pecking);
        anim.SetBool("peck", true);
        yield return new WaitForSeconds(peckTime);
        ChangeState(EnemyState.throwingLetter);
        flazhok = true;
        anim.SetBool("peck", false);
    }

    void ChangeState(EnemyState newState)
    {
        if (currentState != newState) currentState = newState;
    }

    void FindTarget()
    {
        int choseTarget = UnityEngine.Random.Range(1, 5);
        target = GameObject.FindWithTag("hitable" + choseTarget).transform;
        anim.SetBool("sittingOnBin", false);
        FindDirection();
    }

    void FindNewTarget()
    {
        int choseTarget = UnityEngine.Random.Range(6, 11);
        target = GameObject.FindWithTag("hitable" + choseTarget).transform;
        anim.SetBool("sittingOnBin", false);
        FindDirection();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attackkkk"))
        {
            FindNewTarget();
        }

        if (collision.CompareTag("forLitter")) Destroy(this.gameObject);
    }
}