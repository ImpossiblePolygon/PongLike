using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Ball : MonoBehaviour
{
    private const float MAX_DISTANCE = .3f;

	[SerializeField] float _speed = 1;
	[SerializeField] float _paddleForce = .1f;
    [SerializeField] LayerMask _layerMask;

    Rigidbody2D _rigidBody;
    Vector2 _velocity;
    BoxCollider2D _collider;
	Vector2 _startPoint;

	private void Awake()
	{
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _rigidBody.freezeRotation = true;
		_startPoint = transform.position;

    }

	// Start is called before the first frame update
	void Start()
    {
        _rigidBody.gravityScale = 0;
        SetRandomDirection();

    }

    // Update is called once per frame
    void Update()
    {

    }

	private void Reset()
	{
		transform.position = _startPoint;
		SetRandomDirection();
	}

	void SetRandomDirection()
	{
        _velocity = new Vector2(Random.Range(-1f, 1f) * _speed, Random.Range(-1f, 1f) * _speed);
        _rigidBody.velocity = _velocity;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CheckForKillbox(collision);

		RaycastReflect();
        //AddPaddleForce(collision);

    }
    private void RaycastReflect()
    {
		// Pauses the game used for testing
		//Time.timeScale = 0;

		Vector2 origin = transform.position;

		Vector2 leftSide = new Vector2(origin.x - (_collider.size.x / 6), origin.y);
		Vector2 rightSide = new Vector2(origin.x + (_collider.size.x / 6), origin.y);
		Vector2 topSide = new Vector2(origin.x, origin.y + (_collider.size.y / 6));
		Vector2 bottomSide = new Vector2(origin.x, origin.y - (_collider.size.y / 6));

		//Up
		RaycastHit2D hitUpLeft = Physics2D.Raycast(leftSide, Vector2.up, MAX_DISTANCE, _layerMask);
		RaycastHit2D hitUpRight = Physics2D.Raycast(rightSide, Vector2.up, MAX_DISTANCE, _layerMask);
		Debug.DrawRay(leftSide, Vector2.up * MAX_DISTANCE, Color.red);
		Debug.DrawRay(rightSide, Vector2.up * MAX_DISTANCE, Color.red);
		//Right
		RaycastHit2D hitRightTop = Physics2D.Raycast(topSide, Vector2.right, MAX_DISTANCE, _layerMask);
		RaycastHit2D hitRightBottom = Physics2D.Raycast(bottomSide, Vector2.right, MAX_DISTANCE, _layerMask);
		Debug.DrawRay(topSide, Vector2.right * MAX_DISTANCE, Color.red);
		Debug.DrawRay(bottomSide, Vector2.right * MAX_DISTANCE, Color.red);
		//Down
		RaycastHit2D hitDownLeft = Physics2D.Raycast(leftSide, Vector2.down, MAX_DISTANCE, _layerMask);
		RaycastHit2D hitDownRight = Physics2D.Raycast(rightSide, Vector2.down, MAX_DISTANCE, _layerMask);
		Debug.DrawRay(leftSide, Vector2.down * MAX_DISTANCE, Color.red);
		Debug.DrawRay(rightSide, Vector2.down * MAX_DISTANCE, Color.red);
		//Left
		RaycastHit2D hitLeftTop = Physics2D.Raycast(topSide, Vector2.left, MAX_DISTANCE, _layerMask);
		RaycastHit2D hitLeftBottom = Physics2D.Raycast(bottomSide, Vector2.left, MAX_DISTANCE, _layerMask);
		Debug.DrawRay(topSide, Vector2.left * MAX_DISTANCE, Color.red);
		Debug.DrawRay(bottomSide, Vector2.left * MAX_DISTANCE, Color.red);


        if((hitUpLeft.collider != null || hitUpRight.collider != null)&& (hitRightTop.collider != null || hitRightBottom.collider != null)) //TopRightCorner
		{
			_rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y * (-1));
			_velocity = _rigidBody.velocity;
			Debug.Log("TopRightCorner collision");
		}
		else if ((hitUpLeft.collider != null || hitUpRight.collider != null) && (hitLeftTop.collider != null || hitLeftBottom.collider != null)) //TopLeftCorner
		{
			_rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y * (-1));
			_velocity = _rigidBody.velocity;
			Debug.Log("TopLeftCorner collision");
		}
		else if ((hitDownLeft.collider != null || hitDownRight.collider != null) && (hitLeftTop.collider != null || hitLeftBottom.collider != null)) //BottomLeftCorner
		{
			_rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y * (-1));
			_velocity = _rigidBody.velocity;
			Debug.Log("BottomLeftCorner collision");
		}
		else if ((hitDownLeft.collider != null || hitDownRight.collider != null) && (hitRightTop.collider != null || hitRightBottom.collider != null)) //BottomRightCorner
		{
			_rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y * (-1));
			_velocity = _rigidBody.velocity;
			Debug.Log("BottomRightCorner collision");
		}
		else if (hitUpLeft.collider !=null || hitUpRight.collider !=null) //top
		{
            _rigidBody.velocity = new Vector2(_velocity.x, _velocity.y * (-1));
            _velocity = _rigidBody.velocity;
            Debug.Log("Up collision");
        }
        else if (hitDownLeft.collider != null || hitDownRight.collider != null) //bottom
        {
            _rigidBody.velocity = new Vector2(_velocity.x, _velocity.y * (-1));
            _velocity = _rigidBody.velocity;
            Debug.Log("Down collision");
        }
		else if(hitRightTop.collider != null || hitRightBottom.collider != null) //right
        {
            _rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y);
            _velocity = _rigidBody.velocity;
            Debug.Log("Right collision");
        }
		else if(hitLeftTop.collider != null || hitLeftBottom.collider != null) //left
        {
            _rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y);
            _velocity = _rigidBody.velocity;
            Debug.Log("Left collision");
        }
    }

	//diabled for now
	private void AddPaddleForce(Collision2D collision)
	{
		if (collision.gameObject.tag == "Paddle")
		{
			_rigidBody.velocity = new Vector2(_velocity.x + (collision.rigidbody.velocity.x), _velocity.y + (_velocity.y * _paddleForce));
			_velocity = _rigidBody.velocity;
			Debug.Log("Hit Paddle: Increasing Speed");
		}
	}

	private void CheckForKillbox(Collision2D hit)
	{
		if (hit.gameObject.CompareTag("Killbox"))
		{
			//CheckForLives()
			
			Destroy(gameObject);
		}
	}

	private void CheckForLives()
	{
		//Impliment
	}



	//Old try at reflection
	//problem calulating based on origin of rectangles

	//void Reflect(Collision2D collision)
	//{
	//
	//
	//    //ball sides
	//    float ballTop =       transform.position.y + _collider.size.y/2;
	//    float ballBottom =    transform.position.y - _collider.size.y/2;
	//                                                                 
	//    float ballRight =     transform.position.x + _collider.size.x/2;
	//    float ballLeft =      transform.position.x - _collider.size.x/2;
	//
	//
	//
	//
	//    //contact point
	//    ContactPoint2D contact = collision.GetContact(0);
	//    float contactPointx = contact.point.x;
	//    float contactPointy = contact.point.y;
	//    Debug.Log(contactPointx + "," + contactPointy);
	//    Debug.Log("ballTop:" + ballTop);
	//    Debug.Log("ballBottom:" + ballBottom);
	//    Debug.Log("ballRight:" + ballRight);
	//    Debug.Log("ballLeft:" + ballLeft);
	//
	//
	//    if (Ceiling(contactPointy) == Ceiling(ballTop))
	//    {
	//        //Top collision
	//        _rigidBody.velocity = new Vector2(_velocity.x, _velocity.y * (-1));
	//        Debug.Log("Top collision");
	//    }
	//    else if (Floor(contactPointy) == Floor(ballBottom))
	//    {
	//        //bottom collision
	//        _rigidBody.velocity = new Vector2(_velocity.x, _velocity.y * (-1));
	//        Debug.Log("Bottom collision");
	//    }
	//    else if (Floor(contactPointx) == Floor(ballLeft))
	//    {
	//        //Left collision
	//        _rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y);
	//        Debug.Log("Left collision");
	//    }
	//    else if (Ceiling(contactPointx) == Ceiling(ballRight))
	//    {
	//        //Right collision
	//        _rigidBody.velocity = new Vector2(_velocity.x * (-1), _velocity.y);
	//        Debug.Log("Right collision");
	//    }
	//
	//    _velocity = _rigidBody.velocity;
	//
	//}
}
