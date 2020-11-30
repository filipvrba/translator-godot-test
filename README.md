# Translator Godot (test)
Godot je vsestrany, proto jsem vyzkousel jeho silu a otestoval jsem csharp a jeho nuget. Co dale jeste umi? propojeni mezi csharpem a gdscriptem, coz pro me jako programatora gdscriptu je dobra sprava.

## Co je to za projekt?
Projekt je jednoduchy prekladac od google. Nefunguje uplne z dovodu, ze mu chybi overovaci klic od google, ale komunikuje s officialni knihovou od google cloud.

## Implementace
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

Potom jsem se koukal na official web na "[Translation text (Basic)](https://cloud.google.com/translate/docs/basic/translating-text)", kde jsem nasel, jak implementovat preklad textu. Pri implementaci jsem narazil na problem. Godot neumozji inicializaci kodu a tak jsem musel otevrit Visual Studio Code a nainstalovat do nej nastroj "[C# Tools for Godot](https://marketplace.visualstudio.com/items?itemName=neikeq.godot-csharp-vscode)".


**Poznamka:**
> Pokud vlastnite linux, tak je velka pravdepodobnost, ze budete muset stahnout framework. Tento framework je potreba pripsat do *csproj* souboru, aby IDE dokazal spolupracovat ze *cs* souborama.
