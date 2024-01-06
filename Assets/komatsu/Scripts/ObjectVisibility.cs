using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    // オブジェクトの非表示
    public void HideObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    // オブジェクトの表示
    public void ShowObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
