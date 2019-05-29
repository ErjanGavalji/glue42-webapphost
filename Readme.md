WPF-to-browser through app context window launcher
===

# Purpose
A set of demo projects, demonstrating an approach to load/reuse browser windows
started from a WPF application via Glue42.

# Approach
## In WPF
1. Getting a reference to an application, registered in the Glue42 Desktop
platform (or starting the app if no reference)
2. Setting the application context to pass a URL through it

## In HTML/JavaScript
1. Read the URL from the application context
2. Set it to the IFrame source
3. Subscribe to context changes and update IFrame source
4. Subscribe to layout changes and pass the URL to preserve in context

# Run
1. Start Glue42 Desktop
2. Load the DotNetCaller projet in Visual Studio and rebuild in Debug mode
   > If in release, modify the path in the `deploy\deploy.bat` file
3. Run the `deploy\deploy.bat` file to have the configs and files copied
4. under the Glue42 library with a web server available to serve the JavaScript
file.
5. Use the App Manager (launchpad) to run the *WPF-to-Host Web App loader*
application
6. Use the two buttons to load the windows
7. Change the code in `MainWindow.xaml.cs` by invoking `ReuseAppWithURL`
instead of `StartAppWithURL` to reuse the same browser window