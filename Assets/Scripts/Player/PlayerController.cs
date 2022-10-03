using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rig2d;
    public SpriteRenderer sprite;
    public Animator anim;

    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;

    protected float speed;
    public Vector2 movement;

    bool isAlive;
    public static bool armed;

    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        speed = walkSpeed;
        armed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float animSpeed = Math.Abs(movement.x) + Math.Abs(movement.y);
        anim.SetFloat("speed", animSpeed);

        if (movement.x >= 0.1f)
        {
            sprite.flipX = false;
        }
        else if (movement.x <= -0.1f)
        {
            sprite.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rig2d.MovePosition(rig2d.position + movement * speed/50);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Scythe") {
            //Do nothing
        }
        else {
            if (collision.name == "Enemy 1" || collision.name == "EnemyBullet") {
                SceneManager.LoadScene(1);
            }
            else if (collision.name == "Gun") {
                armed = true;
                Destroy(GameObject.Find("Gun"));
            }
        }
    }
}
