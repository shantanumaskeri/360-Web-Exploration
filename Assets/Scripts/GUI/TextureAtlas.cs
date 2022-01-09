using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class TextureAtlas : MonoBehaviour
{

	[SerializeField] private SpriteAtlas spriteAtlas;
	[SerializeField] private string spriteName;
	[SerializeField] private Image image;

	private void Start()
    {
		Initialize();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Initialize()
	{
		PopulateAtlas();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void PopulateAtlas()
    {
		image.sprite = spriteAtlas.GetSprite(spriteName);
		image.preserveAspect = true;
	}

}
