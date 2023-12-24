using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    // Start is called before the first frame update
    void Start()
    {
        
        var r = GetComponent<Renderer>();
        if (texture == null)
        {
            texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
            r.material.mainTexture = texture;
        }
        else
        {
            Texture2D convertedTexture = ConvertTextureFormat(texture, TextureFormat.RGBA32);
            r.material.mainTexture = convertedTexture;
        }
    }
    private Texture2D ConvertTextureFormat(Texture2D sourceTexture, TextureFormat targetFormat)
    {

        // 텍스처 형식이 지원되는지 확인
        if (!SystemInfo.SupportsTextureFormat(targetFormat))
        {
            Debug.LogError("Unsupported texture format: " + targetFormat);
            return null;  // 지원되지 않는 형식이면 null 반환 또는 다른 처리를 수행할 수 있음
        }

        // 새로운 텍스처를 생성하고 픽셀 값을 복사
        Texture2D convertedTexture = new Texture2D(sourceTexture.width, sourceTexture.height, targetFormat, sourceTexture.mipmapCount > 1);

        // Graphics.CopyTexture 대신 GetPixels와 SetPixels를 사용하여 직접 픽셀 값을 복사
        Color[] pixels = sourceTexture.GetPixels();
        convertedTexture.SetPixels(pixels);
        convertedTexture.Apply();

        return convertedTexture;
    }
}
