using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("SelfDestroy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
