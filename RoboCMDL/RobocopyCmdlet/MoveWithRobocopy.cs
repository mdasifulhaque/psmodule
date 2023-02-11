using System.IO;
using System.Management.Automation;
using System.Security.AccessControl;
using RoboCMDL.Utilities;

namespace RoboCMDL;

[Cmdlet(VerbsCommon.Move, "FilesWithRobocopy")]
public class MoveWithRobocopy : Cmdlet
{
    [Parameter(Mandatory = true, Position = 0, HelpMessage = "Source Directory")]
    [Alias("Path", "Root")]
    public string Source { get; set; }

    [Parameter(Mandatory = true, Position = 1, HelpMessage = "Destination Directory")]
    [Alias("TargetDirectory", "FinalPath")]
    public string Destination { get; set; }

    [Parameter(Mandatory = false, Position = 2,
        HelpMessage = "Provide the file name to copy. The default value is *.*")]
    public string Filename { get; set; } = "*.*";

    [Parameter(Mandatory = false, Position = 3, HelpMessage = "Log File Location")]
    public string LogFile { get; set; } = "move_with_robocopy.log";

    [Parameter(Mandatory = false, Position = 4, HelpMessage = "Do you want to append the log data?")]
    public SwitchParameter Append { get; set; }

    private string _logFile;


    private string _argumentList = $"/A:-SH /E";

    protected override void BeginProcessing()
    {
        base.BeginProcessing();
        WriteObject("Starting files Operation");
    }

    protected override void ProcessRecord()
    {

        base.ProcessRecord();
        ArrangeInput();
    }

    private string PathValidateAndCreate(string path)
    {
        var result = path;
        var pathHasExtension = Path.HasExtension(path);
        var isQualified = Path.IsPathFullyQualified(path);
        return result;
    }

    private string ProcessLogFile(string path)
    {
        var result = path;
        WriteObject($"user inputed file is {path}");
        var isPathDefault = string.Equals(path, "move_with_robocopy.log");
        if (isPathDefault)
        {
            WriteObject($"Going with Default Log File {path}");
            var currentPath = Directory.GetCurrentDirectory();
            result = PathValidateAndCreate(Path.Combine(currentPath, result));
            WriteObject($"logfile path would be D:= {result}");

        }
        else
        {
            WriteObject($"Processing user provided logFile {path}");
            result = PathValidateAndCreate(path);

        }
        return result;
    }


    private void ArrangeInput()
    {
        _logFile = ProcessLogFile(LogFile);
        if (Append.IsPresent)
        {
            _argumentList += $" /log:+{_logFile}";
        }
        else
        {
            _argumentList += $" /log:{_logFile}";
        }
    }

}

