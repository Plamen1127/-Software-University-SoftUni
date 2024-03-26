


using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input= args.Split(' ');

            string commandName = input[0];
            string[] velue = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t=> t.Name == commandName + "Command");
            if (type == null)
            {
                throw new InvalidOperationException("Mising command");
            }

            Type commandInterface = type.GetInterface("ICommand");

            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not command");
            }

            var command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(velue);

            return result;
        }
    }
}
