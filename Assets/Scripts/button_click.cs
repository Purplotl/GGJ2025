using UnityEngine;
using UnityEngine.SceneManagement;
using Player.Movement;

public class button_click : MonoBehaviour
{
    public void StartGame()
    {
        player_health.dead = false;
        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
