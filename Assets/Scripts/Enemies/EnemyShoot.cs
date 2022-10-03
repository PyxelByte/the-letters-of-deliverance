using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    bool armed;

    public Transform firepoint;
    public GameObject bullet;
    public Transform player;

    public float timeBtwShots = 1f;
    float timeLeft;

    void Start() {
        timeLeft = timeBtwShots;
    }

    void Update()
    {
        firepoint.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg);
        if (timeLeft > 0) {
            //anim.SetFloat("speed", animSpeed);
            timeLeft -= Time.deltaTime;
        }
        else {
            ShootBullet();
        }
    }

    void ShootBullet() {
        timeLeft = Random.Range(1f, 2.5f);
        Destroy(Instantiate(bullet, firepoint.position, firepoint.rotation), 0.5f);
    }
}
