using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using _Game.Utils;

namespace _Game._UI
{
    //Controls the UI elements for the GameOver panel.
    public class GameOverUI : MonoBehaviourSingleton<GameOverUI>, IUIView
    {

        [SerializeField] private Canvas canvas;
        //Initializes the GameOver panel UI.
        public void Init()
        {
            canvas.gameObject.SetActive(true);
            Hide();
        }
        //Shows the GameOver panel UI.
        public void Show()
        {
            canvas.enabled = true;
        }
        //Hide the GameOver panel UI.
        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}
