using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Manager")]
    public GameManager manager;

    [Header("Stats")]
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 200; 

    [Header("Audio")]
    public AudioClip bounce;

    private Rigidbody2D rb; 
    private Player lastPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        lastPlayer = null;    
    }

    public void StartGame(Player player)
    {
        Vector2 direction = new Vector2(Random.Range(2,6), GetRandNum());
        direction.Normalize();

        // make ball go towards other player
        if (transform.position.x > 0)
        {
            direction.x *= -1;
        }
        rb.AddForce(speed * direction);
        lastPlayer = player;
    }

    private int GetRandNum(){
        if (Random.Range(0,2) == 0)
        {
            return -1;
        }
        else 
        {
            return 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        LayerMask layer = other.gameObject.layer;
        AudioSource audioPlayer = GetComponent<AudioSource>();

        switch (LayerMask.LayerToName(layer))
        {
            case "hittable": 
                other.gameObject.GetComponent<IHittable>().Hit(lastPlayer, this);
                break;
            case "wall": 
                audioPlayer.PlayOneShot(bounce);
                break;
        }
    }

    public void SetLastPlayer(Player hitPlayer)
    {
        lastPlayer = hitPlayer;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void setDamage(int amount)
    {
        damage = amount;
    }

    public void IncreaseSpeed()
    {
        rb.AddForce(rb.velocity.normalized * 1.5f, ForceMode2D.Impulse);
    }
}
