using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class bird : Crow
{
   // private Rigidbody2D myRB;
    public Animator anim;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public float peckTime;
    public float flyAwayTime;

    // Start is called before the first frame update
    void Start()
    {
        
        //myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = EnemyState.flying;
        FindTarget();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();

    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(target.position, transform.position) == 0)
        {
            ChangeState(EnemyState.idle);
            anim.SetBool("sittingOnBin", true);
            StartCoroutine(TakeTheLitter());
          //Thread.Sleep(10);
            StartCoroutine(FlyAway());
        }
    }

    void ChangeState(EnemyState newState)
    {
        if (currentState != newState) currentState = newState;
    }

    void FindTarget()
    {
        int choseTarget = UnityEngine.Random.Range(1, 5);
        target = GameObject.FindWithTag("hitable" + choseTarget).transform;
    }

    void FindNewTarget()
    {
        int choseTarget = UnityEngine.Random.Range(6, 11);
        target = GameObject.FindWithTag("hitable" + choseTarget).transform;
        anim.SetBool("sittingOnBin", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attackkkk"))
        {
            FindNewTarget();
        }
    }

    IEnumerator TakeTheLitter()
    {
        yield return new WaitForSeconds(peckTime);
        anim.SetBool("peck", true);
        //yield return new WaitForSecondsRealTime(flyAwayTime);
        //anim.SetBool("peck", false);
        //FindNewTarget();
    }

    IEnumerator FlyAway()
    {
        yield return new WaitForSeconds(flyAwayTime);
        anim.SetBool("peck", false);

        FindNewTarget();
    }
}
