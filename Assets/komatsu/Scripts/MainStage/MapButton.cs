using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField]
    Camera mapCamera;
    bool isMapActive;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("マウス検知");
            ToggleMapVisibility();
        }
    }

    void ToggleMapVisibility()
    {
        isMapActive = !isMapActive;
        mapCamera.gameObject.SetActive(isMapActive);

        if (mapCamera != null)
        {
            mapCamera.enabled = isMapActive;
        }
    }
}
