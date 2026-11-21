using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    public GameObject spriteObject;
    [SerializeField] private bool bookOpen = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.sBar.WasPressedThisFrame())
        {
            spriteObject.SetActive(!bookOpen);
            bookOpen = !bookOpen;
        }
    }

}
