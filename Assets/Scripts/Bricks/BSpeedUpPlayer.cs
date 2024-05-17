public class BSpeedUpPlayer : Brick
{
    public override void Hit(Player player, Ball ball)
    {
        player.Speed += 200;
        Break();
    }
}
