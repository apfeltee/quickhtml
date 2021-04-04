
QuickHTML is meant for quickly viewing HTML files, markdown files, and/or urls.  
Anything Internet Explorer supports is also supported by QuickHTML.  

Beware, however: It's *not* meant to replace your browser. It's a hack that got out of hand.

General usage:

- open a local HTML document:

```
quickhtml some/local/file.html
```

- open a text file, wrapping it in `<pre>` tags:
```
quickhtml -pre some/text/file.txt
```

- open a markdown file (uses [MarkDig](https://github.com/xoofx/markdig)):
```
quickhtml -markdown some/markdown/file.md
```

- open a URL:
```
quickhtml http://example.com/
```


Todo:

    - zero GUI controls. minimal keyboard controls. at least the latter needs implementing!

    - title tags are ignored - should be trivial to do, actually.

    - files are read as whole into memory. fine for small files, not so fine for big files.


Roadmap:

    - implement dumping document object, similarly to what SingleFile does? (does IEX even permit this?)
