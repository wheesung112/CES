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

        // �ؽ�ó ������ �����Ǵ��� Ȯ��
        if (!SystemInfo.SupportsTextureFormat(targetFormat))
        {
            Debug.LogError("Unsupported texture format: " + targetFormat);
            return null;  // �������� �ʴ� �����̸� null ��ȯ �Ǵ� �ٸ� ó���� ������ �� ����
        }

        // ���ο� �ؽ�ó�� �����ϰ� �ȼ� ���� ����
        Texture2D convertedTexture = new Texture2D(sourceTexture.width, sourceTexture.height, targetFormat, sourceTexture.mipmapCount > 1);

        // Graphics.CopyTexture ��� GetPixels�� SetPixels�� ����Ͽ� ���� �ȼ� ���� ����
        Color[] pixels = sourceTexture.GetPixels();
        convertedTexture.SetPixels(pixels);
        convertedTexture.Apply();

        return convertedTexture;
    }
}
