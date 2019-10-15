# rrule-parser.net

Dotnet port of [rrule-parser by aditosoftware](https://github.com/aditosoftware/rrule-parser). 

RRule parser is a small dotnet library which lets you convert a [iCalendar RRule](https://tools.ietf.org/html/rfc2445#section-4.3.10) into human readable text.

## Example
```csharp 
var ruleParser = RRuleParser.CreateDefault()

string parseResult = ruleParser.ParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=SU;INTERVAL=5");
// Every 5 months on fourth Sunday
```

## Customization


### Translation
Want to use another language? No problem, just implement the [ILanguagePackage](src/DeepWinter.RRuleParserNet/Translation/Language/ILanguagePackage.cs) interface
and pass it to the [parser during initialization](src/DeepWinter.RRuleParserNet/RRuleParser.cs#L29). (An example can be found [here](src/DeepWinter.RRuleParserNet/Translation/Language/EnglishTranslation.cs))

Current available translation are
  - [English](src/DeepWinter.RRuleParserNet/Translation/Language/EnglishTranslation.cs)
  - [German](src/DeepWinter.RRuleParserNet/Translation/Language/GermanTranslation.cs)

The default translation is in [English](src/DeepWinter.RRuleParserNet/Translation/Language/EnglishTranslation.cs).

```csharp 
var ruleParser = RRuleParser.CreateGerman()
...
```

