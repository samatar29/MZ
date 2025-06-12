using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Level1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
