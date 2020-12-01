using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject completeLevelUI;
    public GameObject faileLevelUI;
    public LevelLoader levelLoader;
    
  
    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        //completeLevelUI.SetActive(true);

        if (PlayerPrefs.GetInt("levelReached") < SceneManager.GetActiveScene().buildIndex - 1)
        {
            //Get the active scene, + 1(das nächste Level), -2 (Menu und Level Selector zählen nicht), also -1
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (SceneManager.GetActiveScene().buildIndex != 7)
        {
            levelLoader.LevelComplete();
        } else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            levelLoader.LoadCreditsLV();
        }
        
    }

    public void EndLevel ()
    {
        // Sicherstellen, dass diese Funktion nur einmal aufgerufen wird, weil rb.position.y
        // kleiner als 100 bleibt, und es sonst jedes Frame die Funtion aufrufen würde
        if (gameHasEnded == false)
        {           
            gameHasEnded = true;
            Debug.Log("Game Over");

            //Restart level
            LevelFailed();
        }        
    }

    void LevelFailed ()
    {
        //Play Sound
        FindObjectOfType<Audio_Manager>().Play_("PlayerDeath");

        //faileLevelUI.SetActive(true);
        levelLoader.YouDied();
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     
    public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
