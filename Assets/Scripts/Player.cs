using UnityEngine;

public class Player : MonoBehaviour, IHittable
{
    [Header("Paddle Stats")]
    public float Speed; 

    [Header("Controls")]
    public KeyCode up;
    public KeyCode down;
    public KeyCode sendBall;

    [Header("Ball and Sound")]
    public GameObject ballPrefab;
    [SerializeField] private AudioClip bounce;
   
    private Rigidbody2D rb;
    private AudioSource audioSource;
    
    private bool controllingBall;
    private int numBalls;
    private float nextBallTime;

    private Rigidbody2D starterBallRb;

    void Start()
    {   
        // ball logic
        nextBallTime = 0;
        numBalls = 1;

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        RespawnBall();
    }

    void Update()
    {
        if (numBalls > 0 && !controllingBall && Time.time >= nextBallTime)
        {
            RespawnBall();
            return;
        }

        MovePaddle();
        SendBall();
    }

    public void Hit(Player player, Ball ball)
    {
        audioSource.PlayOneShot(bounce);
        ball.SetLastPlayer(this);
    }

    private void RespawnBall()
    {
        numBalls--;
        controllingBall = true;
        GameObject spawnedBall = Instantiate(ballPrefab, this.transform.position, this.transform.rotation);

        // place pong slightly in front of paddle
        float offset = transform.position.x < 0 ? 0.5f : -0.5f;
        spawnedBall.transform.SetLocalPositionAndRotation(new Vector2(transform.position.x + offset, transform.position.y), transform.rotation);
        
        // for moving the ball with the paddle
        starterBallRb = spawnedBall.GetComponent<Rigidbody2D>();
        starterBallRb.mass = rb.mass;
        starterBallRb.drag = rb.drag;
    }

    public void GiveBall()
    {
        numBalls++;
    }

    private void MovePaddle()
    {
        // move up
        if (Input.GetKey(up))
        {
            rb.AddForce(Time.deltaTime * Speed * Vector2.up);
            if (controllingBall)
            {
                starterBallRb.AddForce(Time.deltaTime * Speed * Vector2.up);
            }
        }
        // move down
        else if (Input.GetKey(down))
        {
            rb.AddForce(Time.deltaTime * Speed * Vector2.down);
            if (controllingBall)
            {
                starterBallRb.AddForce(Time.deltaTime * Speed * Vector2.down);
            }
        } 
    }

    private void SendBall()
    {
        if (!Input.GetKeyDown(sendBall))
        {
            return;
        } 
        if (!controllingBall)
        {
            return;
        }
        
        // set ball rb back to normal values
        starterBallRb.mass = 1;
        starterBallRb.drag = 0;
        starterBallRb.GetComponent<Ball>().StartGame(this);
        controllingBall = false;
        nextBallTime = Time.time + 0.2f;
    }
}
