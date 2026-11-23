using UnityEngine;
using UnityEngine.UI;

public class BringUpPostedNotes : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private BookManager bookManager;

    public GameObject smallNote;
    public GameObject largeNote;
    public GameObject[] noteBookList;

    // Update is called once per frame
    void Update()
    {
        if (inputManager == null)
        {
            inputManager = GameObject.FindWithTag("Input").GetComponent<InputManager>();
        }

        if (noteBookList.Length == 0)
        {
            noteBookList = GameObject.FindGameObjectsWithTag("BookBSNote");
        }

        if (bookManager == null)
        {
            bookManager = GameObject.FindWithTag("Book").GetComponent<BookManager>();
        }

        if (bookManager.bookOpen == true)
        {
            ButtonCanNotInteract();
        }

        if (inputManager.sBar.WasPressedThisFrame())
        {
            CloseNote();
        }
    }

    public void BringUpNote()
    {
        if (!bookManager.bookOpen)
        {
            largeNote.SetActive(true);
            smallNote.SetActive(false);
            Debug.Log("hello");

            ButtonCanNotInteract();
        }
    }

    public void CloseNote()
    {
        smallNote.SetActive(true);
        largeNote.SetActive(false);

        ButtonCanInteract();
    }

    public void ButtonCanNotInteract()
    {
        for (int i = 0; i < noteBookList.Length; i++)
        {
            if (noteBookList[i] != smallNote)
            {
                Debug.Log(smallNote.name);
                Button button = noteBookList[i].GetComponent<Button>();
                button.interactable = false;
                Debug.Log(button.interactable);
            }
        }
    }

    public void ButtonCanInteract()
    {
        for (int i = 0; i < noteBookList.Length; i++)
        {
            if (noteBookList[i] != smallNote)
            {
                if (noteBookList[i] != largeNote)
                {
                    Debug.Log(noteBookList[i]);
                    Button button = noteBookList[i].GetComponent<Button>();
                    button.interactable = true;
                }
            }
        }
    }
}
