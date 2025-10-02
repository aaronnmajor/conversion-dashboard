# Conversion Dashboard

A fully functional Windows desktop application built with WPF (.NET 8) that facilitates conversion-related tasks.

## Features

- **Dashboard**: Overview of conversion jobs with real-time statistics
- **Settings Management**: Configure application, database, notifications, and polling settings
- **Quick Access**: Easy access to important directories (logs, config, output, archive) and files
- **Jobs Management**: Run, monitor, pause, and stop conversion jobs with detailed progress tracking
- **Database Monitor**: Real-time monitoring of database tables with auto-refresh capabilities
  - Active conversions tracking
  - Job queue management
  - Error log monitoring
  - Conversion statistics
- **Controls Showcase**: Demonstrates all major WPF controls including buttons, text inputs, selection controls, data grids, and more

## Requirements

- Windows OS
- .NET 8.0 or later

## Building and Running

1. Clone the repository
2. Open the solution in Visual Studio 2022 or later
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

Or use the command line:

```bash
dotnet build
dotnet run --project ConversionDashboard/ConversionDashboard.csproj
```

## Project Structure

- **Views**: All UI pages (Dashboard, Settings, Quick Access, Jobs, Database Monitor, Controls Showcase)
- **Models**: Data models for configuration, jobs, and monitoring
- **Services**: Configuration management service
- **Styles**: Modern UI styling with consistent color scheme

## UI Design

The application features a modern, clean design with:
- Dark sidebar navigation
- Card-based layouts
- Color-coded status indicators
- Responsive controls
- Professional color scheme (blues, greens, oranges, reds)