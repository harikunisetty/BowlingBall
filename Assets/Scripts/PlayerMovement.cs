using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumping=1f;
    [SerializeField] bool isJump;
    [SerializeField] float maxVelocity = 2f;
    private float xInput, yInput;

    [Header("Componet")]
    public Rigidbody2D rigidbody2D;
    void Start()
    {
        isJump = false;
          rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float forceX = 0f, forceY = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.x);

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        
        if (xInput > 0)
        {
            if (velocity < maxVelocity)
                forceX = speed * Time.fixedDeltaTime;
        }
        else if (xInput < 0)
        {
            if (velocity < maxVelocity)
                forceX = -speed * Time.fixedDeltaTime;
        }

        if (yInput > 0f)
        {
            if ( !isJump)
            {
                isJump = true;
                forceY = jumping;
            }
        }
        else
            isJump = false;

        rigidbody2D.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
       /* if (transform.position.y <-6.51)
        {
            Destroy(this.gameObject);
        }*/
    }
}
