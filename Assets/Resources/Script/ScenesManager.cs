using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    Scenes scenes;
    public enum Scenes
    {
        bootUp,
        title,
        shop,
        level1,
        level2,
        level3,
        gameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("testLevel");
    }

    public void ResetScene()
    {
        //close the existing scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //optional second parameter can determine the mode of the load.  If using additive, it will load the next scene alongside the current one
        //use this when you need to create a loading screen or for keeping the previous scene's settings
    }

    public void GameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
}
