using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightNear : MonoBehaviour
{
    bool isShacking = false;
    float shake = .2f;
    Vector2 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShacking == true)
        {
            transform.position = pos + UnityEngine.Random.insideUnitCircle * shake;
        }
    }

    private void OnTrigger(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackEvilCrow")
        {
            isShacking = true;
            Invoke("StopShaking", .5f);
        }
    }

    void StopShaking()
    {
        isShacking = false;
        transform.position = pos;
    }
}
