using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int _lives = 3;
    [SerializeField] TextMeshProUGUI _livesText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // how do I call these?????????
    public int GetLives()
	{
        return _lives;
	}

    public void SetLives(int lives)
	{
        _lives = lives;
	}

    public void ChangeLivesText()
	{
        _livesText.text = "x " + _lives;
	}
}
