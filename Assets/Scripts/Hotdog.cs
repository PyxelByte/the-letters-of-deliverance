using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Hotdog : MonoBehaviour
{
    public Object hotdog;
    public Vector3 coords;
    public Transform player;
    public float time = 1f;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("AHAHAHHAHHA THE GAME IS OVER LOSER");
            StartCoroutine (Hell());
    }

    IEnumerator Hell() 
    {
        while (true)
        {
            coords.Set(Random.Range(player.position.x - 15, player.position.x + 15), Random.Range(player.position.y - 8, player.position.y + 8), 0);
            Instantiate(hotdog, coords, Quaternion.identity);
            yield return new WaitForSeconds(time);
            audio.Play(0);
        }
    }
}
