⚠️WARNING: This client is deprecated⚠️ 

# c-sharp-client-directkit-xml

This example show how to consume [LemonWay API XML WebService](http://documentation.lemonway.fr/api-en) using C# .NET framework 4.6

# Instructions

1.  Clone or download this repository.

2.  Open the solution then you can build and run it immediately.

3.  There is 2 way to generate the SOAP classes

- Use Visual Studio to add a new "Service Reference" to your project. [Here](http://documentation.lemonway.fr/pr/tutorials/net-tutorials/net-tutorial-consume-api-xml-webservice) is a step-by-step guide.
- Or use the [svcutil.exe](https://docs.microsoft.com/en-us/dotnet/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe) command line (accessible from the WinStart menu > "Developer Command Prompt for VS"). For eg:

```
svcutil https://sandbox-api.lemonway.fr/mb/demo/dev/directkitxml/service.asmx?wsdl /o:path_to_generated_codes\DirectkitXmlService.cs /sc /n:*,Lemonway.DirectkitXml
```

4.  **Note**:

- Please make sure that you use **DirectkitXML**, not Directkit or DirectkitJSON (the URL should finish with **_directkitxml/Service.asmx_**).
- If you have an error _403 Forbidden_, you have to contact Lemonway support to whitelist your IP address.
- The LemonWayAPI reference may be not up-to-date in this repository. You have to follow the tutorial above to update the service reference.

5.  Now it's your turn to play with other methods.

# Error: Cannot obtain Metadata

If for some reason, you got error while Adding the "Service Reference", maybe there is something wrong with your VS, so you can try to run the above `svcutil.exe`

- if `svcutil.exe` work then the problem is your VS
- if `svcutil.exe` return a big error message of kind `Error: Cannot obtain Metadata... An error occurred while making the HTTP request.. This could be due to the fact that the server certificate is not configured properly with HTTP.SYS in the HTTPS case...`. Then [here is the solution](https://stackoverflow.com/a/54722115/347051):

On your machine developer (which got Visual Studio)

step 1) Run "regedit", Add the following registry settings DWORD value as 1

```
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\v4.0.30319\SchUseStrongCrypto
HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\.NETFramework\v4.0.30319\ SchUseStrongCrypto
```

step 2) restart the machine to Apply the new setting

You should be able to add the WebService Reference to your visual studio now (or manually generate the code with svcutil.exe).
