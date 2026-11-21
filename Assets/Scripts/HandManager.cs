using System.Collections;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    [SerializeField] 
    private GameManager gameManager;
    
    //A refrence to the hands that are displayed through the day
    [SerializeField]
    private GameObject[] hands;

    //A list of bools for if the cooresponding hands in the other array
    [SerializeField]
    private bool[] goodOrWrong;

    //The current hand number
    private int handNumber = 0;

    //The light switch
    public GameObject startDayButton;
    public GameObject startDayButtonVisual;

    //The buttons for guessing
    public GameObject guessHumanButton;
    public GameObject guessHumanButtonVisual;
    public GameObject guessNotHumanButton;
    public GameObject guessNotHumanButtonVisual;

    private bool buttonsCanBePressed = default;
    

    //How many wrong guesses you've made
    public int amountWrong = 0;

    //Amount of right guesses you've made
    public int amountGood = 0;

    //Refrence to the light in the window
    public GameObject mainLight;

    //Refrence to the bloodsplatters
    public GameObject bloodOne;
    public GameObject bloodTwo;
    public GameObject bloodThree;

    //The start of day action
    public void StartDayAction()
    {
        //Enables a bunch of the buttons and sprites
        mainLight.SetActive(true);
        startDayButton.SetActive(false);
        startDayButtonVisual.SetActive(true);
        guessHumanButton.SetActive(true);
        guessHumanButtonVisual.SetActive(false);
        guessNotHumanButton.SetActive(true);
        guessNotHumanButtonVisual.SetActive(false);

        //Starts the couroutine that makes the hand appear
        StartCoroutine(DisplayFirstHandWithDelay());
    }

    //The method for guessing that the hand is human
    public void GuessHuman()
    {
        if (buttonsCanBePressed == true)
        {


            if (goodOrWrong[handNumber] == true)
            {
                amountGood++;
            }
            else
            {
                BloodSplatter();
                amountWrong++;
            }

            hands[handNumber].SetActive(false);
            buttonsCanBePressed = false;

            StartCoroutine(DisplayHandsWithDelay());
        }
    }

    //Method for guessing that someone is not human
    public void GuessNotHuman()
    {
        if (buttonsCanBePressed == true)
        {
            if (goodOrWrong[handNumber] == false)
            {
                amountGood++;
            }
            else
            {
                BloodSplatter();
                amountWrong++;
            }

            hands[handNumber].SetActive(false);
            buttonsCanBePressed = false;

            StartCoroutine(DisplayHandsWithDelay());
        }
    }

    //Couroutine for displaying the first hand
    IEnumerator DisplayHandsWithDelay()
    {
        
        yield return new WaitForSeconds(3);
        handNumber++;
        hands[handNumber].SetActive(true);
        buttonsCanBePressed = true;
    }

    //Cououtine for going to the next game
    IEnumerator DisplayFirstHandWithDelay()
    {
        yield return new WaitForSeconds(3);
        hands[handNumber].SetActive(true);
        buttonsCanBePressed = true;
    }

    void BloodSplatter()
    {
        if(amountWrong == 0)
        {
            bloodOne.SetActive(true);
        }
        else if(amountWrong == 1)
        {
            bloodOne.SetActive(false);
            bloodTwo.SetActive(true);
        }
        else if(amountWrong == 2)
        {
            bloodTwo.SetActive(false);
            bloodThree.SetActive(true);
        }
    }
}
