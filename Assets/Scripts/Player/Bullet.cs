using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LayerMask enemy;
    public LayerMask wall;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] target = Physics2D.OverlapCircleAll(rb.transform.position, 0.5f, enemy);
        Collider2D[] debris = Physics2D.OverlapCircleAll(rb.transform.position, 0.5f, wall);
        for (int i = 0; i < target.Length; i++) {
            if (target[i].gameObject.name != "Death") Destroy(target[i].gameObject);
            else if (target[i].gameObject.name == "Death") SceneManager.LoadScene(1);
        }
        if (debris.Length > 0) {
            Destroy(rb.gameObject);
        }
    }
}
