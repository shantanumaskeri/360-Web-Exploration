using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public static CameraZoom Instance;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float orthographicSizeMin;
    [SerializeField] private float orthographicSizeMax;
    [SerializeField] private float fovMin;
    [SerializeField] private float fovMax;
    [SerializeField] private Camera myCamera;

    private string zoomMode;

    private void Start()
    {
        Instance = this;

        Initialize();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Initialize()
	{
        zoomMode = "manual";
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void UpdateZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (myCamera.orthographic)
        {
            myCamera.orthographicSize -= zoomSpeed * scroll * (zoomSpeed * 2f);
            myCamera.orthographicSize = Mathf.Clamp(myCamera.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }
        else
        {
            if (scroll != 0f)
			{
                if (InstructionManual.Instance.instructionID == 1)
                    InstructionManual.Instance.ShowInstruction();
            }

            if (zoomMode == "manual")
			{
                myCamera.fieldOfView -= zoomSpeed * scroll * (zoomSpeed * 2f);
                myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, fovMin, fovMax);
            }
            else
			{
                if (myCamera.fieldOfView > fovMin)
                    myCamera.fieldOfView -= zoomSpeed;
                else
                    zoomMode = "manual";
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ChangeZoomMode()
	{
        zoomMode = "auto";
    }

}
