using System.Collections;
using System.Collections.Generic;
using _Game._UI;
using _Game.Utils;
using UnityEngine;

namespace _Game.Manager
{
    //Manages game
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        private bool isPlayerDetectedByEnemies;
        public bool IsPlayerDetectedByEnemies => isPlayerDetectedByEnemies;
        public GameState gameState;

        //Inits MainMenu and Set GameState 
        void Start()
        {
            gameState = GameState.IsPlay;
            MainMenuUI.Instance.Init();
        }

        //Invoked when the player loses.
        public void GameOver()
        {
            gameState = GameState.Finish;
            GameOverUI.Instance.Show();
        }
        //Invoked when the player Win.
        public void FinishStage()
        {
            gameState = GameState.Finish;
            FinishUI.Instance.Show();
        }

        //Invoked when the player Detected By Enemy.
        public void PlayerDetected()
        {
            isPlayerDetectedByEnemies = true;
        }
    }
}

public enum GameState
{
    IsPlay,
    Finish
}