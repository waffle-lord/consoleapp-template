# consoleapp-template
A dotnet console app VS template with Serilog and DI setup

# To Use
1. Download the consoleapp-template.zip file from [releases](https://github.com/waffle-lord/consoleapp-template/releases)
2. Extract the zip to `%userprofile%\Documents\Visual Studio 2022\Templates\ProjectTemplates`
3. Start Visual Studio and select `Console App with Serilog and DI` when creating a new project

![image](https://github.com/waffle-lord/consoleapp-template/assets/76401815/59bf39f8-5887-4adc-bddd-d08958c34057)

The default logging sends to console while debugging, but release will log to console and file in the directory the program is ran.

## The default log output looks like this
### Console
![image](https://github.com/waffle-lord/consoleapp-template/assets/76401815/0d42306f-fe34-4390-bc6f-dd69863687a8)

You can modify the console logging format by changing the outputFormat and theme in `Logger.cs`
https://github.com/waffle-lord/consoleapp-template/blob/b718972cd630113f62b6b9411fd5ae48320348b7/consoleapp-template/Logging/Logger.cs#L68

### File
The log file changes daily by default and can be found at `<current directory>\Logs\<safeprojectname>_<date>.txt`
![image](https://github.com/waffle-lord/consoleapp-template/assets/76401815/e29be4e6-6b2d-41e5-b7cb-e4e37f0f1c2d)

You can modify the file logging format in `FileFormatter.cs`
https://github.com/waffle-lord/consoleapp-template/blob/b718972cd630113f62b6b9411fd5ae48320348b7/consoleapp-template/Logging/LogFormatters/FileFormatter.cs#L29
