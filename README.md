# Gastropoda Slugifer

> A very fast C# Slugifer

Even though a slug is slow `(no pun intended)`, this package allow you to "slugify" a phrase very fast

## Why ?

In the internet you should have very clean URL's so you need to use characters that are a-zA-Z0-9.
This comes to solve this in a very fast way.

It transforms something like this:
`"coração ûltimatœ"` into `"coracao-ultimatoe"` which is awesome.

## How to use ?

Just import the Gastropoda Extension and :

```c#
    string item = "coração ûltimatœ"; 
    string slugifiedItem = item.Slugify();
```
