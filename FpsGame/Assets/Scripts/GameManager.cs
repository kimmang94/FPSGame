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
    private PlayerMove player;
    
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
        StartCoroutine(ReadyToStart());

        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gameText.text = "GO!";

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;
    }

    private void Update()
    {
        if (player.hp <= 0)
        {
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color(255, 0, 0, 255);
            gState = GameState.GameOver;
        }
    }
}
