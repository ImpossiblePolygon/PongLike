using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string _playSolo;
	[SerializeField] string _playVersus;
	
	public void PlaySolo ()
	{
		SceneManager.LoadScene(_playSolo);
	}

	public void PlayVersus()
	{
		SceneManager.LoadScene(_playVersus);
	}

	public void QuitGame()
	{
		//wont happen in editor
		Debug.Log("Quit!");
		Application.Quit();
	}
}
