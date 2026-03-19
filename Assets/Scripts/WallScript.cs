using UnityEngine;

public class WallScript : MonoBehaviour
{
    public AudioClip wallBounce;
    public AudioSource wallAS;

    void Start()
    {

        wallAS = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // play audio
        wallAS.PlayOneShot(wallBounce);
    }
}
