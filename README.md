# ListenNotesSearch

A .NET Standard wrapper for Listen Node API.

[Listen Notes]() is a new and powerful podcast search engine.

With this library you can easy consume the API using .NET.

## How to install

To use the library just install the [NuGet package]() or build it from source.

## Usage

The library offers a `ListenNotesSearchClient`, which is used to make REST-Requests to the API.

We just need to create an instance passing our API Key:

```csharp
var apiKey = "87e9fiuj9ewf8wez7f98ewuf" //Your Listen Notes Api Key
var client = new ListenNotesSearchClient(apiKey);
```

 