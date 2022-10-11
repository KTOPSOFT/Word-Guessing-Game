using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomImageSelector : MonoBehaviour
{
    public string language = "English";

    public GameManager gameManager;
    public Sprite[] sprites;
    Image thisImage;
    // Start is called before the first frame update

    private void Awake()
    {
        language = PlayerPrefs.GetString("Language");
    }

    void OnEnable()
    {
        thisImage = GetComponent<Image>();
        sprites = Resources.LoadAll<Sprite>("ClientAssets/Item Images/"+language);
        thisImage.sprite = sprites[Random.Range(0, sprites.Length-1)];
        gameObject.name = thisImage.sprite.name;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        StartCoroutine(DoubleCheck());
    }

    IEnumerator DoubleCheck()
    {
        bool unique = false;
        while (!unique)
        {
            unique = true;
            foreach (GameObject gameObj in gameManager.buttons)
            {

                if (gameObj.name == gameObject.name && gameObj != gameObject)
                {
                    thisImage.sprite = sprites[Random.Range(0, sprites.Length - 1)];
                    gameObject.name = thisImage.sprite.name;
                    unique = false;
                }
            }
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
    
}
