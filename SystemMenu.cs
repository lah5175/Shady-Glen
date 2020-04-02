using UnityEngine;
using UnityEngine.UI;

public class SystemMenu : MonoBehaviour
{
    public Button selectedButton;

    void OnEnable()
    {
        selectedButton.Select();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
