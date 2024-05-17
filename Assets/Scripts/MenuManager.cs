using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip button;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(button);
    }

    public void StartGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
