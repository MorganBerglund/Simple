# Simple API with CI-CD on Microsoft Azure

Minimum viable product showcase.

The simplest possible API with swagger & swashbuckle under .net5.
A test project is also included in order to show and trie out simplest possible test.


Test and build release.

``` yml
trigger:
- main

pool:
  vmImage: 'Ubuntu-16.04'

variables:
  buildConfiguration: 'Release'

steps:
- task: DotNetCoreCLI@2
  inputs:
   command: test
   projects: '**/*Test/*.csproj'
   arguments: '--configuration $(buildconfiguration)'
 
- script: dotnet build --configuration $(buildconfiguration)
  displayName: 'dotnet build $(buildconfiguration)'
```

Publish the release.
``` yml

- task: DotNetCoreCLI@2
  displayName: 'dotnet publish --configuration $(buildConfiguration) --output $(Build.ArtifactStagingDirectory)'
  inputs:
    command: publish
    publishWebProjects: false
    projects: '**/*API/*.csproj'
    arguments: '--configuration $(BuildConfiguration) --output $(Build.ArtifactStagingDirectory)'
    zipAfterPublish: true

- task: PublishBuildArtifacts@1
  displayName: 'publish artifacts'
```

The hosting is closed at the moment for this release. 
Otherwise it was available on:
https://morgansimpleapi.azurewebsites.net/WeatherForecast



