
all:
	csc -r:System.Memory.dll -r:Markdig.dll -out:quickhtml.exe main.cs

