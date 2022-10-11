using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MemorizeManager : MonoBehaviour
{
    public string language = "English";

    public GameManager gameManager;
    public Sprite[] sprites;
    Image thisImage;
    TextMeshProUGUI thisText;
    public Image textImage;
    private void Awake()
    {
        language = PlayerPrefs.GetString("Language");
    }

    private void OnEnable()
    {
        thisImage = GetComponent<Image>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        sprites = Resources.LoadAll<Sprite>("ClientAssets/Item Images/" + language);
        thisImage.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        gameObject.name = thisImage.sprite.name;

        //if (language == "Arabic" || language == "Korean" || language == "Chinese" || language == "Japanese")
        //{
        //    thisText.gameObject.SetActive(false);
        //    textImage.gameObject.SetActive(true);
        //    textImage.sprite = Resources.Load<Sprite>("ClientAssets/PictureWords/" + language + "/" + thisImage.sprite.name);
        //}
        //else
        //{
            thisText.gameObject.SetActive(true);
            thisText.text = thisImage.sprite.name;
        //} THIS COMMENTED BLOCK OF CODE WAS USED TO REPLACE THE TEXT WITH AN IMAGE OF THE WORD IN THE MEMORIZE SECTION OF THE GAME
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DoubleCheck());
    }

    IEnumerator DoubleCheck()
    {
        bool unique = false;
        while (!unique)
        {
            unique = true;
            foreach (GameObject gameObj in gameManager.memorizeObjects)
            {

                if (gameObj.name == gameObject.name && gameObj != gameObject)
                {
                    thisImage.sprite = sprites[Random.Range(0, sprites.Length - 1)];
                    gameObject.name = thisImage.sprite.name;
                    thisText.text = thisImage.sprite.name;
                    unique = false;
                }
            }
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}
