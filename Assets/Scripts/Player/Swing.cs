using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swing : MonoBehaviour
{
    public Transform weapon;
    public Transform player;
    public SpriteRenderer sprite;
    public Animator anim;
    public LayerMask enemy;

    float timeBeforeAttack;
    public float waitTime;

    void Start() {
        enemy = GetComponent<LayerMask>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timeBeforeAttack > 0) {
            timeBeforeAttack -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (timeBeforeAttack <= 0) {
                Attack();
                timeBeforeAttack = waitTime;
            }
        }
    }

    void Attack() {
        Transform scythe = Instantiate(weapon, player.position, player.rotation);
        scythe.transform.parent = player.gameObject.transform;
        Collider2D[] target = Physics2D.OverlapCircleAll(player.position, 1.5f, enemy);
        for (int i = 0; i < target.Length; i++) {
            Debug.Log(target[i].gameObject.name);
            if (target[i].gameObject.name == "Old man") {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                Destroy(target[i].gameObject);
            }
        }
    }
}
