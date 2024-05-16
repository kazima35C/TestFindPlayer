using System.Collections;
using System.Collections.Generic;
using _Game.Utils;
using UnityEngine;


namespace _Game._UI
{
    //Controls the UI elements for the MainMenu panel.
    public class MainMenuUI : MonoBehaviourSingleton<MainMenuUI>, IUIView
    {
        [SerializeField] private Canvas canvas;
        //Initializes the MainMenu panel UI.
        public void Init()
        {
            canvas.gameObject.SetActive(true);
            FinishUI.Instance.Init();
            GameOverUI.Instance.Init();
        }
        //Hide the MainMenu panel UI.
        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}
