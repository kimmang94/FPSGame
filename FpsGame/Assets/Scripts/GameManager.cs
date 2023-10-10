using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private GameObject gameLabel;
    private Text gameText;
    
    public enum GameState
    {
        Ready,
        Run,
        GameOver,
    }

    public GameState gState;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    private void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "Ready...";

        gameText.color = new Color(255, 185, 0, 255);
    }
}
