using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    private CharacterPosition characterPosition;

    private void Start()
    {
        characterPosition = FindObjectOfType<CharacterPosition>();

        // ロード
        if (PlayerPrefs.HasKey("CharacterX") && PlayerPrefs.HasKey("CharacterY") && PlayerPrefs.HasKey("CharacterZ"))
        {
            float x = PlayerPrefs.GetFloat("CharacterX");
            float y = PlayerPrefs.GetFloat("CharacterY");
            float z = PlayerPrefs.GetFloat("CharacterZ");
            Vector3 savedPosition = new Vector3(x, y, z);

            // キャラクターの座標をロード
            characterPosition.transform.position = savedPosition;
        }
    }

    public void SavePosition()
    {
        Vector3 currentPosition = characterPosition.GetPosition();

        // セーブ
        PlayerPrefs.SetFloat("CharacterX", currentPosition.x);
        PlayerPrefs.SetFloat("CharacterY", currentPosition.y);
        PlayerPrefs.SetFloat("CharacterZ", currentPosition.z);
        
        PlayerPrefs.Save();
    }
}
