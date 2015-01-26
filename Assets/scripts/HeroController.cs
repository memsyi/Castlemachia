using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	private float speedHero=15f;
	private bool flipright=true;
	private float moves=0;
	Animator animator;

	public float SpeedHero {
		get {
			return speedHero;
		}
		set {
			speedHero = value;
		}
	}



	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		animator.SetFloat("walk",Mathf.Abs(countMoves()));
		rigidbody2D.velocity = new Vector2 (countMoves() * SpeedHero,rigidbody2D.velocity.y);
		if (moves > 0 && !flipright)
						Flip ();
				else
			if (moves < 0 && flipright)
						Flip ();
	}

	float countMoves()
	{
		moves= Input.GetAxis ("Horizontal");
		return moves;
	}

	void Flip()
	{
		flipright = false;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;   

	}
}
