using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	[SerializeField] private bool isPlayer1Goal;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			if(!isPlayer1Goal)
			{
				Debug.Log("Player 1 Scored");
				GameObject.Find("GameManager").GetComponent<GameManager2P>().Player1Scored();
				GameObject.Find("ball").GetComponent<Ball>().Die();
			}
			else
			{
				Debug.Log("Player 2 Scored");
				GameObject.Find("GameManager").GetComponent<GameManager2P>().Player2Scored();
				GameObject.Find("ball").GetComponent<Ball>().Die();
			}
		}
	}

}
