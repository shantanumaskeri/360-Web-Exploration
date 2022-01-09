using System.Runtime.CompilerServices;
using UnityEngine;

public class PropRendering : MonoBehaviour
{

    public static PropRendering Instance;

    [SerializeField] private GameObject target;
    [SerializeField] private Material faded;
    [SerializeField] private Material opaque;

    private void Start()
    {
        Instance = this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShowHideAllChildrenInTarget(bool value)
    {
        MeshRenderer[] childrenMeshRenderers = target.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < childrenMeshRenderers.Length; i++)
        {
            if (childrenMeshRenderers[i].gameObject.GetComponent<MeshCollider>() != null)
                childrenMeshRenderers[i].gameObject.GetComponent<MeshCollider>().enabled = value;

            if (value == false)
                childrenMeshRenderers[i].material = faded;
            else
                childrenMeshRenderers[i].material = opaque;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShowCurrentSelection(MeshRenderer renderer)
	{
        renderer.material = opaque;
    }

}
