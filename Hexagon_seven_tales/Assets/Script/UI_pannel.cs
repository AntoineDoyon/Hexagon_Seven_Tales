using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_pannel : MonoBehaviour
{
    public Text TextIntro;
    public bool IsNextSequence;
    public GameObject MainCamera;
    public GameObject Camera1;

    // Use this for initialization
    void Start()
    {
        IsNextSequence = false;
        StartCoroutine(NextSlide());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNextSequence)
        {
            TextIntro.text = "Their first step was to gather their ally on Mars";
            Camera1.SetActive(true);
            MainCamera.SetActive(false);
            StartCoroutine(NextScene());
        }
    }


    IEnumerator NextSlide()
    {
        yield return new WaitForSeconds(4f);
        IsNextSequence = true;
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Mission1_Mars");
    }
}