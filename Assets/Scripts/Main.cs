using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VirtualArea;
using VirtualArea.DesignElements;

public class Main : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (!Power.IsRunning)
        {
            yield return null;
        }

        AreaLink helloWorldAreaLink = BackgroundManager.instance.GetAreaLink();

        if (helloWorldAreaLink == null)
        {
            yield break;
        }

        helloWorldAreaLink.Show(FileReader.ReadFileAndToSprite("E:\\UserData\\Images\\Group-A\\HelloWorld.png"), HelloWorldArea);

        AreaLink informationAreaLink = BackgroundManager.instance.GetAreaLink();

        if (informationAreaLink == null)
        {
            yield break;
        }

        informationAreaLink.Show(FileReader.ReadFileAndToSprite("E:\\UserData\\Images\\Group-A\\Information.png"), InformationArea);

        AreaLink simpleGameAreaLink = BackgroundManager.instance.GetAreaLink();

        if (simpleGameAreaLink == null)
        {
            yield break;
        }

        simpleGameAreaLink.Show(FileReader.ReadFileAndToSprite("E:\\UserData\\Images\\Group-A\\SimpleGame.png"), SimpleGameArea);
    }
    
    private void HelloWorldArea()
    {
        // Area_Hello World
        Area helloWorldArea = AreaManager.instance.GetArea();

        if (helloWorldArea == null)
        {
            return;
        }

        helloWorldArea.Width = 960;
        helloWorldArea.Height = 540;
        helloWorldArea.Title = "Hello World";

        helloWorldArea.BottomTools.SetTitleImage(FileReader.ReadFileAndToSprite("E:\\HelloWorld.png"));

        // Design elements
        GameObject helloWorldText = new GameObject("HelloWorldText", typeof(TextMeshProUGUI));
        GameObject helloWorldText2 = new GameObject("HelloWorldText2", typeof(TextMeshProUGUI));
        GameObject button = new GameObject("Button", typeof(Button), typeof(TextMeshProUGUI));
        TextMeshProUGUI helloWorldTextComponent = helloWorldText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI helloWorldTextComponent2 = helloWorldText2.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI buttonText = button.GetComponent<TextMeshProUGUI>();
        Button buttonComponent = button.GetComponent<Button>();
        RectTransform helloWorldTextRectTransform = helloWorldText.GetComponent<RectTransform>();
        RectTransform helloWorldTextRectTransform2 = helloWorldText2.GetComponent<RectTransform>();
        RectTransform buttonRectTransform = button.GetComponent<RectTransform>();

        // Add design elements
        helloWorldArea.AddDesignElements(helloWorldTextRectTransform, helloWorldTextRectTransform2, buttonRectTransform);

        // HelloWorldText
        helloWorldTextComponent.text = "Hello, World!";
        helloWorldTextComponent.fontSize = 62f;
        helloWorldTextComponent.color = Color.white;
        helloWorldTextComponent.alignment = TextAlignmentOptions.Center;

        helloWorldTextRectTransform.position = Vector3.up * 370f;
        helloWorldTextRectTransform.sizeDelta = new Vector2(400f, 70f);

        // HelloWorldText2
        helloWorldTextComponent2.text = "JkhTV!";
        helloWorldTextComponent2.fontSize = 40f;
        helloWorldTextComponent2.color = new Color(0.2627f, 0.0632f, 0.3739f, 1f);
        helloWorldTextComponent2.alignment = TextAlignmentOptions.Left;

        helloWorldTextRectTransform2.position = Vector3.up * 540f;
        helloWorldTextRectTransform2.sizeDelta = new Vector2(300f, 50f);

        // Button
        buttonText.text = "Toggle";
        buttonText.color = Color.black;

        buttonComponent.onClick.AddListener(() => helloWorldText2.SetActive(!helloWorldText2.activeSelf));

        buttonRectTransform.position = new Vector3(250f, 400f, 0f);
        buttonRectTransform.sizeDelta = new Vector2(160f, 80f);

        // Active this area
        helloWorldArea.Active();
    }

    private void InformationArea()
    {
        // Area_Information
        Area informationArea = AreaManager.instance.GetArea();

        if (informationArea == null)
        {
            return;
        }

        informationArea.Width = 1280;
        informationArea.Height = 720;
        informationArea.Title = "Information";

        informationArea.BottomTools.SetTitleImage(FileReader.ReadFileAndToSprite("E:\\Information.png"));

        // Design elements
        DEText myText = DE.Create("MyText", DesignElementType.Text).GetComponent<DEText>();
        DEImage myImage = DE.Create("MyImage", DesignElementType.Image).GetComponent<DEImage>();

        // Add design elements
        informationArea.AddDesignElements(myText.RectTransform, myImage.RectTransform);

        // MyText
        myText.SetText("JkhTV subscriber is 460!").SetFontSize(65f).SetColor(Color.white).SetAlignment(TextAlignmentOptions.Center);

        myText.RectTransform.position = Vector2.up * 820f;
        myText.RectTransform.sizeDelta = new Vector2(1000f, 70f);

        // MyImage
        myImage.SetSprite(FileReader.ReadFileAndToSprite("E:\\UserData\\Youtube\\Channel\\¿Â∞Ê«ıtv\\Images\\Youtube_Thumbnail\\±∏µ∂¿⁄_N∏Ì_±‚≥‰\\400.png"));

        myImage.RectTransform.position = Vector3.up * 500f;
        myImage.RectTransform.sizeDelta = new Vector2(960f, 540f);

        // Active this area
        informationArea.Active();
    }

    private void SimpleGameArea()
    {
        // Area_SimpleGame
        Area simpleGameArea = AreaManager.instance.GetArea();

        if (simpleGameArea == null)
        {
            return;
        }

        simpleGameArea.Width = 960;
        simpleGameArea.Height = 540;
        simpleGameArea.Title = "Simple Game";

        simpleGameArea.BottomTools.SetTitleImage(FileReader.ReadFileAndToSprite("E:\\SimpleGame.png"));

        // Variables
        uint score = 0;

        // Design elements
        DEText scoreText = DE.Create("ScoreText", DesignElementType.Text).GetComponent<DEText>();
        DEImage potatoImage = DE.Create("PotatoImage", DesignElementType.Image).GetComponent<DEImage>();
        DEButton increaseScoreButton = DE.Create("IncreaseScoreButton", DesignElementType.Button).GetComponent<DEButton>();

        // Add design elements
        simpleGameArea.AddDesignElements(scoreText.RectTransform, potatoImage.RectTransform, increaseScoreButton.RectTransform);

        // ScoreText
        scoreText.SetText("0").SetFontSize(50f).SetColor(new Color(0.627f, 0.384f, 0.672f)).SetAlignment(TextAlignmentOptions.Top);

        scoreText.RectTransform.position = Vector2.up * 650f;
        scoreText.RectTransform.sizeDelta = new Vector2(800f, 55f);

        // PlayerImage
        potatoImage.SetSprite(FileReader.ReadFileAndToSprite("E:\\Programming\\Projects\\Unity\\Game\\GrowingTown\\Assets\\Images\\Food\\Potato.png"));

        potatoImage.RectTransform.position = Vector2.up * 420f;
        potatoImage.RectTransform.sizeDelta = new Vector2(128f, 128f);

        // IncreaseScoreButton
        increaseScoreButton.AddOnClickEvent(() =>
        {
            scoreText.SetText($"{++score}");

            if (score % 10 == 0)
            {
                potatoImage.RectTransform.sizeDelta += Vector2.one * 16f;
            }
            if (score % 250 == 0)
            {
                potatoImage.RectTransform.sizeDelta = new Vector2(128f, 128f);
            }
        });

        increaseScoreButton.RectTransform.position = Vector2.up * 190f;
        increaseScoreButton.RectTransform.sizeDelta = new Vector2(220f, 60f);

        // Active this area
        simpleGameArea.Active();
    }
}
