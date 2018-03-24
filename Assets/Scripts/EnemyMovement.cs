using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D enemy;
	BoxCollider2D enemyBox;
	public bool facingRight;
	public float horizontal;
	public int enemyHealth;


	void Start () {

		horizontal = -5f;

		enemy = GetComponent<Rigidbody2D>();
		enemyBox = GetComponent<BoxCollider2D>();
		enemyHealth = 2;


	}
	void FixedUpdate () {
		//OnCollisionEnter2D(enemyBox);
		enemy.velocity = new Vector2(horizontal,0);
		if(enemyHealth<=0){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D coll){

		if(coll.gameObject.tag=="Player"){
      enemy.velocity = new Vector2(-horizontal,10);
			//enemy.velocity = new Vector2(horizontal*=-1,0);
			//Debug.Log(horizontal);
			//enemyHealth -=1;
			//enemy.velocity = new Vector2(-horizontal,0);
    }
		if(coll.gameObject.tag=="Obstacle"){
      flip();
			horizontal*=-1;
    }

	}

	void flip(){
		facingRight=!facingRight;
		Vector2 scale = transform.localScale;
		scale.x *=-1;
		transform.localScale = scale;
	}

}
