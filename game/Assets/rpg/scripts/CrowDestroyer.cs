using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowDestroyer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
    }
}
