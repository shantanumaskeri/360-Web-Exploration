using System.Runtime.CompilerServices;
using UnityEngine;

public class PropSystem : MonoBehaviour
{

    public static PropSystem Instance;

    private void Start()
    {
        Instance = this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ConfigureSystem(MeshRenderer renderer, string tag)
    {
        PropRendering.Instance.ShowCurrentSelection(renderer);
        PropDisplay.Instance.ShowHideOutlineEffect(false);
        PropIndicator.Instance.ShowHideAllIndicators(false);

        switch (tag)
        {
            case "Superstructure":
                MenuAnimation.Instance.InitializeAnimation(3);
                break;

            case "Shell and Cradle":
                MenuAnimation.Instance.InitializeAnimation(2);
                break;

            case "Cathode Lining":
                MenuAnimation.Instance.InitializeAnimation(1);
                break;

            case "Busbar":
                MenuAnimation.Instance.InitializeAnimation(0);
                break;
        }
    }

}
