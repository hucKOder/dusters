using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hubka : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Image hubkaSelf;
    public bool isDragged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCursorSprite()
    {
        if (isDragged) { 
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            var tempColor = hubkaSelf.color;
            tempColor.a = 255f;
            hubkaSelf.color = tempColor;
            isDragged = false;
        }
        else
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            var tempColor = hubkaSelf.color;
            tempColor.a = 0f;
            hubkaSelf.color = tempColor;
            isDragged = true;
        }
    }
}
