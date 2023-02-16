using RoboCMDL.Exceptions;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RoboCMDL.Utilities;

public class DriveUtilities
{
    /*
     * This variable will log the path of LogFile for Robocopy Operation
     */


    private bool IsPathQualified(string path)
    {
        return Path.IsPathFullyQualified(path);
    }

    private string CleanPathFromIllegalChar(string path)
    {
        // return Regex.Replace(path, "[^a-zA-Z0-9_.-]+", "\\", RegexOptions.Compiled);
        string invalidCharsRegex = @"[<>:""/\\|?*\x00-\x1f]";
        string cleanedPath = Regex.Replace(path, invalidCharsRegex, "\\");
        string absolutePath = Path.GetFileName(cleanedPath);

        return absolutePath;

    }

    public string ValidateAndCorrectPath(string pathToValidate)
    {
        string validatedPath;


        var isPathValid = IsPathQualified(pathToValidate);
        if (isPathValid)
        {
            Console.WriteLine("test 1");
            validatedPath = pathToValidate;
        }
        else
        {
            var currentWorkingLocation = Directory.GetCurrentDirectory();
            var combinedPath = Path.Combine(currentWorkingLocation, pathToValidate);
            var logFileFullPath = Path.GetFullPath(combinedPath);
            //Console.WriteLine($"The final path is {logFileFullPath}");

            if (IsPathQualified(logFileFullPath))
            {
                Console.WriteLine($"{logFileFullPath} is qualified");
                validatedPath = logFileFullPath;
            }
            else
            {
                validatedPath = "X";
            }
        }


        validatedPath = CleanPathFromIllegalChar(validatedPath);
        Console.WriteLine($"Finally return would be  {validatedPath}");
        return validatedPath;
    }


    private string CreatePath(string pathToCreate)
    {
        var getPathStatus = ValidateAndCorrectPath(pathToCreate);
        if (getPathStatus != null)
        {
        }

        var result = pathToCreate;
        var pathHasExtension = Path.HasExtension(pathToCreate);
        var isQualified = Path.IsPathFullyQualified(pathToCreate);
        return result;
    }

    public string PathValidateAndCreate(string path)
    {
        return "X";
    }
}