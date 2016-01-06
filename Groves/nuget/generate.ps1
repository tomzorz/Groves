$releaseNotesUri = 'https://github.com/tomzorz/Groves/wiki/Release-Notes'
$nugetFileName = 'nuget.exe'
$nuspecPath = 'Groves.nuspec'
$assemblyPath = '../Groves/bin/Release/Groves.dll'

Write-Host 'Groves NuGet packaging script'
Write-Host '-----------------------------'
Write-Host ''
Write-Host -NoNewLine 'Looking for nuget: '
if (!(Test-Path $nugetFileName))
{
    Write-Host 'Not found, downloading!'
    (New-Object System.Net.WebClient).DownloadFile('http://nuget.org/nuget.exe', $nugetFileName)
}
else 
{
	Write-Host 'Found!'
}
Write-Host 'Packaging...'
if ((Test-Path $assemblyPath))
{
    $fileInfo = Get-Item $assemblyPath
    $coreFileVersion = $fileInfo.VersionInfo.ProductVersion
    Invoke-Expression ".\$($nugetFileName) pack $($nuspecPath) -Prop version=$($coreFileVersion) -Prop releaseNotes=$($releaseNotesUri)" 
    Write-Host 'Packaging successful!'
}
else
{
    Write-Host 'Groves.dll not found.'
}
Write-Host ''
Write-Host -NoNewLine 'Press any key to quit...'
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');