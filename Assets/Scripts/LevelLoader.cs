using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Button Level_1;
    public Button Level_2;
    public Button Level_3;
    public Button Level_4;
    public Button Level_5;
    public Button Level_6;
    public Button Level_7;
    public Button Level_8;
    public Button Level_9;

    public int CurrentLevelIndex;
    private string[] levelNames = new string[] { "Isle of Noob", "Mount Ego", "Frigid Forest", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9" };
    public bool[] availableLevels = new bool[] { true, false, false, false, false, false, false, false, false };

    private void Start()
    {
        instance = this;
        // on start, check to see which levels are available
        Level_1.interactable = availableLevels[0];
        Level_2.interactable = availableLevels[1];
        Level_3.interactable = availableLevels[2];
        Level_4.interactable = availableLevels[3];
        Level_5.interactable = availableLevels[4];
        Level_6.interactable = availableLevels[5];
        Level_7.interactable = availableLevels[6];
        Level_8.interactable = availableLevels[7];
        Level_9.interactable = availableLevels[8];

    }

    public void UnlockNextLevel()
    {
        print("Level unlocked!" + levelNames[CurrentLevelIndex + 1]);
        availableLevels[CurrentLevelIndex + 1] = true;
    }

    public void PlayIsleOfNoob()
    {
        SceneManager.LoadScene("IsleOfNoob");
    }
    public void PlayMountEgo()
    {
        SceneManager.LoadScene("MountEgo");
    }
}