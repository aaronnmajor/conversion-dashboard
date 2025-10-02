# Conversion Dashboard - User Guide

## Getting Started

### Prerequisites
- Windows 10 or later
- .NET 8.0 Runtime or SDK

### Installation
1. Download or clone the repository
2. Open `ConversionDashboard.sln` in Visual Studio 2022 or later
3. Press F5 to build and run the application

Alternatively, from command line:
```bash
dotnet build
dotnet run --project ConversionDashboard/ConversionDashboard.csproj
```

## Application Overview

When you launch the Conversion Dashboard, you'll see:
- **Left Sidebar**: Navigation menu with 6 main sections
- **Main Content Area**: The current view/page
- **Status Bar**: Bottom of sidebar showing current status

## Using Each Section

### 📊 Dashboard
The Dashboard provides an at-a-glance view of your conversion system:

**Statistics Cards** display:
- Total Jobs count
- Active Jobs count  
- Failed Jobs count
- Database connection status

**Recent Activity** shows:
- Latest system events
- Completion notifications
- Warnings and errors

**Quick Actions** let you:
- Run a new conversion
- View logs
- Refresh statistics
- Open settings

### ⚙️ Settings
Configure all aspects of the application:

**General Settings:**
1. Enter your preferred application name
2. Set the working directory (use Browse button to select)
3. Toggle "Start with Windows" if desired
4. Toggle "Minimize to tray" if desired

**Database Settings:**
1. Enter your SQL Server address
2. Enter database name
3. Enter username
4. Adjust connection timeout using the slider
5. Click "Test Connection" to verify settings

**Notification Settings:**
1. Toggle notifications on/off
2. Enable/disable email alerts
3. Enter email recipients (comma-separated)

**Polling Settings:**
1. Select database poll interval
2. Choose dashboard refresh rate

**Saving:**
- Click "Save Settings" to persist your changes
- Click "Reset to Defaults" to restore original settings

### 📁 Quick Access
Quick Access provides easy access to important files and directories:

**Opening Directories:**
1. Click any "Open" button next to a directory path
2. Windows Explorer will open to that location
3. If directory doesn't exist, you'll be prompted to create it

**Managing Files:**
1. Click "Open" to view a file in its default application
2. Click "Edit" to open in Notepad for editing
3. Click "View" to display log files
4. Click "Clear" to empty log files (with confirmation)

**Directory Actions:**
- **Create All Directories**: Creates any missing directories
- **Clean Temp Files**: Removes temporary files
- **Archive Old Logs**: Moves old logs to archive
- **Backup Configuration**: Creates a config backup
- **Refresh Paths**: Reloads all paths from settings

### ⚡ Jobs
Manage and monitor conversion jobs:

**Viewing Jobs:**
1. The DataGrid shows all jobs with their current status
2. Status colors: Green (Running), Blue (Completed), Red (Failed), Orange (Pending)
3. Click any row to see detailed information below

**Running a Job:**
1. Select a job from the list
2. Click "▶️ Run Selected Job"
3. Confirm the action if prompted

**Monitoring:**
1. Click "🔄 Refresh Status" to update the job list
2. Progress is shown as percentage
3. Records processed count updates in real-time

**Other Actions:**
- **Pause**: Temporarily pause a running job
- **Stop**: Terminate a job completely
- **View Logs**: Open the log file for selected job
- **New Job**: Launch the job creation wizard

### 💾 DB Monitor
Real-time database monitoring with multiple views:

**Auto-Refresh:**
1. Toggle "Auto-refresh" checkbox
2. Select refresh interval (5s, 10s, 30s, or 60s)
3. Click "🔄 Refresh Now" for manual refresh

**Active Conversions Tab:**
- Shows currently running conversion jobs
- Displays progress, elapsed time, and user
- Updates automatically based on refresh interval

**Conversion Queue Tab:**
- Lists pending jobs waiting to run
- Shows priority, position, and estimated size
- Helps you track job backlog

**Error Log Tab:**
- Displays recent errors and warnings
- Color-coded by severity (Red=Error, Orange=Warning)
- Click "Clear All" to remove all entries

**Statistics Tab:**
- View summary metrics:
  - Total conversions
  - Success rate percentage
  - Average duration
  - Today's failures
  - Total records processed
  - Data volume
- Chart area for visualizations (placeholder)

**Exporting Data:**
1. Click "📊 Export Data"
2. Choose export location
3. Data saved as CSV or Excel format

### 🎨 Controls
Demonstrates all WPF controls available:

This section is primarily for developers and showcases:
- All button styles (Primary, Success, Danger)
- Text input controls
- Selection controls (CheckBox, RadioButton, ComboBox)
- Range controls (Slider, ProgressBar)
- List controls (ListBox, ListView)
- Date/Time pickers
- Grouping controls (GroupBox, Expander, TabControl)
- Menus and toolbars
- DataGrids
- Status bars and tooltips

## Tips & Best Practices

### Performance
- Set appropriate polling intervals to balance freshness vs. system load
- Use auto-refresh sparingly for large datasets
- Archive old logs regularly to maintain performance

### Organization
- Create the directory structure early using "Create All Directories"
- Keep logs in the designated logs directory
- Back up configuration before making major changes
- Use meaningful job names for easy identification

### Monitoring
- Check the Dashboard regularly for system health
- Review error logs to identify patterns
- Monitor active jobs during peak times
- Keep an eye on database connection status

### Maintenance
- Clear temp files weekly
- Archive old logs monthly
- Back up configuration before updates
- Test database connection after changes

## Troubleshooting

### Application Won't Start
- Ensure .NET 8.0 is installed
- Check Windows version compatibility
- Review error logs in AppData

### Database Connection Failed
1. Verify server address in Settings
2. Check network connectivity
3. Confirm credentials are correct
4. Use "Test Connection" button

### Jobs Not Running
- Check job status in Jobs view
- Review error logs for details
- Verify working directory exists
- Ensure sufficient permissions

### Settings Not Saving
- Check write permissions to AppData folder
- Close and reopen application
- Try "Reset to Defaults" then reconfigure

## Configuration File Location

Settings are stored in:
```
%APPDATA%\ConversionDashboard\config.json
```

You can manually edit this file if needed, but use the Settings page when possible.

## Keyboard Shortcuts

While the application doesn't currently implement custom keyboard shortcuts, standard Windows shortcuts work:
- **Alt + F4**: Close application
- **Tab**: Navigate between controls
- **Space**: Activate buttons
- **Enter**: Confirm actions
- **Escape**: Cancel dialogs

## Support & Feedback

For issues, questions, or suggestions:
1. Check this user guide
2. Review the FEATURES.md for capabilities
3. Check application logs for errors
4. Contact your system administrator

## Version Information

Current Version: 1.0.0  
.NET Framework: 8.0  
Platform: Windows Desktop (WPF)

---

**Note**: This is a demonstration application. Some features show simulated data. In a production environment, these would connect to real databases, file systems, and job execution engines.
