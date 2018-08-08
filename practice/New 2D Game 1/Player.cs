using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Rigidbody2D _Rigidbody2D;
	public LayerMask _GLayer;
	
	public Transform _LGroundCheck;
	public Transform _RGroundCheck;

	public float Speed = 0f;
	public float Jump = 0f;
	public bool grounded = false;

	void Start(){
		_Rigidbody2D = GetComponent<Rigidbody2D>();

		_LGroundCheck = transform.Find("LGroundCheck");
		_RGroundCheck = transform.Find("RGroundCheck");

	}

	void Update(){

		grounded = Physics2D.Linecast(_LGroundCheck.transform.position, _RGroundCheck.transform.position,_GLayer);
		float x = Input.GetAxisRaw("Horizontal");
		_Rigidbody2D.velocity = new Vector2(Speed * x, _Rigidbody2D.velocity.y);

		if(Input.GetKeyDown("space") && grounded){

			_Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x,Jump);
		}

		
	}
}
