param ( [switch] $incremental = $false, [switch] $pack = $false )

$ErrorActionPreference = "Stop" 

function RemoveLockedFiles()
{
    gcim win32_process | where { $_.Name -eq "iisexpress.exe" } | foreach { 
        Stop-Process -ID $_.ProcessId 
        Start-Sleep  -Seconds 1
    }

    # Delete the output soon because it may be locked.
    if ( test-path "output\Caravela.Doc.zip") {
       del "output\Caravela.Doc.zip"
    }

}

function Clean()
{

    RemoveLockedFiles

 
    # Delete temporary files (disable incremental build)
    if ( test-path "obj" ) {
       rd "obj" -Recurse -Force
    }

    if ( test-path "_site" ) {
       rd "_site" -Recurse -Force
    }

}

function Restore()
{

    nuget restore -OutputDirectory packages

    if ($LASTEXITCODE -ne 0 ) { exit }
}

function Metadata()
{

    packages\docfx.console.2.58.0\tools\docfx.exe metadata --property TargetFramework=netstandard2.0

    if ($LASTEXITCODE -ne 0 ) { exit }
}

function BuildExtensions()
{
    dotnet build "..\code\Caravela.Documentation.DfmExtensions\Caravela.Documentation.DfmExtensions.csproj"

    if ($LASTEXITCODE -ne 0 ) { exit }
}

function RunTests()
{
    dotnet restore "..\code\Caravela.Documentation.SampleCode.sln"

    if ($LASTEXITCODE -ne 0 ) { exit }

    dotnet test "..\code\Caravela.Documentation.SampleCode.sln"

    # We tolerate failing tests for now.
  #  if ($LASTEXITCODE -ne 0 ) { exit }
}

function BuildDoc()
{
 
   packages\docfx.console.2.58.0\tools\docfx.exe build
    
   if ($LASTEXITCODE -ne 0 ) { exit }
}

function Pack()
{

    if (!(test-path "output" )) {
       New-Item -ItemType Directory -Force -Path "output"
    }

    Compress-Archive -Path _site\* -DestinationPath "output\Caravela.Doc.zip" -Force
}

function Prepare()
{
    Clean
    Restore
    Metadata
    BuildExtensions
    RunTests
}

# Main build sequence
if ( $incremental )
{
    BuildDoc
}
else
{
    Prepare
    BuildDoc
}

if ( $pack )
{
    Pack
}