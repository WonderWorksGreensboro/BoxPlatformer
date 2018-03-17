//from my computer

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

  public Rigidbody2D rb;
  public float horizontal;
  public float vertical;
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;
  public int playerHealth;
  Animator animation;
  private bool facingRight;
  private bool onGround;

  void Start(){
    rb=GetComponent<Rigidbody2D>();
    animation=GetComponent<Animator>();
    facingRight=true;
    onGround = true;
    playerHealth = 2;
  }

  void FixedUpdate (){

    //Debug.Log("onGround is "+onGround);
    Debug.Log("Movement in Y direction: "+rb.velocity.y);
    //Debug.Log("health"+playerHealth);
    Debug.Log("onGround"+onGround);

    if(playerHealth <=0){
      Application.LoadLevel(Application.loadedLevel);
    }


    if(Input.GetKey("a")){
      if(facingRight){
        flip();
      }
      //Debug.Log("Moving Left.");
      horizontal = -20f;                                // Make player move left
      if(Input.GetKey("w")&& onGround == true){
        vertical = 150f;                                // Allow jump while moving
      }else{vertical=-10f;}
      animation.SetFloat("speed",20);
    }
    else if(Input.GetKey("d")){
      if(!facingRight){
        flip();
      }else{vertical=-10f;}
      //Debug.Log("Moving Right.");
      horizontal = 20f;                                 // Make player move right
      if(Input.GetKey("w")&& onGround == true){
        vertical = 150f;                                // Allow jump while moving
      }
      animation.SetFloat("speed",20);
    }
    else if(Input.GetKeyDown("w")&& onGround == true){  // Jump if the player is on a ground
      //Debug.Log("Jump!");
      //rb.AddForce(transform.up*force);
      vertical = 150f;
      //animation.SetBool("jumped",true);

    }
    else if(Input.GetKey("space")){
      Debug.Log("Attack!");
    }
    else{
      animation.SetFloat("speed",0);
      //animation.SetBool("jumped",false);
      horizontal =0f;
      vertical = -10f;
    }


    rb.velocity = new Vector2(horizontal,vertical);
    //Debug.Log("horizontal is: "+horizontal+" vertical is: "+vertical);

  }



  void OnCollisionEnter2D(Collision2D coll){
    if(coll.gameObject.tag=="ground"){                    //Checks if player is on the ground
      //Debug.Log("OnASurface");
      onGround = true;
      animation.SetBool("jumped",false);
    }
    if(coll.gameObject.tag=="Enemy"){

      animation.SetBool("EnemyCollision",true);
      playerHealth -= 1;


    }
  }
  void OnCollisionExit2D(Collision2D coll){
    if(coll.gameObject.tag=="ground"){                 //Checks if the player is in the air
      //Debug.Log("PlayeAirBorne");
      onGround= false;
      animation.SetBool("jumped",true);
    }
    animation.SetBool("EnemyCollision",false);


  }


  void flip()
  {
		facingRight=!facingRight;
		Vector2 scale = transform.localScale;
		scale.x *=-1;
		transform.localScale = scale;
	}

}
