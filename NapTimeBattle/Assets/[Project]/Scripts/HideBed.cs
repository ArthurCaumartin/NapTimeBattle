using UnityEngine;

public class HideBed : HidePlace
{
    public bool isAllreadyTaken;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Sprite _baseSprite;

    public void SetSprite(Sprite sprite)
    {
        isAllreadyTaken = sprite;
        _sprite.sprite = sprite ? sprite : _baseSprite;
    }
}
