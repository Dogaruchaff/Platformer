using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    public LayerMask yerLayer;
    public LayerMask duvarLayer;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private BoxCollider2D boxcollider;



    private void Awake()
     {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    
    }

    private void Update() 
    {
        float horizontalinput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalinput*speed,body.velocity.y);
        
        ///flip player left or right

        if(horizontalinput>0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput<0f)
            transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.Space) && İsgrounded())
            Jump();

        ///set animator parameters
        anim.SetBool("run",horizontalinput != 0);
        anim.SetBool("grounded", İsgrounded());
        print(onwall());

    }
    
    private void Jump() 
    {
        body.velocity = new Vector2(body.velocity.x,speed);
        anim.SetTrigger("jump");
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

    }
    

    private bool İsgrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,Vector2.down,0.01f,yerLayer);
        return raycastHit.collider != null;
}
     private bool onwall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,new Vector2(transform.localScale.x,0),0.05f,duvarLayer);
        return raycastHit.collider != null;
}
}
    


