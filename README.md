SharpGhost
==========

**SharpGhost** is a C# .NET portable class library (PCL) for [Ghost API](http://docs.ghost.org/api/).

Note - this is work in progress. This PCL is not feature complete and some breaking changes and design improvements are likely to happen during the development. The official Ghost REST API is not completed either at the moment. 
If you wish to speed up the development of this library, feel free to open pull requests.

###Logo is also being developed :) ###
![](http://res.cloudinary.com/dvi6ot1t1/image/upload/c_scale,h_105/v1411229870/ghostSmaller_qwplti.png)

## Usage Example:

Authentication:

```csharp

GhostClient ghostClient = new GhostClient("http://GhostBlogDomain");
var authResponse = await ghostClient.AuthenticateWithPasswordAsync(USERNAME, PASSWORD);
```

## Supported platforms

SharpGhost is a **Portable Class Library**, so it's compatible with many different platforms:

- **.NET** >= 4.5 (including WPF)
- **Windows Phone** (Silverlight + WinRT, 8 & 8.1)
- **Windows Store** 8, 8.1

## Dependencies

- [Microsoft.Bcl.Async](https://www.nuget.org/packages/Microsoft.Bcl.Async/)
- [Microsoft.Net.Http](https://www.nuget.org/packages/Microsoft.Net.Http/)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

## Contributors

[![igrali](https://pbs.twimg.com/profile_images/418704900327870464/-njlu79F_bigger.png)](https://github.com/igrali "Igor Ralic")<br />[Igor Ralic](https://igrali.com)

## License

[MIT License](https://github.com/igrali/SharpGhost/blob/master/LICENSE)
