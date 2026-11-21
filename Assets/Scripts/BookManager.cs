using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    public GameObject bookPrefab;
    public GameObject bookOnTable;
    [SerializeField] private bool bookOpen = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for 1 frame if spacebar was pressed. Inverts bookOpen and then sets it to that inversion.
        if (inputManager.sBar.WasPressedThisFrame())
        {
            bookOpen = !bookOpen;
            bookPrefab.SetActive(bookOpen);
            bookOnTable.SetActive(!bookOpen);
        }
    }

}
