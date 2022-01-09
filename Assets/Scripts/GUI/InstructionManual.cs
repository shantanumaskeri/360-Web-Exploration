using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InstructionManual : MonoBehaviour
{

    public static InstructionManual Instance;

    [HideInInspector]
    public int instructionID = -1;

    [SerializeField] private GameObject helpButton;
    [SerializeField] private GameObject instructionObj;
    [SerializeField] private TextMeshProUGUI instructionText;
    [SerializeField] private string[] instructions;

    private int instructionViewed;

    private void Start()
    {
        Instance = this;

        //PlayerPrefs.DeleteAll();

        Initialize();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Initialize()
	{
        instructionViewed = PlayerPrefs.GetInt("InstructionViewed");
        if (instructionViewed == 0)
            ShowInstruction();
        else
            HideInstructions();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PrepareInstructions()
	{
        instructionID = -1;

        instructionViewed = 0;
        PlayerPrefs.SetInt("InstructionViewed", instructionViewed);

        ShowInstruction();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShowInstruction()
	{
        if (instructionViewed == 0)
		{
            instructionID++;
            instructionObj.SetActive(true);
            instructionText.text = instructions[instructionID];

            helpButton.SetActive(false);
        }
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HideInstructions()
	{
        instructionID = 0;
        instructionText.text = "";
        instructionObj.SetActive(false);

        instructionViewed = 1;
        PlayerPrefs.SetInt("InstructionViewed", instructionViewed);

        helpButton.SetActive(true);
    }

}
