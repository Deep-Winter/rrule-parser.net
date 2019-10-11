# rrule-parser.net
Dotnet port of [rrule-parser by aditosoftware](https://github.com/aditosoftware/rrule-parser). 

RRule parser is a small java library which lets you convert a [iCalendar RRule](https://tools.ietf.org/html/rfc2445#section-4.3.10) into human readable text.

## Example
```csharp 
RRuleParser ruleParser = new RRuleParser();

string parseResult = ruleParser.ParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=SU;INTERVAL=5");
// Every 5 months on fourth Sunday
```

## Customization


### Translation
Want to use another language? No problem, just implement the [ILanguagePackage](src/main/java/de/adito/rruleparser/translation/language/ILanguagePackage.java) interface
and pass it to the [parser during initialization](src/main/java/de/adito/rruleparser/RRuleParser.java#L29). (An example can be found [here](src/main/java/de/adito/rruleparser/translation/language/EnglishTranslation.java))

The default translation is in [English](src/main/java/de/adito/rruleparser/translation/language/EnglishTranslation.java).
