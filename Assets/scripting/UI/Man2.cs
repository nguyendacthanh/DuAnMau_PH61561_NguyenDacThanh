using UnityEngine;
using UnityEngine.SceneManagement;

public class Man2 : MonoBehaviour 
{
    public string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
