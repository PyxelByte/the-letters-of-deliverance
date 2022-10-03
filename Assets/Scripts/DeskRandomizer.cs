using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskRandomizer : MonoBehaviour
{
    public GameObject[] assets;

    void Start()
    {
        GameObject gameObject = Instantiate(assets[Random.Range(0, assets.Length)], transform);
    }
}
