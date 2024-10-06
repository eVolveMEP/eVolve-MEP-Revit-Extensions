# Overview
This repository contains Revit addins which utilize the eVolve MEP Revit Integration Platform API.

Project | Description
--- | ---
eVolveMEP CSV Data Exchange | Performs export and import operations between Revit element parameters and CSV files.
eVolveMEP Data Table Tools | Advanced tools for manipulating and importing/exporting data within eVolve Data Tables.

**Fun Fact:**
This _exact_ codebase ships with the eVolve Revit products so it serves as a real working sample.

# Project Details
- Compatible with:
  - Revit 2022, 2023, 2024, 2025
  - eVolve Electrical 8.0+
  - eVolve Mechanical 8.0+
- Visual Studio 2022 format

# Building and Running
This project uses private Nuget packages to source the Autodesk Revit binaries referenced by the code. In order to build this in an external environment, the appropriate `ConditionalTargets/Revit` sources (which all come from the respective Revit install folder) need to be explicitly referenced by the project.

# Important Notes
- You must have a license of the respective eVolve MEP Revit product the project is built against in order to communicate with the Revit Integration Platform API.
- License information for this source code is included within the **LICENSE** file.