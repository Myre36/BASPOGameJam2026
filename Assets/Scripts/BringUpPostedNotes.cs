using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BringUpPostedNotes : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private BookManager bookManager;

    public GameObject smallNote;
    public GameObject largeNote;
    public GameObject[] noteBookList;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */

        if (bookManager.bookOpen == true)
        {
            ButtonCanNotInteract();
        }

        if (inputManager.sBar.WasPressedThisFrame())
        {
            CloseNote();
        }
    }

    void OnEnable()
    {
        string scene = SceneManager.GetActiveScene().name;
        if (scene != "MainScene") return;
        inputManager = GameObject.FindWithTag("Input").GetComponent<InputManager>();
        noteBookList = GameObject.FindGameObjectsWithTag("BookBSNote");
        bookManager = GameObject.FindWithTag("Book").GetComponent<BookManager>();
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
