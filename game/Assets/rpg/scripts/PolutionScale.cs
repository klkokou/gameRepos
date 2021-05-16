using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PolutionScale : MonoBehaviour
{
    public float health;
    public float damage;
    Animator anim;
    public GameObject gameover;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        //TakeDamage(damage);
        CheckDamage();
        //  if (health == 0) GameOver();
        if (health == 0) gameover.SetActive(true);
    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("rubbish"))
        {
            TakeDamage(damage);
            Destroy(other);
        }

        
    }

    public void CheckDamage()
    {
        if (health == 40) anim.SetBool("TenLitters", true);
        else if (health == 30) anim.SetBool("TwentyLitters", true);
        else if (health == 20) anim.SetBool("ThirtyLitters", true);
        else if (health == 10) anim.SetBool("FortyLitters", true);
        else if (health == 0) anim.SetBool("FiftyLittters", true);
    }
    public void TakeDamage(float damage)
    {
        if (health > 0) health -= damage;
    }
}
