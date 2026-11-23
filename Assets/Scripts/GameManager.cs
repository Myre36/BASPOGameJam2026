using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Grabbing elements from HandManager script.
    [SerializeField] private HandManager handManager; //amountWrong amountGood

    public static GameManager Instance { get; private set; }

    //Array people for amount of people for the first day. Gives 5 people. Non-temporary placeholder dayOver.
    public bool[] people = new bool[10];
    [SerializeField] private bool dayOver = default;

    // For CheckAnswer() 
    public int peopleCorrect = 0;
    public int everyPerson = 0;

    void Awake()
    {
        Debug.Log(people.Length);
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

        if(everyPerson >= 19)
        {
            everyPerson = 0;
            SceneManager.LoadScene("DayOver");
        }
    }

    void FixedUpdate()
    {
        fourStrikesOut();
        //DayDone();
    }

    public void DayDone()
    {
        if (people.Length <= everyPerson)
        {
            dayOver = true;
        }

        if (dayOver == true)
        {
            dayOver = false;
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
