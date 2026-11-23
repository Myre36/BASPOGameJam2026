using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    public GameObject bookOnTable;
    public GameObject book;
    public Sprite[] pageSprites;
    public int bookPage = 0;

    public bool bookOpen = default;

    //Audio
    public AudioSource audioPlayer;
    public AudioClip pageTurn2;
    public AudioClip pageTurn1;
    public AudioClip putDown;
    public AudioClip pickUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager == null)
        {
            inputManager = GameObject.FindWithTag("Input").GetComponent<InputManager>();
        }

        // Checks for 1 frame if spacebar was pressed. Inverts bookOpen and then sets it to that inversion. Removes the book on the table.
        if (inputManager.sBar.WasPressedThisFrame())
        {
            OpenBook();
        }

        if (inputManager.rClick.WasPressedThisFrame() && bookOpen == true)
        {
            bookPage++;
            if (bookPage >= pageSprites.Length)
            {
                bookPage = (pageSprites.Length - 1);
                return;
            }
            ShowPage();
            PlayAudio(pageTurn1);
        }

        if (inputManager.lClick.WasPressedThisFrame() && bookOpen == true)
        {
            bookPage--;
            if (bookPage == -1)
            {
                bookPage = 0;
                return;
            }
            ShowPage();
            PlayAudio(pageTurn2);
        }
    }
    private void ShowPage()
    {
        book.GetComponent<Image>().sprite = pageSprites[bookPage];
    }

    public void OpenBook()
    {
        bookOpen = !bookOpen;
        book.SetActive(bookOpen);
        bookOnTable.SetActive(!bookOpen);

        //Switches sound based on if we're picking it up or putting it down
        if (bookOpen) { PlayAudio(pickUp); } else { PlayAudio(putDown); }
    }

    //Takes a audio clip and feeds it to this objects audio source
    void PlayAudio(AudioClip inAudio)
    {
        audioPlayer.clip = inAudio;
        audioPlayer.Play();
    }
}
