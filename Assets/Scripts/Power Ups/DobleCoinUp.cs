using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleCoinUp : PowerUps
{
    public override void effect()
    {
        base.effect();
        StartCoroutine(PowerUpDuration(duration));
        player.addcoin *= 2;
        
    }
    public override IEnumerator PowerUpDuration(float time)
    {
        yield return new WaitForSeconds(time);
        player.addcoin /= 2;
        Destroy(gameObject);
    }

}
