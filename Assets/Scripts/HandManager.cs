using System.Collections;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hands;

    [SerializeField]
    private bool[] goodOrWrong;

    private int handNumber = 0;

    public GameObject startDayButton;
    public GameObject startDayButtonVisual;

    public GameObject guessHumanButton;
    public GameObject guessHumanButtonVisual;
    public GameObject guessNotHumanButton;
    public GameObject guessNotHumanButtonVisual;

    public int amountWrong = 0;

    public int amountGood = 0;

    public GameObject mainLight;

    public void StartDayAction()
    {
        mainLight.SetActive(true);
        startDayButton.SetActive(false);
        startDayButtonVisual.SetActive(true);
        guessHumanButton.SetActive(true);
        guessHumanButtonVisual.SetActive(false);
        guessNotHumanButton.SetActive(true);
        guessNotHumanButtonVisual.SetActive(false);

        StartCoroutine(DisplayFirstHandWithDelay());
    }

    public void GuessHuman()
    {
        if (goodOrWrong[handNumber] == true) 
        {
            amountGood++;
        }
        else
        {
            amountWrong++;
        }

        hands[handNumber].SetActive(false);

        StartCoroutine(DisplayHandsWithDelay());
    }

    public void GuessNotHuman()
    {
        if (goodOrWrong[handNumber] == false)
        {
            amountGood++;
        }
        else
        {
            amountWrong++;
        }

        hands[handNumber].SetActive(false);

        StartCoroutine(DisplayHandsWithDelay());
    }

    IEnumerator DisplayHandsWithDelay()
    {
        yield return new WaitForSeconds(3);
        handNumber++;

        hands[handNumber].SetActive(true);
    }

    IEnumerator DisplayFirstHandWithDelay()
    {
        yield return new WaitForSeconds(3);
        hands[handNumber].SetActive(true);
    }
}
