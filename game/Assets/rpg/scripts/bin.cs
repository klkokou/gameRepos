using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bin : MonoBehaviour
{
    public bool isShacking = false;
    public float shake = .2f;
    Vector2 pos;
    SpriteRenderer sprite;
    // Start is called before the first frame update
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attackkkk"))
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
