﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
        Destroy(gameObject);
    }

	private void OnCollisionExit2D(Collision2D collision)
    {

        Destroy(gameObject);

    }
}
