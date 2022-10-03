using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public GameObject[] assets;
    public float secondSpawn = 0.5f;
    public float minPos;
    public float maxPos;

    void Start()
    {
        StartCoroutine(RandomSpawn());
    }

    IEnumerator RandomSpawn() 
    {
        while (true)
        {
            var wanted = Random.Range(minPos, maxPos);
            var pos = new Vector3(wanted, transform.position.y);
            GameObject gameobject = Instantiate(assets[Random.Range(0, assets.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameobject, 5f);
        }
    }
}
