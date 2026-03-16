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
        randomDirectionNumber = Random.Range(0, 4);
        Debug.Log("pablo roation");
        ballRotation = directions[randomDirectionNumber]; // get random direction for the ball

        movement = new Vector2(Speed, 0).normalized;
        Debug.Log("it moves");
        Vector2 direction = Quaternion.Euler(0, 0, ballRotation) * Vector2.right; // add speed to ball
        PlayerRigidbod2D.AddForce(direction, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
