using System.Collections;
using System.Collections.Generic;
using _Game.Manager;
using TMPro;
using UnityEngine;
using _Game.Utils;
namespace _Game._UI
{
    //Controls the UI elements for the finish panel.
    public class FinishUI : MonoBehaviourSingleton<FinishUI>, IUIView
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private TextMeshProUGUI scoreTxt;
        //Initializes the finish panel UI.
        public void Init()
        {
            canvas.gameObject.SetActive(true);
            Hide();
        }
        //Shows the finish panel UI.
        public void Show()
        {
            scoreTxt.text = "Score : " + (GameManager.Instance.IsPlayerDetectedByEnemies ? "2" : "3");
            canvas.enabled = true;

        }
        //Hide the finish panel UI.
        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}
