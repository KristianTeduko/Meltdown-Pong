using Unity.VisualScripting;
using UnityEngine;

public class CoreBallNoRespawn : MonoBehaviour
{
    public float Speed = 1f;
    public Rigidbody2D PlayerRigidbod2D;
    public float force = 1f;

    GameController gameController;

    public CoreRespawner coreRespawner;
    public LifeSystem lifeSystem;

    // audio
    public AudioClip ballBounce;
    public AudioSource ballAS;

    int ballRotation;

    Vector2 movement;
    Vector2Int direction;

    int randomDirectionNumber;

    int[] directions = { 40, 140, 220, 320 }; // table for the ball directions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
        coreRespawner = FindFirstObjectByType<CoreRespawner>();
        lifeSystem = FindFirstObjectByType<LifeSystem>();
        ballAS = GetComponent<AudioSource>();
        Invoke("StartRandomBallMovement", 1);

    }


    public void StartRandomBallMovement()
    {
        randomDirectionNumber = Random.Range(0, 4);
        Debug.Log("pablo roation");
        ballRotation = directions[randomDirectionNumber]; // get random direction for the ball

        movement = new Vector2(Speed, 0).normalized;

        Debug.Log("it moves");

        Vector2 direction = Quaternion.Euler(0, 0, ballRotation) * Vector2.right; // add speed to ball
        PlayerRigidbod2D.AddForce(direction, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only randomize on walls (optional)
        if (collision.collider.CompareTag("Walls"))
        {
            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add a small random angle (degrees)
            float randomAngle = Random.Range(-10f, 30f);

            // Rotate the velocity vector
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep speed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * PlayerRigidbod2D.linearVelocity.magnitude;

        }
        if (collision.transform.tag == "Walls")
        {
            Debug.Log("osumaoli hyvä");
        }
        if (collision.collider.CompareTag("CoreBall"))
        {
            ballAS.PlayOneShot(ballBounce);
        }

        if (collision.transform.tag == "KillZone")
        {
            Debug.Log("osumaoli hyväFREEZEDOWN");
            lifeSystem.LoseTwoLifes();
            lifeSystem.NoLifesCheckFreezedown();
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 0);
        }

        if (collision.transform.tag == "KillZone2")
        {
            Debug.Log("osumaoli hyväMELTDOWN");
            lifeSystem.LoseTwoLifes();
            lifeSystem.NoLifesCheckMeltdown();
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 0);

        }
    }



    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        PlayerRigidbod2D.linearVelocity = PlayerRigidbod2D.linearVelocity.normalized * Speed; // MAKE SURE THE BALL MOVES AT A CONSTANT SPEED
    }

}
