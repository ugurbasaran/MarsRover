using System.Text.RegularExpressions;

namespace Mars.Rover.Command
{
    public interface ICommand
    {
        void Execute(string commandInput);

        Regex CommandRegex { get; }

        bool CheckInputRegexMatch(string commandInput);
    }
}
