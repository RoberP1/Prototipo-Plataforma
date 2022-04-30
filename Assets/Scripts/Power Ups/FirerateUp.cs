using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateUp : PowerUps
{
    public override void effect()
    {
        base.effect();
        StartCoroutine(PowerUpDuration(duration));
        player.fireRate = 10;
        
    }
    public override IEnumerator PowerUpDuration(float time)
    {
        float temp = player.fireRate;
        yield return new WaitForSeconds(time);
        player.fireRate = temp;
        Destroy(gameObject);
    }

}
