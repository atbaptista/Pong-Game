public class BSpeedBallUp : Brick
{
    public override void Hit(Player player, Ball ball)
    {
        ball.IncreaseSpeed();
        Break();
    }
}
