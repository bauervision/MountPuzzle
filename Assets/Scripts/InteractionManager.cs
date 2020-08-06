using UnityEngine;
using UnityEngine.UI;


public class InteractionManager : MonoBehaviour
{

    public static InteractionManager instance;
    public GameObject[] spawnLocations;
    public GameObject spawnItem;
    public GameObject GoodieBag;
    public Text GoodieBagText;

    public Text GoodieBagUIText;
    public GameObject GoodieBagStamina;


    // canvases
    public GameObject initialCanvas;
    public GameObject gameCanvas;
    public GameObject levelCanvas;
    public GameObject finalCanvas;

    // cameras
    public Camera gameCamera;
    public Camera uiCamera;
    public GameObject gameController;


    public Image mainItemSprite;
    public Image bonusItem1Sprite;
    public Image bonusItem2Sprite;
    public Sprite foundSprite;

    public Text GemText;
    public Text CoinText;

    public Text finalTimeText;

    public Text finalCoinText;
    public Text finalGemText;
    public Text finalDeductionText;
    public Text tallyTimeText;
    public Text tallyCollectibleText;
    public Text tallyItemText;
    public Text tallyDeductionText;


    public Text finalScoreText;

    public static int finalMinutes = 0;
    public static int finalSeconds = 0;


    private string[] goodieBag = new[] { "Bag O' Nothing", "Goggles", "Halo", "Radar", "Bad Knees", "Stamina", "Poisoned" };
    private int[] goodieBagDeductions = new[] { 0, 1, 5, 10, -1, -5, -10 };

    private string[] goodieBagDescription = new[] {
        "Bag O' Nothing!\nYou enter the level with all that you came with, no help or hindrances to speak of, good luck!",
        "Goggles!\nYou have gained the ability to see the special item spawn bubbles! This can speed up your location time greatly because you now know where the item is NOT!",
        "Halo!\nDown from the heavens you will see beams of light pointing to every place the special items might be. Instead of randomly running around, you now know exactly where to look!",
        "Radar!\nLike the Halo, except you will only see one ray of light from the sky, directly where the item is!",
        "Bad Knees!\nOuch, you've injured your knees which means no jumping for you today!",
        "Stamina Meter installed!\nNot quite as young as you were, today you will have to deal with a lack of stamina, which means you can only sprint for so long before you will need to catch your breath.",
        "Poisoned!\nMovement speed has been reduced to half as you struggle to move around at all." };

    private string levelDeductionText = "None";
    private int levelDeduction = 0;
    private int levelBonusItemScore = 0;
    private int levelCoinCount = 0;
    private int levelGemCount = 0;
    private int levelTotalPoints = 0;
    private int chosenDropzoneIndex = -1;



    private void InitializeAllVariables()
    {
        levelDeductionText = "None";
        levelDeduction = 0;
        levelBonusItemScore = 0;
        levelCoinCount = 0;
        levelGemCount = 0;
        levelTotalPoints = 0;
        finalMinutes = 0;
        finalSeconds = 0;
    }

    private void InitializeGoodieBagAbilities()
    {
        GoodieBagStamina.SetActive(false);
        // hide all the dropzones
        foreach (GameObject dropzone in spawnLocations)
        {
            // hide the mesh
            dropzone.GetComponent<MeshRenderer>().enabled = false;
            // hide the halo
            dropzone.GetComponentInChildren<Light>().enabled = false;
        }
    }

    public void GrabGoodieBag()
    {
        GoodieBag.SetActive(false);

        chosenDropzoneIndex = Random.Range(0, goodieBag.Length);

        GoodieBagText.text = goodieBagDescription[chosenDropzoneIndex];
        levelDeductionText = goodieBag[chosenDropzoneIndex];
        levelDeduction = goodieBagDeductions[chosenDropzoneIndex];

        // set the game UI
        GoodieBagUIText.text = goodieBag[chosenDropzoneIndex];
        // turn off all abilities first


        // now turn on only what we plled from the bag
        switch (chosenDropzoneIndex)
        {
            case 1: // goggles = show all ghost dropzones
                {
                    foreach (GameObject dropzone in spawnLocations)
                    {
                        dropzone.GetComponent<MeshRenderer>().enabled = true;
                    }
                    break;
                }
            case 2: // halo
                {
                    foreach (GameObject dropzone in spawnLocations)
                    {
                        dropzone.GetComponentInChildren<Light>().enabled = true;
                    }
                    break;
                }
            case 3: //radar
                {
                    print("Radar" + chosenDropzoneIndex);
                    if (chosenDropzoneIndex != -1)
                    {
                        spawnLocations[chosenDropzoneIndex].GetComponentInChildren<Light>().enabled = true;
                    }

                    break;
                }
            case 4: { break; }//bad knees
            case 5: { GoodieBagStamina.SetActive(true); break; }//stamina
            case 6: { break; }//poison
            default: { break; } // bag o nothing
        }

    }

    public void PlayLevel()
    {
        initialCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        uiCamera.transform.gameObject.SetActive(false);
        gameCamera.transform.gameObject.SetActive(true);
        gameController.GetComponent<Invector.vGameController>().enabled = true;
        PuzzleTimer.StartTimer();
    }

    public void ShowLevelSelect()
    {
        levelCanvas.SetActive(true);
        initialCanvas.SetActive(false);
    }

    public void ReturnToLaunch()
    {
        levelCanvas.SetActive(false);
        initialCanvas.SetActive(true);
    }


    private void Start()
    {
        gameCamera.transform.gameObject.SetActive(false);
        gameCanvas.SetActive(false);
        finalCanvas.SetActive(false);
        levelCanvas.SetActive(false);
        instance = this;
        SpawnItem();
        GoodieBagText.text = "";
        InitializeGoodieBagAbilities();
    }

    private void SpawnItem()
    {
        int spawnPoint = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnItem, spawnLocations[spawnPoint].transform.position, Quaternion.identity);

    }

    public static void SetItemFound(int itemFound)
    {

        switch (itemFound)
        {
            // main level items
            case 0: { LevelCompleted(); break; }
            case 1: { instance.levelBonusItemScore++; instance.bonusItem1Sprite.sprite = instance.foundSprite; break; }
            case 2: { instance.levelBonusItemScore++; instance.bonusItem2Sprite.sprite = instance.foundSprite; break; }
            // collectibles
            case 3: { instance.levelCoinCount++; break; }
            case 4: { instance.levelGemCount++; break; }
            case 5: { break; }
            case 6: { break; }
            case 7: { break; }

            default: { break; }
        }

    }

    public static void LevelCompleted()
    {
        instance.mainItemSprite.sprite = instance.foundSprite;
        instance.finalCanvas.SetActive(true);
        instance.gameCanvas.SetActive(false);
        instance.gameController.GetComponent<Invector.vGameController>().enabled = false;
        instance.uiCamera.transform.gameObject.SetActive(true);
        instance.gameCamera.transform.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // perform tally calculations
        instance.CalculateLevelPoints();

        //stop timer
        PuzzleTimer.instance.finished = true;
        // unlock the next level
        LevelLoader.instance.UnlockNextLevel();
    }

    private void CalculateLevelPoints()
    {
        // coins are 1 point each, gems are 5 pts each
        int collectibleScore = levelCoinCount + (levelGemCount * 5);

        int itemScore = (levelBonusItemScore * 50) + 100; // 100 is for getting the main item

        // TODO figure out time calculation
        int timeScore = 200;

        levelTotalPoints = collectibleScore + itemScore + timeScore;

        // handle deductions
        var deductionValue = Mathf.RoundToInt(levelDeduction / 100);
        levelTotalPoints = levelTotalPoints - deductionValue;

        // set all text objects
        finalTimeText.text = "Time:" + finalMinutes + ":" + finalSeconds;
        finalCoinText.text = levelCoinCount.ToString();
        finalGemText.text = levelGemCount.ToString();
        finalDeductionText.text = levelDeductionText;

        tallyTimeText.text = timeScore.ToString() + "pts!";
        tallyCollectibleText.text = collectibleScore.ToString() + "pts!";
        tallyItemText.text = itemScore.ToString() + "pts!";
        tallyDeductionText.text = levelDeduction.ToString() + "% = " + deductionValue.ToString() + "pts!";

        // finally set the total score
        finalScoreText.text = "Total: " + levelTotalPoints.ToString();

    }

    private void Update()
    {
        GemText.text = instance.levelGemCount.ToString();
        CoinText.text = instance.levelCoinCount.ToString();
    }

}
