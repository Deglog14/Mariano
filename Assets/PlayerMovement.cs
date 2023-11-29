using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //para llamar a la caja que compone el cuerpo
    private Rigidbody2D rb;
    //para llamar a la Animación
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX=0f;
    //SerializeField sirve para mostrar en unity  un cuadro con los valores pa cambiar rapido
    [SerializeField]private float moveSpeed = 8f;
    [SerializeField]private float jumpforce = 14f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite =GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity =new Vector2 (dirX * moveSpeed, rb.velocity.y);


       if(Input.GetButtonDown("Jump")) 
       {
        rb.velocity =new Vector2(rb.velocity.x, jumpforce);
       }
        
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        //Este if es para saber cuando tiene que cambiar el bull de Run
       if(dirX > 0f)
       {
            anim.SetBool("Run", true);
            //Cambiamos donde se renderiza el sprite la direcion
            sprite.flipX = false ;
       }
       else if(dirX < 0f)
       {
            anim.SetBool("Run", true);
            sprite.flipX = true;
       }
       else
       {
            anim.SetBool("Run", false);
       }
    }
}
