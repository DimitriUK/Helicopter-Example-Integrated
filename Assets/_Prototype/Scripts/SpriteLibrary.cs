using UnityEngine;

public class SpriteLibrary : MonoBehaviour
{
    public static SpriteLibrary instance;

    public Sprite NoAds;
    public Sprite Coins100;
    public Sprite Coins200;

    private void Awake()
    {
        instance = this;
    }
}
