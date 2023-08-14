using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LimitedArea
{
    [Range(-8.5f, 5.5f)]
    public float area_x;
    [Range(-4.4f, 4.4f)]
    public float area_y;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 moveInput;

    public LimitedArea topLeft;
    public LimitedArea bottomRight;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Movement", moveInput.y);
        rb.velocity = moveInput * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,topLeft.area_x, bottomRight.area_x),
                                                Mathf.Clamp(transform.position.y, bottomRight.area_y, topLeft.area_y),
                                                            transform.position.z);
    }
}
