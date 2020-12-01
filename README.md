A simple prototype of basic 2D game
- a player character, moved by WSAD keys
- camera that follows the player or, if possbile, also can be moved using arrow keys
- camera can also be zoomed in and out (E and Q keys)
- Basic collision between the player and the objects
It is very simple and NOT finished, I made this when I started to learn Monogame (basically XNA) but the academic year has started and the lack of time forced me to drop it and leave it as is.

From me personal experience it can be very hard to migrate Monogame projects between diffrent computers, especially between Linux distro and Windows. The easiest way to do this is:
1) create new Monogame project in Visual Studio 2019 (requires Monogame obviously)
2)  add every .cs file from my project to the newly created one
3) copy Content folder (rebuilding assets may be requied; this can be done using Monogame build-in pipeline tool – open Content.mgcb and then just select every *.png file in the same folder, and simply click build all).
4) make sure the namespaces line up
5) then it should compile and run just fine – if VS2019 doesn’t want to/ doesn’t recognize Monogame (which happend to me most of the times) type in cmd/terminal dotnet build to build and dotnet run to run.
