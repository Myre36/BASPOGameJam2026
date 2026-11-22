using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    public GameObject bookOnTable;
    public GameObject book;
    public Sprite[] pageSprites;
    public int bookPage = 0;

    [SerializeField] private bool bookOpen = default;

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
            }
            ShowPage();
        }

        if (inputManager.lClick.WasPressedThisFrame() && bookOpen == true)
        {
            bookPage--;
            if (bookPage == -1)
            {
                bookPage = 0;
            }
            ShowPage();
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
    }
}
