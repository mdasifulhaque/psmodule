using RoboCMDL.Utilities;

namespace RobocopyCmdletTest
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //Console.WriteLine("Test");

            DriveUtilities driveUtilities = new DriveUtilities();

            driveUtilities.ValidateAndCorrectPath("..\\test\\test.log");
            driveUtilities.ValidateAndCorrectPath("@!~<>test2\\test2.log");
        }
    }
}
