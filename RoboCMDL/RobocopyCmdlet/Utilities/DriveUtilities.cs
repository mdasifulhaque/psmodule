using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCMDL.Utilities
{
    public class DriveUtilities
    {

        private string _logFilePath;
        public string ValidateAndCorrectPath(string path)
        {
            _logFilePath = path;
            var isValid = Path.IsPathFullyQualified(_logFilePath);
            if (isValid)
            {
                return _logFilePath;
            }
            else
            {
                var currentLocation = Directory.GetCurrentDirectory();
                var finalPath = Path.Combine(currentLocation, _logFilePath);
                if (Path.IsPathFullyQualified(finalPath))
                {

                    _logFilePath = Path.GetFullPath(finalPath);
                }
                else
                {
                    return null;
                }
            }

            return _logFilePath;
        }


        private string CreatePath(string path)
        {
            var getPathStatus = ValidateAndCorrectPath(path);
            if (getPathStatus != null)
            {

            }
            var result = path;
            var pathHasExtension = Path.HasExtension(path);
            var isQualified = Path.IsPathFullyQualified(path);
            return result;
        }
    }
}
