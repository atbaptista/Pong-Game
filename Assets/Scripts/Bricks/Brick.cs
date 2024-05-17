using UnityEngine;

public abstract class Brick : MonoBehaviour, IHittable
{   

    protected AudioSource audioSource;
    [SerializeField] protected AudioClip breakSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void Break()
    {
        audioSource.PlayOneShot(breakSound);
        Destroy(this.gameObject, 0.15f);
    }

    public virtual void Hit(Player player, Ball ball)
    {
        Break();
    }
}
