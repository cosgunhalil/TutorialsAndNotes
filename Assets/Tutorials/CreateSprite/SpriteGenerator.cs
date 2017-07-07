using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGenerator : MonoBehaviour {

    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            CreateSprite();
        }
    }

    public Texture2D CreateTexture2D()
    {
        Texture2D texture = new Texture2D(100, 100);
        texture.SetPixel(0,0,Color.white);
        texture.Apply();

        return texture;
    }

    public void CreateSprite()
    {
        var texture = CreateTexture2D();
        
        var sprite = new GameObject();
        sprite.name = "Sprite";

        _spriteRenderer = sprite.AddComponent<SpriteRenderer>() as SpriteRenderer;
        _spriteRenderer.color = Color.green;

        sprite.transform.position = new Vector3(0, 0, 0);

        _sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(.5f, .5f), 100f);

        _spriteRenderer.sprite = _sprite;
    }

}
