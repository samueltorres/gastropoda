# Gastropoda Slugifer

> A very fast C# Slugifer

Even though a slug is slow `(no pun intended)`, this package allow you to "slugify" a phrase very fast

## Why ?

In the internet you should have very clean URL's so you need to use characters that are a-zA-Z0-9.
This comes to solve this in a very fast way.

It transforms something like this:
`"coração ûltimatœ"` into `"coracao-ultimatoe"` which is awesome.

## How to use ?
1. Install Gastropoda via NuGet: [![NuGet](https://img.shields.io/nuget/v/Gastropoda.svg)](https://www.nuget.org/packages/MoqMeUp/)
2. Import the namespace Gastropoda
3. Apply the extension Slugify on a String

```c#
    string item = "coração ûltimatœ"; 
    string slugifiedItem = item.Slugify();
```
