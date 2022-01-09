using System.Runtime.CompilerServices;
using UnityEngine;

public class InputControl : MonoBehaviour
{

    public static InputControl Instance;

    [HideInInspector]
    public bool isMousePressed;

	private void Start()
	{
        Instance = this;

        Initialize();
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Initialize()
	{
        isMousePressed = false;
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnLeftMousePressDown();
        if (Input.GetMouseButtonUp(0))
            OnLeftMouseReleaseUp();
        if (Input.GetMouseButton(0))
            OnLeftMousePressAndKeep();
        if (Input.GetMouseButtonDown(1))
            OnRightMousePressDown();

        OnMouseScrollWheelRoll();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OnLeftMousePressDown()
	{
        isMousePressed = true;

        CameraMovement.Instance.InitializeMovement();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OnLeftMouseReleaseUp()
    {
        isMousePressed = false;

        PropInteraction.Instance.PrepareInteraction();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OnLeftMousePressAndKeep()
	{
        CameraMovement.Instance.UpdateMovement();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OnRightMousePressDown()
    {
        PropInteraction.Instance.ResetInteraction(true);
        MenuAnimation.Instance.ResetAnimations();
        InstructionManual.Instance.HideInstructions();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void OnMouseScrollWheelRoll()
	{
        CameraZoom.Instance.UpdateZoom();
    }

}
