using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scythe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
            {
            Debug.Log("killem!");
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.name == "Old man")
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
