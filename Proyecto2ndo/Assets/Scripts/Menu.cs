using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool IsOption = false;
    public bool IsCredit = false;
    public bool IsPlay = false;
    public GameObject optionMenu;
    public GameObject creditMenu;
    public GameObject playMenu;
    private KeyCode leaveKey = KeyCode.Escape;

    [SerializeField] Slider sliderVolume;


    // Start is called before the first frame update
    void Start()
    {
        optionMenu.SetActive(false);
        creditMenu.SetActive(false);
        playMenu.SetActive(false);
    }

    private void Update()
    {
        if(IsOption)
        {
            if(Input.GetKeyDown(leaveKey))
            {
                IsOption = false;
                optionMenu.SetActive(false);
            }
        }
        if(IsCredit)
        {
            if(Input.GetKeyDown(leaveKey))
            {
                IsCredit = false;
                creditMenu.SetActive(false);
            }
        }

        if(IsPlay)
        {
            if(Input.GetKeyDown(leaveKey))
            {
                IsPlay = false;
                playMenu.SetActive(false);
            }
        }
    }

    public void Play()
    {
        playMenu.SetActive(true);
        IsPlay = true;
    }

    public void PlayTuto()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ExitPlay()
    {
        playMenu?.SetActive(false);
        IsPlay = false;
    }

    public void Options(GameObject idk)
    {
        optionMenu.SetActive(true);
        IsOption = true;
    }

    public void Credits()
    {
        creditMenu.SetActive(true);
        IsCredit = true;
    }
    public void exitCredits()
    {
        creditMenu.SetActive(false);
        IsCredit=false;
    }

    public void exitOptions()
    {
        optionMenu.SetActive(false);
        IsOption =false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = sliderVolume.value;
    }
}
