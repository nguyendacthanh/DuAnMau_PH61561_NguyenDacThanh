using UnityEngine;

public class CheckLost_1 : MonoBehaviour
{
    public GameObject losePanel;


    void Update()
    {
        CheckMainCharacter();
    }

    private void CheckMainCharacter()
    {

        GameObject mainCharacter = GameObject.FindGameObjectWithTag("main");


        if (mainCharacter == null)
        {
            LostGame();
        }
    }
    private void LostGame()
    {

        if (losePanel != null)
        {
            losePanel.SetActive(true); // Hiển thị panel thua
        }

    }
}
