$commit = git rev-parse HEAD
$env:CaravelaDocGitCommit = $commit

nuget restore -OutputDirectory packages
packages\docfx.console.2.56.6\tools\docfx.exe metadata
packages\docfx.console.2.56.6\tools\docfx.exe build

If(!(test-path "output" ))
{
   New-Item -ItemType Directory -Force -Path "output"
}

Compress-Archive -Path _site\* -DestinationPath "output\Caravela.Doc.zip" -Force