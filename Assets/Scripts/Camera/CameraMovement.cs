using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement Instance;

    [HideInInspector]
    public bool isCameraMoving;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10f;

    private Vector3 previousPosition;

	private void Start()
	{
        Instance = this;

        Initialize();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Initialize()
	{
        isCameraMoving = false;

        cam.gameObject.transform.position = cam.gameObject.transform.localPosition = new Vector3(0f, 0f, -distanceToTarget);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void InitializeMovement()
	{
        previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        isCameraMoving = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void UpdateMovement()
	{
        Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = previousPosition - newPosition;
        
        float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
        float rotationAroundXAxis = direction.y * 180; // camera moves vertically

        cam.transform.position = target.position;

        cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        if (newPosition != previousPosition)
		{
            isCameraMoving = true;

            if (InstructionManual.Instance.instructionID == 0)
                InstructionManual.Instance.ShowInstruction();
        }
            
        previousPosition = newPosition;
    }

}
