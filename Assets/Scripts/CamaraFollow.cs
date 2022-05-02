using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    void Start() => offset = transform.position - player.position;
    void Update()
    {
        Vector3 targetpos = player.position + offset;
        targetpos.z = -15;
        targetpos.y = 4;
        transform.position = targetpos;
    }
}