using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float thrust;
    public float knockTime;
   // public float damage;

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                hit.isKinematic = false;
                Vector2 dif = hit.transform.position - transform.position;
                dif = dif.normalized * thrust;
                hit.AddForce(dif, ForceMode2D.Impulse);
                hit.isKinematic = true;
                StartCoroutine(KnockCo(hit));
            }

        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
            //enemy.GetComponent<Crow>().currentState = EnemyState.idle;
        }
    }
}
