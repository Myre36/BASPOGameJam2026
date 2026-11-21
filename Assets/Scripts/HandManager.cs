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

    public void StartDayAction()
    {
        hands[handNumber].SetActive(true);
        startDayButton.SetActive(false);
        guessHumanButton.SetActive(true);
        guessNotHumanButton.SetActive(true);
    }

    private void DisplayNextHand()
    {
        handNumber++;

        hands[handNumber].SetActive(true);
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

        DisplayNextHand();
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

        DisplayNextHand();
    }
}
