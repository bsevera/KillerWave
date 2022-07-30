using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentScene = 0;
    public static int gameLevelScene = 1;

    bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }

    static GameManager instance;
    public static GameManager Instance
    {
        get {  return instance; }
    }

    void Awake()
    {
        CheckGameManagerIsInThisScene();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        LightandCameraSetup(currentScene);
    }

    void CheckGameManagerIsInThisScene()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void LightandCameraSetup(int sceneNumber)
    {
        switch (sceneNumber)
        {
            //testlevel, level1, level2, level3
            case 3: case 4: case 5: case 6:
            {
                LightSetup();
                CameraSetup();
                break;
            }
        }
    }

    void CameraSetup()
    {

        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //camera transform
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        //camera properties
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 255);
    }

    void LightSetup()
    {
        GameObject dirLight = GameObject.Find("DirectionalLight");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Camera>().backgroundColor = new Color32(152, 204, 255, 255);
    }
}
