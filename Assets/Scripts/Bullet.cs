using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCD(destroyTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DestroyCD(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
