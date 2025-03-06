using UnityEngine;
using UnityEngine.SceneManagement;

public class Man1 : MonoBehaviour 
{
    public GameObject panelNext,panelPrev;
    

    public void LoadScene()
    {
        panelPrev.SetActive(false);
        panelNext.SetActive(true);

    }
}
