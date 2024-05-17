using UnityEngine;

public class BGiveHealth : Brick
{
    public override void Hit(Player player, Ball ball)
    {
        ball.setDamage(-1);
        
        ball.GetComponent<SpriteRenderer>().color = Color.green;
        Break();    
    }
}
