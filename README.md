# EnhancedLogger

A utility class for logging messages with customizable log levels and colors in Unity.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Downsides](#downsides)
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Tests](#tests)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This Unity project provides a flexible and customizable logging utility named `Log`. It allows you to log messages with different log levels (Error, Warning, Debug, Success, Info) and customize the appearance of log messages with colors. The utility is designed to be easy to integrate into your Unity projects.

## Features

- Log messages with various log levels.
- Customize log message appearance with colors.
- Control logging behavior based on the current log level.
- Unity Editor and Development Build aware.
- Click to go to the source of the log message.

## Downsides
- The first lines in the Console are reserved for the Log utility. This means that the first lines of your own logs will be pushed down. Not so handy when you want to click to the code that generated the log message. 

## Installation

### Unity Package Manager

1. Open your Unity project.
2. Open the Unity Package Manager from the `Window` menu.
3. Click the `+` button at the top-left corner of the Package Manager window.
4. Select `Add package from git URL...`.
5. Enter the following Git URL in the input field: `https://github.com/mrstruijk/EnhancedLogger.git`
6. Click the `Add` button.

## Manual Installation

If you prefer manual installation, clone or download [the repository](https://github.com/mrstruijk/EnhancedLogger) to your local machine.

## Usage

1. Add the `Log.cs` script to your Unity project.
2. Use the `Log` class to log messages in your scripts.

```csharp
using UnityEngine;
using mrstruijk.EnhancedLogger;

// Log messages with different levels. Note that depending on the CurrentLogLevel, maybe not all messages will be logged.
public class Example : MonoBehaviour
{
    public GameObject OtherGameObject;
    void Start()
    {
        // Standard way of logging is using 'this' as the first parameter. This will log the message from the current gameobject.
        this.Debug("This is a debug message.");
        this.Warning("This is a warning message.");
     
        // Another objcet could serve as well.   
        OtherGameObject.Success("This is a success message. It is called from another gameobject");
        
        // These are useful when the object you're calling the Log from has been destroyed. Be careful with the second one, thay may cause a NullReferenceException anyway.
        Log.Info("Provide a name here", "This is an info message.");
        Log.Error(nameof(SomeObscureClass), "This is an error message.");
    }
}
``` 
    
## Examples

Examples are in the Demo folder.

## Tests

You can find tests in the LogTests.cs file.
This project includes tests to ensure the functionality of the Log utility. To run the tests, open the Unity Test Runner and execute the tests from there.

## Contributing

If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
Feel free to modify the content based on your project's specifics, and add any additional sections or information as needed.