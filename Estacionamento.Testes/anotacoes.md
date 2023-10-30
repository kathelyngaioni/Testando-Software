Para fazer referência do xnuit com o projeto foi preciso modificar o arquivo Estacionamento.Testes.csproj

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.5.0" />
    <PackageReference Include="xunit" Version="2.4.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.5">
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="coverlet.collector" Version="3.2.0">
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <ProjectReference Include="Estacionamento/Estacionamento.csproj" />
</ItemGroup>
<ItemGroup>
    <Compile Include="../Estacionamento/Modelos/**/*" />
</ItemGroup>

</Project>

```