# XorInterceptor
A .NET Interceptor which does a simple XOR encryption at compile time, without embedding the plaintext literal in your IL.
It scans the syntax tree for calls named `Xor` with zero arguments. It retrieves the interceptable location from the compiler and it will emit the interceptor method, instead of the original call.

> ⚠️ This currently requires .NET 9

![devenv_wzIwCFKn4b](https://github.com/user-attachments/assets/6669c774-ac62-452c-b99b-cdb9ab623d13)

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

You can take a look at the console application included, however it is nothing more than:

```csharp
using static XorInterceptor.XorEncryption;

var encryptedString = Xor( /*"Hello, World"*/);
Console.WriteLine(encryptedString);
```

Now each time you (re)build your project the encryption changes.

> ⚠️ This is of course very easy to undo, since both the encrypted data and the key are next to eachother. It is more a proof of concept.
<img width="1100" height="900" alt="image" src="https://github.com/user-attachments/assets/731019b2-acd2-4f00-a2ce-e61d05bb33f1" />

## References
* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#interceptors
* https://andrewlock.net/creating-a-source-generator-part-11-implementing-an-interceptor-with-a-source-generator/
