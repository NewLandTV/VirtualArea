using System.IO;
using UnityEngine;

namespace VirtualArea
{
    public class FileReader
    {
        public static readonly string RESOURCE_PATH = Path.Combine(Application.persistentDataPath, "Resources");

        /// <summary>
        /// It converts data at a specific path, relative to the resources directory, into a sprite and retrieves it.
        /// </summary>
        /// <param name="path">Target to get data to sprite path.</param>
        /// <returns>From local image to graphic sprite object.</returns>
        public static Sprite ReadFileAndToSprite(string path)
        {
            // Access Resources Folder
            path = Path.Combine(RESOURCE_PATH, path);

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
