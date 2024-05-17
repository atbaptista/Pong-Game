using UnityEngine;

public class ScoreBarrier : MonoBehaviour, IHittable
{

    [Header("Manager")]
    public GameManager manager;

    [Header("Audio")]
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip ballHit;

    public void Hit(Player player, Ball ball)
    {
        audioPlayer.PlayOneShot(ballHit);
        Destroy(ball.gameObject);
        
        if (tag == "player1")
        {
            manager.PlayerLoseLife(1, ball.GetDamage());
        }
        else
        {
            manager.PlayerLoseLife(2, ball.GetDamage());
        }
    }
}
