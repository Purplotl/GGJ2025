using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    static public int Score;

    private void Update()
    {
        text.text = ("Score: "+Score);
    }
}
