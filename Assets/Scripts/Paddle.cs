using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] int _speed = 5;

    Rigidbody2D _rigidBody;


    private void Awake()
	{
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            _rigidBody.velocity = new Vector2(- _speed, 0);
        else if (Input.GetKey(KeyCode.D))
            _rigidBody.velocity = new Vector2( _speed, 0);
        else
            _rigidBody.velocity = new Vector2(0, 0);
    }
}
