using System.Management.Automation;

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
    [Parameter(Mandatory = true, Position = 2, HelpMessage = "Log File Location")]
    public string LogFile { get; set; }


    private string _logFilePath = "move_with_robocopy.log";




}