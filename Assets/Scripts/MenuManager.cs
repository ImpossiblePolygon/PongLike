using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string _sceneForButton1;
	[SerializeField] string _sceneForButton2;
	
	public void Button1()
	{
		SceneManager.LoadScene(_sceneForButton1);
	}

	public void Button2()
	{
		SceneManager.LoadScene(_sceneForButton2);
	}

	public void QuitGame()
	{
		//wont happen in editor
		Debug.Log("Quit!");
		Application.Quit();
	}

}
