using System.IO;
using UnityEngine;

namespace VirtualArea
{
    public class FileReader
    {
        public static Sprite ReadFileAndToSprite(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            byte[] textureBytes = File.ReadAllBytes(path);

            if (textureBytes.Length <= 0)
            {
                return null;
            }

            Texture2D texture = new Texture2D(0, 0);

            texture.LoadImage(textureBytes);

            return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.one * 0.5f);
        }
    }
}
