using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool isMenu;


    public RandomImageSelector imageSelector;

    public Animator memorizeAnimator;
    public Animator winAnimator;
    public Animator loseAnimator;

    public Animator transitionAnimator;
    public float transitionTime = 1;

    public TextMeshProUGUI correctText;
    public Image correctTextImage;
    public GameObject[] buttons;
    public GameObject[] memorizeObjects;
    int randomMemorize;
    int randomButton;
    string correctItem;
    public List<string> words = new List<string>();


    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!isMenu)
        {
            buttons = GameObject.FindGameObjectsWithTag("ObjectButtons");
            memorizeObjects = GameObject.FindGameObjectsWithTag("Memorize");

            words = new List<string>(new string[imageSelector.sprites.Length]);
            for (int i = 0; i < imageSelector.sprites.Length; i++)
            {
                words[i] = imageSelector.sprites[i].name;
            }

            randomButton = Random.Range(0, buttons.Length - 1);
            randomMemorize = Random.Range(0, memorizeObjects.Length - 1);

            //if (imageSelector.language == "Arabic" || imageSelector.language == "Korean" || imageSelector.language == "Chinese" || imageSelector.language == "Japanese")
            //{
            //    correctText.gameObject.SetActive(false);
            //    correctTextImage.gameObject.SetActive(true);
            //    correctTextImage.sprite = Resources.Load<Sprite>("ClientAssets/PictureWords/" + imageSelector.language + "/" + words[Random.Range(0,words.Count-1)]);

            //    buttons[randomButton].GetComponent<Image>().sprite = Resources.Load<Sprite>("ClientAssets/Item Images/" 
            //        + imageSelector.language + "/" + correctTextImage.sprite.name);
            //    buttons[randomButton].name = correctTextImage.sprite.name;

            //    memorizeObjects[randomMemorize].GetComponent<Image>().sprite = Resources.Load<Sprite>("ClientAssets/Item Images/"
            //        + imageSelector.language + "/" + correctTextImage.sprite.name);
            //    memorizeObjects[randomMemorize].name = correctTextImage.sprite.name;
            //    memorizeObjects[randomMemorize].GetComponent<MemorizeManager>().textImage.sprite = correctTextImage.sprite;
            //}
            //else
            //{
                //correctText.gameObject.SetActive(true);
                //correctTextImage.gameObject.SetActive(false);

                correctText.text = words[Random.Range(0, words.Count-1)];

                buttons[randomButton].GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("ClientAssets/Item Images/" + imageSelector.language + "/" + correctText.text);
                buttons[randomButton].name = correctText.text;

                memorizeObjects[randomMemorize].GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("ClientAssets/Item Images/" + imageSelector.language + "/" + correctText.text);
                memorizeObjects[randomMemorize].name = correctText.text;
                memorizeObjects[randomMemorize].GetComponentInChildren<TextMeshProUGUI>().text = correctText.text;
           // }  THIS COMMENTED BLOCK OF CODE WAS USED TO REPLACE THE TEXT WITH AN IMAGE OF THE WORD IN THE CHOSING SECTION OF THE GAME
            
        }
    }


    public void ButtonClick(Button btn)
    {

        if (btn.name == correctText.text || btn.name == correctTextImage.sprite.name)
        {
            winAnimator.SetTrigger("Win");
        }
        else
        {
            loseAnimator.SetTrigger("Lose");
        }
    }

    public void ReadyButton()
    {
        memorizeAnimator.SetTrigger("Slide");
    }

    public void RestartButton()
    {
        StartCoroutine(Restart());
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(Load(levelName));
    }

    public void TryAgainButton()
    {
        loseAnimator.SetTrigger("TryAgain");
    }


    IEnumerator Restart()
    {
        transitionAnimator.SetTrigger("Transition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Load(string sceneName)
    {
        transitionAnimator.SetTrigger("Transition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
