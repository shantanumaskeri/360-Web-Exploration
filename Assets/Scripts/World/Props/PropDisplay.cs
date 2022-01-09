using cakeslice;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PropDisplay : MonoBehaviour
{

	public static PropDisplay Instance;

	private Outline outline;

	private void Start()
	{
		Instance = this;

		Initialize();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Initialize()
	{
		outline = GetComponent<Outline>();
		outline.enabled = false;
	}

	private void OnMouseOver()
	{
		if (!InputControl.Instance.isMousePressed)
		{
			ShowHideOutlineEffect(true);

			if (InstructionManual.Instance.instructionID == 2)
				InstructionManual.Instance.ShowInstruction();
		}
	}

	private void OnMouseExit()
	{
		ShowHideOutlineEffect(false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ShowHideOutlineEffect(bool value)
	{
		outline.enabled = value;
	}

}
