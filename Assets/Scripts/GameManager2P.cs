using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager2P : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("2PlayerAI")]
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject WinText;

    public GameObject winButtons;
    //public GameObject restartButton;
    //public GameObject MainMenuButton;

    [SerializeField] int ScoreGoal = 5;
    private int Player1Score = 0;
    private int Player2Score = 0;

	private void Start()
	{
        CloseWinMenu();
    }

	public void Player1Scored()
	{
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        CheckScoreGoal();

    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        CheckScoreGoal();
    }

    private void CheckScoreGoal()
	{
        if(Player1Score == ScoreGoal)
		{
            Destroy(ball);
            Debug.Log("Player 1 Wins");
            SetWinText("1");
            OpenWinMenu();

        }
        if (Player2Score == ScoreGoal)
        {
            Destroy(ball);
            Debug.Log("Player 2 Wins");
            SetWinText("2");
            OpenWinMenu();
        }
    }

    private void SetWinText(string player)
	{
        WinText.GetComponent<TextMeshProUGUI>().text = "Player " + player + " Wins!";
    }

    private void OpenWinMenu()
	{
        WinText.SetActive(true);
        winButtons.SetActive(true);

        //restartButton.SetActive(true);
        //MainMenuButton.SetActive(true);
    }
    
    private void CloseWinMenu()
	{
        WinText.SetActive(false);
        winButtons.SetActive(false);
        //doesnt work???
        //restartButton.SetActive(false);
        //MainMenuButton.SetActive(false);
    }
}
