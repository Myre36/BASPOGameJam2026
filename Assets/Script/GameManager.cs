using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Array people for amount of people for the first day. Gives 5 people. Non-temporary placeholder.
    private bool[] people = new bool[5];
    [SerializeField] private bool dayOver = default;

    // For CheckAnswer() 
    private int maxPeople = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
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
                dayOver = true;
            }
        }
    }
}
