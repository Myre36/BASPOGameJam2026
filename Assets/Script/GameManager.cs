using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool[] people = new bool[4];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < people.Length; i++) 
        {
        Debug.Log(people[i]);
        }


    private void CheckAnswer()
    {
        
    }
}
