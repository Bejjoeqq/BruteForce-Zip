# BruteForce-Zip

A Windows Forms utility for recovering and extracting password-protected `.zip` archives by trying candidate passwords.

## Disclaimer

Use this software only on archives you own or are explicitly authorized to access.  
Unauthorized password cracking may be illegal and unethical.

## Features

- Select a target ZIP archive and extraction folder from the GUI.
- Brute-force mode with configurable character sets:
  - lowercase letters (`a-z`)
  - uppercase letters (`A-Z`)
  - numbers (`0-9`)
  - symbols (`!@#$%^&*()-_=+{[}]|:;<>,.?/`)
- Custom wordlist mode (load password candidates from a `.txt` file).
- Automatic extraction when a valid password is found.
- Console output to show attempted passwords and result status.

## Tech Stack

- Language: C#
- UI: Windows Forms
- ZIP library: [DotNetZip](https://www.nuget.org/packages/DotNetZip/)
- Target framework: .NET Framework 4.5.2

## Repository Structure

- `BruteForceZip.sln` - Visual Studio solution.
- `BruteForceZip/BruteForceZip.csproj` - WinForms project file.
- `BruteForceZip/Form1.cs` - Main brute-force and wordlist logic.
- `BruteForceZip/Form1.Designer.cs` - UI layout and controls.
- `packages/` - checked-in DotNetZip package artifacts.

## Requirements

- Windows OS (WinForms desktop app).
- Visual Studio with support for **.NET Framework 4.5.2** development.
- .NET Framework 4.5.2 targeting pack / developer pack installed.

> Note: Building on Linux/macOS with `dotnet build` typically fails because .NET Framework 4.5.2 reference assemblies are Windows-specific.

## Build and Run

1. Open `BruteForceZip.sln` in Visual Studio.
2. Restore NuGet packages if prompted.
3. Build the solution (`Build > Build Solution`).
4. Start the application (`F5` or `Ctrl+F5`).

## Usage

### 1) Choose archive and extraction path

1. Click the `...` button next to **Zip File** and select a `.zip` file.
2. Click the `...` button next to **Target Directory** and select output folder.

### 2) Select password search mode

Choose one of the following:

- **Brute-force by character set**
  1. Select one or more area checkboxes (`a-z`, `A-Z`, `Numbers`, `Symbols`).
  2. Set maximum password length using **Password Length : 1 - [N]**.
  3. Click **Go!**.

- **Custom wordlist**
  1. Click the `...` button next to **Custom** (labeled **Custome :** in the current UI) and choose a `.txt` file.
  2. The app disables area/length settings and tests each line as a password.
  3. Click **Go!**.

### 3) Observe output and results

- The app opens a console window and prints tried passwords.
- On success, it extracts files to the target directory and shows a confirmation.
- If no password matches, it prints `Password not found`.

## How It Works (High Level)

- For brute-force mode, the app builds a character pool from selected checkboxes and recursively generates candidates.
- For wordlist mode, it reads all lines from the selected text file and tests each candidate.
- Password checks use `ZipFile.CheckZipPassword(...)` from DotNetZip.

## Known Limitations

- GUI only (no command-line interface).
- No pause/resume or progress estimation.
- Single-threaded attempt flow; performance may be limited on long passwords.
- Targets ZIP archives only.
- Error handling is minimal; many internal exceptions are swallowed.

## Security and Safety Notes

- Keep extracted output in a trusted location.
- Wordlists may contain sensitive data; handle and store them securely.
- Prefer shortest practical search space first (smaller charset and lower max length).

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Make changes and test in Visual Studio on Windows.
4. Submit a pull request with a clear description.

## License

No explicit license file is currently present in this repository.  
Assume all rights reserved unless the maintainer adds a license.
