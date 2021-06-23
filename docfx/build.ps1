param ( $step )

$ErrorActionPreference = "Stop" 

function RemoveLockedFiles()
{
    # Delete the output soon because it may be locked.
    if ( test-path "output\Caravela.Doc.zip")
    {
       del "output\Caravela.Doc.zip"
    }

}

function Clean()
{

    RemoveLockedFiles

 
    # Delete temporary files (disable incremental build)
    if ( test-path "obj" )
    {
       rd "obj" -Recurse -Force
    }

}

function Restore()
{

    nuget restore -OutputDirectory packages
}

function Metadata()
{

    packages\docfx.console.2.58.0\tools\docfx.exe metadata

    if ($LASTEXITCODE -ne 0 ) { throw "docfx metadata failed." }
}

function BuildExtensions()
{
    dotnet build "..\code\Caravela.Documentation.DfmExtensions\Caravela.Documentation.DfmExtensions.csproj"

    if ($LASTEXITCODE -ne 0 ) { throw "Building DfmExtensions failed." }
}

function RunTests()
{
    dotnet test "..\code\Caravela.Documentation.SampleCode.sln"

    if ($LASTEXITCODE -ne 0 ) { throw "docfx metadata failed." }
}

function BuildDoc()
{
    packages\docfx.console.2.58.0\tools\docfx.exe build
    

    if ($LASTEXITCODE -ne 0 ) { throw "docfx build failed." }
}

function Publish()
{

    if (!(test-path "output" ))
    {
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
switch ( $step )
{
    $null 
    {
        Prepare
        BuildDoc
        Publish
    }

    "build"  # This build target skips the Prepare step.
    {
    RemoveLockedFiles
    BuildDoc
    Publish
    }

}
