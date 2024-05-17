using UnityEngine;

public class BDamageBall : Brick
{
    public override void Hit(Player player, Ball ball)
    {
        ball.setDamage(2);
        ball.GetComponent<SpriteRenderer>().color = Color.red;
        Break();    
    }
}
