# CyberArk.PSM.GenerateTOTPPreconnect

A [PreConnect DLL](https://docs.cyberark.com/PAS/12.2/en/Content/PASIMP/psm_WebApplication_Preconnect.htm?tocpath=Developer%7CCreate%20extensions%7CPSM%20Connectors%7CWeb%20applications%20for%20PSM%7C_____1) for CyberArk's Privileged Session Manager that can be used to generate a TOTP. Tested on PSM version 12.2.

## Building the DLL

Simply build the solution inside of Visual Studio 2022.

## Using the Preconnect DLL

1. Copy the PreConnect DLL to `PSM/Components/`.
2. Add the `LogonAccount` capability to the Connection Component under `Component Parameters > Target Settings > Supported Capabilities`.
3. Configure the connection component as described [in the documentation](https://docs.cyberark.com/PAS/12.2/en/Content/PASIMP/psm_WebApplication_Preconnect.htm?tocpath=Developer%7CCreate%20extensions%7CPSM%20Connectors%7CWeb%20applications%20for%20PSM%7C_____1#Codeandconfigurationsample). Use `CyberArk.PSM.GenerateTOTPPreconnect.dll` for the `PreConnectDllName` value and `logonaccount_password` for the `PreConnectParameters` value.
4. Use `&MfaCode&` in the connection component's WebFormFields when you want to inject the TOTP.
