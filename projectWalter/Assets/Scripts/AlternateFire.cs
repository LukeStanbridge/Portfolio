using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateFire : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed; // Gives bullet rigidbody velociy
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
