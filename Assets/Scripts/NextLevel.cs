using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene actualScene;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                if (actualScene.name == "Level1")
                {
                    if(FruitController.fruitScore == 1)
                    {
                        SCManager.instance.LoadScene("Level2");
                    }
                   
                }else if (actualScene.name == "Level2")
                {
                    if(FruitController.fruitScore == 2)
                    {
                        SCManager.instance.LoadScene("Level3");
                    }
                    
                }else if (actualScene.name == "Level3")
                {
                    if (FruitController.fruitScore == 6)
                    {
                        AudioManager.instance.musicSource.Stop();
                        SCManager.instance.LoadScene("EndVictory");
                    }
                }


            }
        }
    }
}
