# XorInterceptor
A .NET Interceptor which does a simple XOR encryption at compile time, without embedding the plaintext literal in your IL.
It scans the syntax tree for calls named `Xor` with zero arguments. It retrieves the interceptable location from the compiler and it will emit the interceptor method, instead of the original call.

> ⚠️ This currently requires .NET 9

![devenv_wzIwCFKn4b](https://i.imgur.com/Pa4DQ9U.gif)

## Installation
### Option A — NuGet (recommended)

### [NuGet](https://www.nuget.org/packages/XorInterceptor/)
#### .NET CLI
    dotnet add package XorInterceptor
#### Package Reference
    <PackageReference Include="XorInterceptor" Version="1.0.*" />

## Option B — Local project reference

```xml
  </PropertyGroup>
    <!-- ... -->
    <InterceptorsNamespaces>$(InterceptorsNamespaces);XorInterceptor</InterceptorsNamespaces>
    <XorBuildSeed>$([System.Guid]::NewGuid().GetHashCode())</XorBuildSeed>
  </PropertyGroup>

  <ItemGroup>
    <CompilerVisibleProperty Include="XorBuildSeed" />
    <ProjectReference Include="..\XorInterceptor\XorInterceptor.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
  </ItemGroup>
```

## Usage

The most important requirement is how you write the string.
You do not pass the string as a normal argument.
Instead, you must place it inside a multi-line comment inside the Xor() call:

```csharp
using static XorInterceptor.XorEncryption;

var encryptedString = Xor(/*"Hello, World"*/);
Console.WriteLine(encryptedString);
```

Now each time you (re)build your project the encryption changes.

> ⚠️ This is of course very easy to undo, since both the encrypted data and the key are next to eachother. It is more a proof of concept.
<img width="1100" height="900" alt="image" src="https://i.imgur.com/SsnOKh8.png" />

## References
* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#interceptors
* https://andrewlock.net/creating-a-source-generator-part-11-implementing-an-interceptor-with-a-source-generator/
