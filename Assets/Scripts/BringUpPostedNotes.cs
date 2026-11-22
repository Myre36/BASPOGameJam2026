using UnityEngine;

public class BringUpPostedNotes : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    public GameObject smallNote;
    public GameObject largeNote;

    // Update is called once per frame
    void Update()
    {
        if (inputManager == null)
        {
            inputManager = GameObject.FindWithTag("Input").GetComponent<InputManager>();
        }

        if (inputManager.sBar.WasPressedThisFrame())
        {
            CloseNote();
        }
    }

    public void BringUpNote()
    {
        largeNote.SetActive(true);
        smallNote.SetActive(false);
    }

    public void CloseNote()
    {
        smallNote.SetActive(true);
        largeNote.SetActive(false);
    }
}
