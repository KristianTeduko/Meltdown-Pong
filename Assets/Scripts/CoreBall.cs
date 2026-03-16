using Unity.VisualScripting;
using UnityEngine;

public class CoreBall : MonoBehaviour
{
    public float Speed = 1f;
    public Rigidbody2D PlayerRigidbod2D;
    public float force = 1f;

    int ballRotation;

    Vector2 movement;
    Vector2Int direction;

    int randomDirectionNumber;

    int[] directions = {40, 140, 220, 320}; // table for the ball directions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartRandomBallMovement();
        
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


    private int lastDirection = -1;

    public void RandomBallMovement()
    {
        int newDirection;

        // reroll until direction is different from last
        do
        {
            newDirection = Random.Range(0, directions.Length);
        }
        while (newDirection == lastDirection);

        lastDirection = newDirection;

        ballRotation = directions[newDirection];

        Vector2 direction = Quaternion.Euler(0, 0, ballRotation) * Vector2.right;

        // 90° rotation
        Vector2 perpendicular = new Vector2(-direction.y, -direction.x);

        PlayerRigidbod2D.AddForce(perpendicular * Speed, ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // Only randomize on walls (optional)
        if (col.collider.CompareTag("Walls"))
        {
            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add a small random angle (degrees)
            float randomAngle = Random.Range(-12f, 12f);

            // Rotate the velocity vector
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep speed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * PlayerRigidbod2D.linearVelocity.magnitude;

            if (Mathf.Abs(PlayerRigidbod2D.linearVelocity.x) < 0.2f)
            {
                PlayerRigidbod2D.linearVelocity = new Vector2(
                    Mathf.Sign(PlayerRigidbod2D.linearVelocity.x) * 0.2f,
                    PlayerRigidbod2D.linearVelocity.y
                );
            }

        }
    }



    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        PlayerRigidbod2D.linearVelocity = PlayerRigidbod2D.linearVelocity.normalized * Speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Walls")
        {
            Debug.Log("osumaoli hyvä");
            //RandomBallMovement();

        }
    }
}
