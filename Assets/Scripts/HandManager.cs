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

    public GameObject guessHumanButton;
    public GameObject guessNotHumanButton;

    public int amountWrong = 0;

    public int amountGood = 0;

    public GameObject mainLight;

    public void StartDayAction()
    {
        mainLight.SetActive(true);
        startDayButton.SetActive(false);
        guessHumanButton.SetActive(true);
        guessNotHumanButton.SetActive(true);

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
