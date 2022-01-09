using System.Runtime.CompilerServices;
using UnityEngine;

public class PropInteraction : MonoBehaviour
{

    public static PropInteraction Instance;

	private void Start()
	{
        Instance = this;
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PrepareInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (!hit.collider.gameObject.CompareTag("Untagged"))
            {
                if (!CameraMovement.Instance.isCameraMoving)
				{
                    ResetInteraction(false);

                    MeshRenderer renderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                    PropSystem.Instance.ConfigureSystem(renderer, hit.collider.gameObject.tag);
                    CameraZoom.Instance.ChangeZoomMode();

                    if (InstructionManual.Instance.instructionID == 3)
                        InstructionManual.Instance.ShowInstruction();
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ResetInteraction(bool value)
	{
        PropRendering.Instance.ShowHideAllChildrenInTarget(value);
        PropIndicator.Instance.ShowHideAllIndicators(true);
    }

}
