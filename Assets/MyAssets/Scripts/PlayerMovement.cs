using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public FogOfWar fogofWar;
    public Transform secundaryFogOfWar;
    public float sightDistance;
    public float checkInterval;
    public float moveSpeed;
    float SpeedX;
    float SpeedY;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CheckFogOfWar(checkInterval));
        secundaryFogOfWar.localScale = new Vector2(sightDistance, sightDistance) * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        SpeedX = Input.GetAxis("Horizontal") * moveSpeed;
        SpeedY = Input.GetAxis("Vertical") * moveSpeed;

        Vector2 movement = new Vector2(SpeedX, SpeedY);
        movement.Normalize();

        rb.linearVelocity = new Vector2(SpeedX, SpeedY);
    }

    //Fog of war
    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            fogofWar.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
