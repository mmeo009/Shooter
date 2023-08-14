using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotSpeed = Random.Range(10f, 100f);
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
        transform.Rotate(0, 0, this.rotSpeed * Time.deltaTime);
    }
}
