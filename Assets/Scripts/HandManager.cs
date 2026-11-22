using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //The light switch
    public GameObject startDayButton;
    public GameObject startDayButtonVisual;

    //The buttons for guessing
    public GameObject guessHumanButton;
    public GameObject guessHumanButtonVisual;
    public GameObject guessNotHumanButton;
    public GameObject guessNotHumanButtonVisual;

    //To stop mashing the buttons causing multiple shadows to be dispalyed on screen, where only the last one decided good or bad.
    private bool buttonsCanBePressed = default;

    // First one will always be zero, then in DisplayHandsWithDelay() it will now choose randomly.
    private int handNumber = 0;
    private int?[] handNumberChecker = new int?[10];
    private int addNumber = 0;

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

    //Audio
    public AudioSource walkAudio;
    public AudioClip walkIn;

    //TODO
    public AudioClip walkOut;

    public AudioSource lightAudio;
    public AudioClip turnOn;

    //TODO
    public AudioClip turnOff;

    public AudioSource turretAudio;
    public AudioClip shotInfected;
    public AudioClip shotHuman;

    public AudioSource gateAudio;
    public AudioClip gateOpenInfected;
    public AudioClip gateOpenHuman;

    public AudioSource buttonAudio;
    public AudioClip buttonPress;


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

        lightAudio.clip = turnOn;
        lightAudio.Play();

        //Starts the couroutine that makes the hand appear
        StartCoroutine(DisplayFirstHandWithDelay());
    }

    //The method for guessing that the hand is human
    public void GuessHuman()
    {
        if (buttonsCanBePressed == true)
        {
            buttonAudio.clip = buttonPress;
            buttonAudio.Play();
            if (goodOrWrong[handNumber] == true)
            {
                amountGood++;
                gateAudio.clip = gateOpenInfected;
            }
            else
            {
                BloodSplatter();
                amountWrong++;
                gateAudio.clip = gateOpenInfected;
            }

            gateAudio.Play();

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
            buttonAudio.clip = buttonPress;
            buttonAudio.Play();
            if (goodOrWrong[handNumber] == false)
            {
                amountGood++;
                turretAudio.clip = shotInfected;
            }
            else
            {
                BloodSplatter();
                amountWrong++;
                turretAudio.clip = shotHuman;
            }

            turretAudio.Play();

            hands[handNumber].SetActive(false);
            buttonsCanBePressed = false;

            StartCoroutine(DisplayHandsWithDelay());
        }
    }

    //Couroutine for displaying the first hand
    IEnumerator DisplayHandsWithDelay()
    {
        //Play audio of someone walking in
        walkAudio.clip = walkIn;
        walkAudio.Play();
        
        //Suggestion: Getting the length of the audio clip above to control this wait
        yield return new WaitForSeconds(walkIn.length + 0.5f);

        //Picks a random number between 0 and 9. UnityEngine just to make sure no conflict between System.Random and UnityEngine.Random.
        handNumber = UnityEngine.Random.Range(0, (hands.Length));

        //Checks how long it is based on the length of the array hands.
        for (int i = 0; i < hands.Length; i++)
        {
            //As long as the number randomly chosen is a number in the array, randomly generate a new one until it isn't in the array
            while (handNumber == handNumberChecker[i])
            {
                //Checks if the last element in the array is not null. If it is breaks the loop. To prevent game crash and memory leak.
                if (handNumberChecker[hands.Length - 1] != null)
                {
                    Debug.Log("I broke");
                    break;
                }
                else 
                {
                    handNumber = UnityEngine.Random.Range(0, (hands.Length));
                    i = 0;
                }
            }

            Debug.Log(handNumberChecker[i]);
        }

        //To avoid game loop breaks. Because addNumber is updated after checking this condition it needs to be the same number as the last element in the array. 
        if (addNumber !<= 9)
        {
            //Adds the number into the array. Increases addNumber after so that it will not change a number already chosen.
            handNumberChecker[addNumber] = handNumber;
            addNumber++;
            //Gameplay with a full array will be randomized without checking for duplicates due to the conditions of the while loop above.
        }

        hands[handNumber].SetActive(true);
        buttonsCanBePressed = true;
    }

    //Couroutine for going to the next game
    IEnumerator DisplayFirstHandWithDelay()
    {
        yield return new WaitForSeconds(3);
        hands[handNumber].SetActive(true);
        handNumberChecker[addNumber] = handNumber;
        addNumber++;
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