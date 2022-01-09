using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{

    public static MenuAnimation Instance;

    [SerializeField] private RectTransform[] panelTransforms;
    [SerializeField] private float initialPosition;
    [SerializeField] private float animationTime;

    private void Start()
	{
        Instance = this;
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void InitializeAnimation(int id)
    {
        HideAllScreenAnimations();
        ShowSelectedScreenAnimation(id);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ResetAnimations()
    {
        HideAllScreenAnimations();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ShowSelectedScreenAnimation(int id)
	{
        panelTransforms[id].DOLocalMoveX(initialPosition - panelTransforms[id].rect.width, animationTime).SetEase(Ease.OutBack);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void HideAllScreenAnimations()
    {
        for (int i = 0; i < panelTransforms.Length; i++)
		{
            panelTransforms[i].DOLocalMoveX(initialPosition, animationTime).SetEase(Ease.InBack);
        }
    }

}
