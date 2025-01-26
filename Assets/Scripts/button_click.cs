using UnityEngine;
using UnityEngine.SceneManagement;

public class button_click : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
