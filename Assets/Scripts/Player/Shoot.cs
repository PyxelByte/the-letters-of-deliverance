using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    bool armed;

    public Transform firepoint;
    public GameObject bullet;

    public float timeBtwShots;
    float timeLeft;

    void Start()
    {
        timeLeft = timeBtwShots;
        armed = false;
    }

    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
 
        firepoint.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);
        armed = PlayerController.armed;
        if (timeLeft <= 0) {
            if (Input.GetKeyDown(KeyCode.Mouse0) && armed) {
                timeLeft = timeBtwShots;
                ShootBullet();
            }
        }
        else {
            timeLeft -= Time.deltaTime;
        }
    }

    void ShootBullet() {
        Debug.Log("Bang!");
        Destroy(Instantiate(bullet, firepoint.position, firepoint.rotation), 0.5f);
    }
}
