using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    [SerializeField] protected float duration;
    protected Player player;

    public virtual void effect() 
    {
        player = FindObjectOfType<Player>();
    }
    public virtual IEnumerator PowerUpDuration(float time)
    {
        yield return new WaitForSeconds(time);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect();
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
