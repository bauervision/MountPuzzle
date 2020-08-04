using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Invector;

public class InteractionManager : MonoBehaviour
{

    public static InteractionManager instance;
    public GameObject[] spawnLocations;
    public GameObject spawnItem;
    public GameObject GoodieBag;
    public Text GoodieBagText;
    public GameObject canvas;
    public GameObject gameCanvas;
    public Camera gameCamera;
    public Camera uiCamera;
    public GameObject gameController;
    public Image mainItemSprite;
    public Image bonusItem1Sprite;
    public Image bonusItem2Sprite;
    public Sprite foundSprite;

    private string[] goodieBag = new[] { "Goggles", "Halo", "Radar", "Bad Knees", "Stamina", "Poisoned" };
    private string[] goodieBagDescription = new[] {
        "Goggles!\nYou have gained the ability to see the special item spawn bubbles! This can speed up your location time greatly because you now know where the item is NOT!",
        "Halo!\nDown from the heavens you will see beams of light pointing to every place the special items might be. Instead of randomly running around, you now know exactly where to look!",
        "Radar!\nLike the Halo, except you will only see one ray of light from the sky, directly where the item is!",
        "Bad Knees!\nOuch, you've injured your knees which means no jumping for you today!",
        "Stamina Meter installed!\nNot quite as young as you were, today you will have to deal with a lack of stamina, which means you can only sprint for so long before you will need to catch your breath.",
        "Poisoned!\nMovement speed has been reduced to half as you struggle to move around at all." };


    public void GrabGoodieBag()
    {
        GoodieBag.SetActive(false);

        int grabItem = Random.Range(0, goodieBag.Length);
        GoodieBagText.text = goodieBagDescription[grabItem];
    }

    public void PlayLevel()
    {
        canvas.SetActive(false);
        gameCanvas.SetActive(true);
        uiCamera.transform.gameObject.SetActive(false);
        gameCamera.transform.gameObject.SetActive(true);
        gameController.GetComponent<Invector.vGameController>().enabled = true;

    }
    private void Start()
    {
        gameCamera.transform.gameObject.SetActive(false);
        gameCanvas.SetActive(false);
        instance = this;
        SpawnItem();
        GoodieBagText.text = "";
    }

    private void SpawnItem()
    {
        int spawnPoint = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnItem, spawnLocations[spawnPoint].transform.position, Quaternion.identity);
    }

    public static void SetMainItemFound()
    {
        instance.mainItemSprite.sprite = instance.foundSprite;
    }
}
