param(
	[string]$path
)

$isAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $isAdmin) {
	$testFile = Join-Path $path ([System.IO.Path]::GetRandomFileName())
	try {
		New-Item $testFile -ErrorAction Stop
		Remove-Item $testFile -Force
		return
	} catch {
		# Not writable - needs elevation to grant permissions
	}
	Add-Type -Assembly System.Windows.Forms 
	[System.Windows.Forms.MessageBox]::Show("There will be a UAC prompt for PowerShell to change the permissions of the addin directory. This should only happen once per Revit release year.")
	Start-Process powershell.exe -Verb RunAs -ArgumentList "-ExecutionPolicy Bypass -File `"$($MyInvocation.MyCommand.Path)`" `"$path`"" -Wait
	return
}

New-Item $path -ItemType Directory -Force
$acl = Get-Acl -Path $path
$acl.SetAccessRule([System.Security.AccessControl.FileSystemAccessRule]::new("BUILTIN\Users", [System.Security.AccessControl.FileSystemRights]::FullControl, [System.Security.AccessControl.InheritanceFlags]::ContainerInherit -bor [System.Security.AccessControl.InheritanceFlags]::ObjectInherit, [System.Security.AccessControl.PropagationFlags]::None, [System.Security.AccessControl.AccessControlType]::Allow))
Set-Acl -Path $path -AclObject $acl
