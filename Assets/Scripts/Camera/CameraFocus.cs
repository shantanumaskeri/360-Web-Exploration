using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

    public static CameraFocus Instance;

    [SerializeField] private Transform cam;

	private void Start()
	{
		Instance = this;
	}

	private void Update()
	{
		LookAtCamera();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void LookAtCamera()
	{
        transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }

}
