# What does it do?

A library with extension methods and helpers that implement general-purpose routines.
It aims to facilitate and speed up the development process, preventing features that can be reused from being rewritten in all projects.

# Extension methods

**OBS:** All methods in this section are extension methods, so they must always be called respecting their respective syntax.

Example:

```csharp
public void Execute()
{
    ..
    
    var foo = new Foo();
    foo.ExtensionMethod();
}
```

### Byte

| Return Type | Method |
| --------------- | ------- |
| string | ToHexadecimal()|

### DateTime

| Return Type | Method |
| --------------- | ------- |
| DateTime | ConvertTimeToSouthAmericaZone() |

### Enum

| Return Type | Method |
| --------------- | ------- |
| string | GetDescription() |

### IEnumerable

| Return Type | Method |
| --------------- | ------- |
| bool | IsNullOrEmpty() |
| IEnumerable<TClass?> | Distinct<TClass>(Func<TClass, object> key) |
| bool | ContainsAny<TClass>(params TClass[] values) |
| IEnumerable<TClass> | DistinctByMaxValue<TClass, TKey, TValue>(Func<TClass, TKey> groupBy, Func<TClass, TValue> orderBy) |

**Distinct**

Example:
```csharp

var people = new List<Person>()
{
    new Person { Id = 1, Name = John },
    new Person { Id = 2, Name = John },
    new Person { Id = 3, Name = Mary }
};

var result = people.Distinct(l => l.Name);

foreach(var item in result)
    Console.WriteLine($"Id = {item.Id}, Name = {item.Name}");

// Output
// Id = 1, Name = John
// Id = 3, Name = Mary
```

**DistinctByMaxValue**

Example:

```csharp
var people = new List<Person>()
{
    new Person() { Name = "Todd", Age = 11 },
    new Person() { Name = "Tony", Age = 50 },
    new Person() { Name = "Alfred", Age = 70},
    new Person() { Name = "Todd", Age = 5}
};

var newResult = people.DistinctByMaxValue(p => p.Name, p => p.Age);

foreach(var item in newResult)
    Console.WriteLine($"Name = {item.Name}, Age = {item.Age}");

// Output
// Name = Alfred, Age = 70
// Name = Tony, Age = 50
// Name = Todd, Age = 11
```

### Int

| Return Type | Method |
| --------------- | ------- |
| bool | IsBetween(int startNumber, int endNumber) |

### Object

| Return Type | Method |
| --------------- | ------- |
| bool | IsNull() |
| bool | In<TEntity>(params TEntity[] values) |

**In**

Example:

```csharp
var guid = Guid.NewGuid();
var result = guid.In(Guid.NewGuid(), guid, Guid.NewGuid());

Console.WriteLine($"this object exists in source list? {result}");

// Output
// O objeto existe na lista informada: true
```

### Reflection

| Return Type | Method |
| --------------- | ------- |
| TAttribute? | GetAttribute<TAttribute>() |
| bool | HasAttribute<TAttribute>() |
| object? | GetPropertyValue<TCLass>() |
| TCLass | SetPropertyValue<TCLass>() |
| object? | GetFieldValue<TCLass>() |
| void | SetFieldValue<TCLass>() |

### Stream

| Return Type | Method |
| --------------- | ------- |
| Task<string> | ReadAsStringAsync() |

### String

| Return Type | Method |
| --------------- | ------- |
| bool | Match(string compare) |
| string | GetOnlyAlphanumeric() |
| string | RemoveAllSpaces() |
| string | RemoveText(params string[] removeValues |
| string | RemoveText(params Regex[] removeValues) |
| string | RemoveFirstOccurence(Regex removeRegex) |
| string | RemoveGrammarAccents() |
| string | RemoveLineBreaks(string replaceWith = " ") |
| string | ReplaceAll(string[] replaceArguments, string replaceWith) |
| string | NullAsEmpty() |
| string? | EmptyAsNull() |
| string | Captalize() |
| string | ToBase64() |
| string | MaskCharacters(char maskChar, int numCharacters = 0) |
| bool | HasOnlyDigits() |
| string | GetOnlyDigits() |
| bool | HasOnlyLetters() |
| string | GetOnlyLetters() |
| string | ToSnakeCase() |
| string | ToCamelCase() |

**Match**

```csharp
var value = "Text";
var valueToCompare = "tEXt";

var result = value.Match(valueToCompare);

Console.WriteLine($"The values are equals? {valueToCompare}.");

// Output
// The values are equals? true.
```

**MaskCharacters**

```csharp
var result = "1458-5885-6263-4554".MaskCharacters('*', 12);

Console.WriteLine($"Value: {result}.");

// Output
// Value: ****-****-****-4554.
```

### ExceptionExtensions

| Return Type | Method |
| --------------- | ------- |
| Dictionary<string, string> | ToDictionary<TException>() |

# Helper methods

### EnumHelper

| Return Type | Method |
| --------------- | ------- |
| TEnum? | GetByDescription<TEnum>(string description)|

### StringHelper

| Return Type | Method |
| --------------- | ------- |
| bool | HasValueInAny(params string[] values) |

**HasValueInAny**

```csharp
    string[] values = { null, "abc", string.Empty };
    var result = StringHelper.HasValueInAny(values);

    Console.WriteLine($"Has value in any? {result}.");

    // Output
    // Has value in any? true.
```

### UrlHelper

| Return Type | Method |
| --------------- | ------- |
| string | UseEndpointFormat(string text) |
| string | Combine(params string[] values) |

**UseEndpointFormat**

```csharp
    var url = UrlHelper.UseEndpointFormat("Jornal DO--métrô");

    Console.WriteLine($"Url: {url}.");

    // Output
    // Url: jornal-do-metro.
```

**Combine**

```csharp
var combinatedUrl = UrlHelper.Combine("http://mysite.com", "resource", "page=1");

Console.WriteLine($"Url: {url}.");

// Output
// Url: http://mysite.com/resource/page=1
```