# Kentico Xperience 13 Xpandable section

[![Stack Overflow](https://img.shields.io/badge/Stack%20Overflow-ASK%20NOW-FE7A16.svg?logo=stackoverflow&logoColor=white)](https://stackoverflow.com/tags/kentico)

| [![NuGet](https://img.shields.io/nuget/v/KenticoXperience.AspNetCore.XpandableSection.svg)](https://www.nuget.org/packages/Kentico.Xperience.AspNetCore.XpandableSection) | NuGet package for your MVC project |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------------------: |

A [Kentico Xperience 13](https://xperience.io/) section that allows editors to create any section layout that they want, with no code or configuration.

This repository contains the source code for the section and its form component.

## Description

This is a Kentico Xperience 13 section that allows editors to create any section layout that they want, with no code or configuration. By adding the section to a page, an editor can open the section properties and add widget zones and name them (for CSS). The editor can also change the direction (horizontal or vertical).

## Requirements and prerequisites

- _Kentico Xperience 13_ installed.
  - Only the ASP.NET Core development model is supported.

## Installation

1. Use Visual Studio to open the solution with your MVC project.
1. In the **NuGet Package Manager Console**, run `Install-Package Kentico.Xperience.AspNetCore.XpandableSection`.
1. Build and run in IIS Express, or publish the project to local IIS.
1. Run the Kentico Xperience 13 administration and open **Pages**.
1. Navigate to a page with the page builder feature.
1. Add _Xpandable section_ to an editable area.

## Localization

This section uses the following resource strings:

| Codename                             | Default value                                                                                                                                                                                                                      |
| ------------------------------------ | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `xpandablesection.section`           | Xpandable section                                                                                                                                                                                                                  |
| `xpandablesection.layout`            | Section layout                                                                                                                                                                                                                     |
| `xpandablesection.formcomponent`     | Xpandable section form component                                                                                                                                                                                                   |
| `xpandablesection.widgetzone`        | widget zone                                                                                                                                                                                                                        |
| `xpandablesection.add`               | Add a new zone                                                                                                                                                                                                                     |
| `xpandablesection.remove`            | Remove this zone                                                                                                                                                                                                                   |
| `xpandablesection.cancelremove`      | Cancel removing this zone                                                                                                                                                                                                          |
| `xpandablesection.confirmremove`     | Confirm removing this zone                                                                                                                                                                                                         |
| `xpandablesection.removemessage`     | Warning! Widgets in this zone may get lost or moved.                                                                                                                                                                               |
| `xpandablesection.name`              | Name...                                                                                                                                                                                                                            |
| `xpandablesection.direction`         | Change direction                                                                                                                                                                                                                   |
| `xpandablesection.styles`            | Custom styles                                                                                                                                                                                                                      |
| `xpandablesection.stylesexplanation` | Enter valid CSS that matches the section layout you have defined. The section is contained in an element with class 'xpandable'. For example, if a widget zone is named 'col4', you can write a rule selecting '.xpandable .col4'. |
