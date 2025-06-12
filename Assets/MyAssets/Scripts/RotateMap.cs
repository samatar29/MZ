using UnityEngine;

public class RotateMap : MonoBehaviour
{

    public Rigidbody2D rb;

    public float rotationAmount = 5f;
    public float rotationSpeed = 10f;
    public float timer = 0f;
    public float interval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate every 5 seconds
        /*timer += Time.deltaTime;

        if (timer >= interval)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            rb.rotation += rotationAmount;
            timer = 0f;
        }*/

        // Rotate slowly over time
        rb.rotation += rotationSpeed * Time.deltaTime;

    }
    
}
