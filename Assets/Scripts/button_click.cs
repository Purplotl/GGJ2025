using UnityEngine;
using UnityEngine.SceneManagement;
using Player.Movement;

public class button_click : MonoBehaviour
{
    [SerializeField] private GameObject instructions;
    public void StartGame()
    {
        player_health.dead = false;
        score.Score = 0;
        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }
}
