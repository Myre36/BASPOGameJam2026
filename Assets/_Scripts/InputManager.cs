using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //So only this script can change Dontdestroyonload.
    public static InputManager Instance { get; private set; }

    public InputAction sBar;
    public InputAction lClick;
    public InputAction rClick;
    void Awake()
    {
        OnEnable();

        //Making sure there are no duplicates.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        sBar?.Enable();
        lClick?.Enable();
        rClick?.Enable();
    }
    private void OnDisable()
    {
        sBar?.Disable();
        lClick?.Disable();
        rClick?.Disable();
    }
}
