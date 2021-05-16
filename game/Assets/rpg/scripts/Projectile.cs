using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement stuff")]
    public float moveSpeed;
    public Vector2 directionToMove;

    [Header("Lifetime")]
    public float lifeTime;
    private float lifeTimeSeconds;
    public Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        lifeTimeSeconds = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeSeconds -= Time.deltaTime;
        if (lifeTimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVel)
    {
        myRB.velocity = initialVel * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var scale = other.gameObject.GetComponent<PolutionScale>();
        if (scale)
        {
            scale.TakeDamage(2);
        }
        Destroy(this.gameObject);
    }
}
