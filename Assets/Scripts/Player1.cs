using UnityEngine;

public class Players : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.W))
            move = 1f;
        else if (Input.GetKey(KeyCode.S))
            move = -1f;

        rb.linearVelocity = new Vector2(0, move * speed);
    }
}
