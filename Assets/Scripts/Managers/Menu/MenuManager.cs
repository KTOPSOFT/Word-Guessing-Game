using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    // Start is called before the first frame update
    void Start()
    {
        languageDropdown.value = PlayerPrefs.GetInt("LanguageIndex");
    }



    public void SetLanguage()
    {
        PlayerPrefs.SetInt("LanguageIndex", languageDropdown.value);
        PlayerPrefs.SetString("Language", languageDropdown.options[languageDropdown.value].text);
    }
}
