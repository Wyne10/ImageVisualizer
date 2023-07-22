# ImageVisualizer

## Overview
This is a first project in a series of projects that i will be making in a process of **learning C# (again...)**. I decided to write some ideas that randomly appear in my head and gradually update them as i get better in language.

## About project
This project is a simple image visualizer that uses console colors and symbols to draw any image in console. This idea is pretty useless but i made it anyway and while making it i came up with a better idea that i will probably develop later. 

## Highlights
I really tried my best to make code extensible and i think i made pretty good job with property system as you can easily add, get properties and probably create more property reader systems. Right now all the properties obtained via user input in console but it should be easy to make something like JSON property reader (which is not needed in current project state).

## Features
- Parse any image and draw them using colored symbols
- Scale images so their symbol projection can fit in console window
- User can select visualization symbol
- English and russing localizations

## Known issues
- .NET doesn't provide method to set any RGB or HEX color values to console text, so my program is restricted to [ConsoleColor](https://learn.microsoft.com/ru-ru/dotnet/api/system.consolecolor?view=net-7.0) enum. Program converts pixel RGB color to ConsoleColor using some code i took from StackOverflow. This alghorithm is pretty bad so it makes incorrect colors almost always, i don't know if there is a way to make superior algorithm that will be more precise, but the only idea i came up with is to match every [Color.KnownColor](https://learn.microsoft.com/ru-ru/dotnet/api/system.drawing.knowncolor?view=net-7.0) enum value to ConsoleColor enum values, but it doesn't worth time so i won't do this.
- I don't like my implementation of image compressor. I made height, width compressors and compressor that combines width and height. I decided to split width and height in favour to extensiability but both HeightCompressor and WidthCompressor classes voilate DRY principle even though i tried to fix it in ChunkCompressor class.
- Currently [18ee105](https://github.com/Wyne10/ImageVisualizer/commit/18ee105) i have my Properties class made as singleton but i think it can be made as DI-Container. I don't know how to implement DI-Container yet so i think it will be fixed later.

## Updates that will not be implemented
I wanted to add options to automatically scale console window to fit drawn image and to automatically calculate compression ratio for image to fit console window. But apperantly i have to use some win32 api calls to get window resolution and i dont want to make it in this project.

## Updates that will be implemented (_maybe_)
I want my program to start image scaling process asynchronously as soon as user inputs image path and compression ratio but i'm not sure how to do it with current code structure without violating any code design principle.


