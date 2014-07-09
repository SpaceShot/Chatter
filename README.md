Chatter
=======

Demonstrates "cross platform" SignalR by creating different platform apps


Projects
--------

###ChatterWeb###
This project started life as an Empty Web Project.  I added a SignalR Hub Class via the tooling with "Add New Item" and an OWIN Startup Class.  This automatically adds several NuGet packages that enable SignalR support.

What you want to look at is:

default.html : demonstrates JavaScript client setup to connect to a SignalR Hub.

ChatHub.cs : Demonstrates creating a simple SignalR hub, which I like to say is "just a class with public methods that derives from Microsoft.AspNet.SignalR.Hub".

Startup.cs : SignalR embraces OWIN and you "setup" your SignalR hubs with one simple line of code in an Owin startup class.

When you create a web project, Visual Studio picks a random port for use with IIS Express. I didn't bother changing it, but you need to know it later (for your versions to run on other platforms).

For ease of use set default.html as your start page or make sure when you run the app you point your browser at: http://localhost:51942/

####Note####
I actually do not recommend letting the tooling add your NuGet packages in the long run.  It's okay for learning or to see "how it works" but you can get into trouble if different developers on your team do this and are at different update releases of the tools.

###ChatterWindowsStore###
This is a Windows 8.1 Store App that will connect to a running SignalR server and thw two apps can chat with each other!

###Running multiple apps for cross platform chatter###
Make sure you run ChatterWeb first so that IIS Express is running and available.  In this sample I did not separate the web client from the web server (they are both in ChatterWeb).  Many ASP.NET project worked this way historically and likely still do.  You may be very comfortable with this model, so I didn't touch it.
