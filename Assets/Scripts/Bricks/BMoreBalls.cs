using UnityEngine;

public class BMoreBalls : Brick
{
    public GameObject ballPrefab;
    public override void Hit(Player player, Ball ball)
    {
        player.GiveBall();

        Break();    
    }
}
