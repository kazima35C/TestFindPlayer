using _Game.Manager;
using UnityEngine;
using _Game.Utils;
namespace _Game._Player
{
    //Controls Player
    public class PlayerController : MonoBehaviourSingleton<PlayerController>
    {
        [SerializeField] private float moveSpeed = 6;

        private Camera viewCamera;
        private Vector3 velocity;

        private void Start()
        {
            viewCamera = Camera.main;
        }

        private void Update()
        {
            if (GameManager.Instance.gameState != GameState.IsPlay) { return; }
            Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
            transform.LookAt(mousePos + Vector3.up * transform.position.y);
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        }

    }
}
