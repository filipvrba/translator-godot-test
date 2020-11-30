# Translator Godot (test)
Godot je vsestrany, proto jsem vyzkousel jeho silu a otestoval jsem csharp a jeho nuget. Co dale jeste umi? propojeni mezi csharpem a gdscriptem, coz pro me jako programatora gdscriptu je dobra sprava.

## Co je to za projekt?
Projekt je jednoduchy prekladac od google. Nefunguje uplne z dovodu, ze mu chybi overovaci klic od google, ale komunikuje s officialni knihovou od google cloud.

## Implementace
### Nuget
Pri vytvoreni projektu z mono verce jsem musel pridat do meho souboru *translattor-godot-test.csproj* novy balicek.
``` csproj
  <ItemGroup>
        <PackageReference Include="Google.Cloud.Translation.V2">
          <Version>2.0.0</Version>
        </PackageReference>
  </ItemGroup>
</Project>
```
Nazev & verzi balicku jsem nasel [zde](https://www.nuget.org/).

### Google translator & CSharp
Potom jsem se koukal na official web na "[Translation text (Basic)](https://cloud.google.com/translate/docs/basic/translating-text)", kde jsem nasel, jak implementovat preklad textu. Pri implementaci jsem narazil na problem. Godot neumozji inicializaci kodu a tak jsem musel otevrit Visual Studio Code a nainstalovat do nej nastroj "[C# Tools for Godot](https://marketplace.visualstudio.com/items?itemName=neikeq.godot-csharp-vscode)".

**Poznamka:**
> Pokud vlastnite linux, tak je velka pravdepodobnost, ze budete muset stahnout framework. Tento framework je potreba pripsat do *csproj* souboru, aby IDE dokazal spolupracovat ze *cs* souborama.

Vytvoril jsem novy script *Translator.cs* a vlozil do nej metodu.
``` csharp
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
```

### GDScript jako hlavni jazyk
Na dale jsem nechtel pouzivat csharp jako hlavni programovaci jazyk v Godotu a tak jsem si nasel clanek, ve kterem se resi "[Cross-language scripting](https://docs.godotengine.org/en/stable/getting_started/scripting/cross_language_scripting.html)". Proto jsem na dale vytvoril do Control uzlu script *Control.gd*.
``` gdscript
var translator = load("res://Translator.cs")
onready var translator_node = translator.new()

func _ready() -> void:
	print(translator_node.TranslateTextWithModel())
```
Tento script spousti metodu, ktera je napsana v csharpu. Komunikace mezi gdsriptem a csharpem mi prijde velice jednoducha.
