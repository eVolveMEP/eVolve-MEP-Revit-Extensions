# Overview
This project is a Revit addin which utilizes the eVolve MEP Integration Platform API to perform export and import operations between Revit element parameters and CSV files.

**Fun Fact:**
This _exact_ codebase ships with the eVolve products so it serves as a real working sample.

# Project Details
- Compatible with:
  - Revit 2020, 2021, 2022, 2023
  - eVolve Electrical 6.0+
  - eVolve Mechanical 6.0+
- Visual Studio 2022 format

# Building and Running

> These instructions assume you are using Visual Studio and is intended as a getting started guide. You are free to use any build configuration which is best suited for your workflow.

The project includes build configurations for combinations of the compatible environments listed above. For example, the build configuration "eM Release Revit 2021" is configured to compile against _eVolve Mechanical_ on _Revit 2021_ using _Release_ compiler settings.

However, the file paths to the required assembly references will need to be updated to that of your development environment in order to compile. Using the example above, follow these steps:
1. [Open the `.csproj` file for editing](https://stackoverflow.com/a/5129214/3962346)
1. Locate the line containing: `DefineConstants.Contains('REVIT2021')`
1. For each entry within the respective `<ItemGroup>`, update the `<HintPath>` to point to the location of the same file on your computer
    - These files are installed with Revit so in most cases you can update these to point the file in the Revit installation location. For example:
      ```
      <HintPath>C:\Program Files\Autodesk\Revit 2021\RevitAPI.dll</HintPath>
      ```
1. Save the changes to your `.csproj` file and reload it in Visual Studio

You should now be able to compile the project (in this example) for both "eM Debug Revit 2021" and "eM Release Revit 2021". Once the project successfully compiles it will attempt to create the appropriate Revit '.addin' file to have Revit load it from your build output location.
 
 > For '.addin' file generation to succeed Visual Studio may need to be running with elevated permissions. Check your Visual Studio build _Output_ window for any messages.
 
Launch Revit 2021 and when prompted, allow the _eVolveCSVDataExchange-eVolveMechanical.dll_ extension to run (if all went well, the path presented should be the project's build target folder). Once presented with the Revit welcome screen, you can set breakpoints and [attach to the Revit.exe process](https://docs.microsoft.com/en-us/visualstudio/debugger/attach-to-running-processes-with-the-visual-studio-debugger?view=vs-2019#BKMK_Attach_to_a_running_process) to step through the code.

# Important Notes
- You must have a license of the respective eVolve MEP product this is built against in order to communicate with the Integration Platform API.
- Project license information for this source code is included within the **LICENSE** file.