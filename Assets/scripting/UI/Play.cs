using UnityEngine;
using UnityEngine.SceneManagement;

public class NewEmptyCSharpScript : MonoBehaviour 
{
    public string sceneName; 

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
