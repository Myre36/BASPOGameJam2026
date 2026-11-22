using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Grabbing elements from HandManager script.
    [SerializeField] private HandManager handManager; //amountWrong amountGood

    public static GameManager Instance { get; private set; }

    //Array people for amount of people for the first day. Gives 5 people. Non-temporary placeholder dayOver.
    public bool?[] people = new bool?[10];
    [SerializeField] private bool dayOver = default;

    // For CheckAnswer() 
    public int peopleChecker = 0;
    public int everyPerson = 0;

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
    void Update()
    {
        if (handManager == null)
        {
            handManager = GameObject.FindWithTag("Hand").GetComponent<HandManager>();
        }
    }

    void FixedUpdate()
    {
        fourStrikesOut();
        DayDone();
    }

    public void CheckAnswer()
    {
        // Loop that checks if people is false. If true adds one more to maxPeople. Resets max people if next is false.
        for (int i = 0; i < people.Length; i++)
        {
            if (people[i] == false)
            {
                everyPerson++;
                Debug.Log(everyPerson);
                return;
            }
            else
            {
                everyPerson++;
                Debug.Log(everyPerson);
                peopleChecker++;
            }
        }
    }

    public void DayDone()
    {
        if (people.Length <= everyPerson)
        {
            dayOver = true;
        }

        if (dayOver == true)
        {
            SceneManager.LoadScene("DayOver");
        }
    }

    //Game over conditionals.
    public void fourStrikesOut()
    {
        if (handManager.amountWrong == 4)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
