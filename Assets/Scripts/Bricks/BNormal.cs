public class BNormal : Brick
{
    public override void Hit(Player player, Ball ball)
    {
        Break();
    }
}
