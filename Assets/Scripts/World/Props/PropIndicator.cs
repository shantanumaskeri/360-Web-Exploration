using System.Runtime.CompilerServices;
using UnityEngine;

public class PropIndicator : MonoBehaviour
{

    public static PropIndicator Instance;

    [SerializeField] private GameObject indicator;

    private void Start()
    {
        Instance = this;    
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShowHideAllIndicators(bool value)
	{
        indicator.SetActive(value);
	}

}
