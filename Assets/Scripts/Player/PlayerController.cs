using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int id { get => this.playerID; }
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour PlayerMovementBehaviour;
    public PlayerAnimationBehaviour PlayerAnimationBehaviour;


    [Header("Input Settings")]
    public PlayerInput PlayerInput;
    private Vector3 rawInputMovement;

    [Header("Physics")]
    public Rigidbody2D rigidbody2d;

    //Action Maps
    //private string actionMapPlayerControls = "Player Controls";
    //private string actionMapMenuControls = "Menu Controls";

    //Current Control Scheme
    private string currentControlScheme;

    public void SetupPlayer(int newPlayerID)
    {
        playerID = newPlayerID;

        currentControlScheme = PlayerInput.currentControlScheme;

        PlayerMovementBehaviour.SetupBehaviour();
        PlayerAnimationBehaviour.SetupBehaviour();
    }


    #region InputActions events, called from PlayerInput
    //This is called from PlayerInput; when a joystick or arrow keys has been pushed.
    //It stores the input Vector as a Vector3 to then be used by the smoothing function.


    public void OnMovement(InputAction.CallbackContext value)
    {
        rawInputMovement = value.ReadValue<Vector2>();
        //Debug.Log(rawInputMovement);
    }

    //This is called from PlayerInput, when a button has been pushed, that corresponds with the 'Attack' action
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            //playerAnimationBehaviour.PlayAttackAnimation();
        }
    }

    //This is called from Player Input, when a button has been pushed, that correspons with the 'TogglePause' action
    public void OnTogglePause(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            GameManager.Instance.TogglePause();
        }
    }
    #endregion

    void Update()
    {
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
    }

    void UpdatePlayerMovement()
    {
        PlayerMovementBehaviour.UpdateMovementData(rawInputMovement);
    }
    void UpdatePlayerAnimationMovement()
    {
        PlayerAnimationBehaviour.UpdateMovementAnimation(rigidbody2d);
        //playerAnimationBehaviour.UpdateMovementAnimation(rawInputMovement.magnitude);
    }
}
