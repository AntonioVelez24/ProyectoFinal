using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlScenes : MonoBehaviour
{
    public Button startButton;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {        
        startButton.onClick.AddListener(() => LoadGameScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.nextLevel2 == true)
            {
                SceneManager.LoadScene("Level2");
            }
            if (player.nextLevel3 == true)
            {
                SceneManager.LoadScene("Level3");
            }
            if (player.Victory == true)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
