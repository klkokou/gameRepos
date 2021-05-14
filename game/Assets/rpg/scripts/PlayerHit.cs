using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 dif = enemy.transform.position - transform.position;
                dif = dif.normalized * thrust;
                enemy.AddForce(dif, ForceMode2D.Impulse);
                enemy.isKinematic = true;
                StartCoroutine(KnockCo(enemy));
            }

        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            //enemy.isKinematic = true;
            enemy.GetComponent<Crow>().currentState = EnemyState.idle;
        }
    }
}
