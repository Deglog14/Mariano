using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //para llamar a la caja que compone el cuerpo
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //para llamar a la Animación
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]private LayerMask jumpableTerreno;

    private float dirX=0f;
    //SerializeField sirve para mostrar en unity  un cuadro con los valores pa cambiar rapido
    [SerializeField]private float moveSpeed = 8f;
    [SerializeField]private float jumpforce = 14f;

    private enum MovementState {idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite =GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity =new Vector2 (dirX * moveSpeed, rb.velocity.y);


        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            jumpSoundEffect.Play();
            rb.velocity =new Vector2(rb.velocity.x, jumpforce);
        }
        
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state; // Aquí declaramos una variable 'state' del tipo MovementState

        // Este bloque de código determina el estado del movimiento basado en las condiciones
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state); // Asignamos el estado al parámetro "state" en el Animator
    }

    private bool IsGrounded()
    {
        //con esto crear una caja igual que la del colider del jugador
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableTerreno);
    }
}
