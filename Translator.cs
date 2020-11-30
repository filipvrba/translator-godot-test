using Godot;
using System;
using Google.Cloud.Translation.V2;

public class Translator : Node
{
	public string TranslateTextWithModel()
	{
		try
		{
			TranslationClient client = TranslationClient.Create();
			TranslationResult result = client.TranslateText(
				text: "Hello World.",
				targetLanguage: "cs",
				sourceLanguage: "en",
				model: TranslationModel.NeuralMachineTranslation);
			return result.TranslatedText;
		}
		catch (Exception e)
		{
			return e.Message;
		}
	}
}
