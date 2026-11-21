using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //So only this script can change Dontdestroyonload.
    public static GameManager Instance { get; private set; }
    //Grabbing elements from HandManager script.
    [SerializeField] private HandManager handManager; //amountWrong amountGood

    //Array people for amount of people for the first day. Gives 5 people. Non-temporary placeholder dayOver.
    private bool[] people = new bool[5];
    [SerializeField] private bool dayOver = default;

    // For CheckAnswer() 
    private int maxPeople = 0;

    void Awake()
    {
        //Making sure there are no duplicates.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        threeStrikesOut();
    }

    public void CheckAnswer()
    {
        // Loop that checks if people is false. If true adds one more to maxPeople. Resets max people if next is false.
        for (int i = 0; i < people.Length; i++)
        {
            if (people[i] == false)
            {
                maxPeople = 0;
                return;
            }
            else
            {
                maxPeople++;
            }

            // If every person in people are true, dayOver is true.
            if (maxPeople == 5)
            {
                handManager.amountWrong = 0;
                dayOver = true;
            }
        }
    }

    //Game over conditionals.
    public void threeStrikesOut()
    {
        if (handManager.amountWrong == 4)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
