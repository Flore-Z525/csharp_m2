namespace HarryPotterIndex.Commands;

public class CommandInterpreter
{
    private Index _index;
    private readonly Dictionary<string, string> _commands;
    
    public CommandInterpreter(Index index)
    {
        _index = index;
        _commands = new Dictionary<string, string>
        {
            { "add", "ajouter un nouveau personnage à l'index, \nex. add HarryPotter human male (Gryffindor) (1980)" }, 
            { "search", "rechercher un/des personnage(s) dans l'index, \nex. search name HarryPotter; search house Gryffindor" }, 
            { "load", "charger les données des personnages depuis un fichier csv, \nex. load Data/hp.csv" }, 
            { "save", "sauvegarder les données des personnages dans un fichier csv/txt, \nex. save Data/hp_test.csv" }, 
            { "read_json", "charger les données des personnages depuis un fichier json, \nex. read_json Data/hp.json" }, 
            { "write_json", "sauvegarder les données des personnages dans un fichier json, \nex. write_json Data/hp_test.json" }, 
            { "exit", "quitter l'application" }, 
            { "help", "lister les commandes disponibles" }
        };
    }

    public Command Interpret(string[] arguments)
    {
        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                // Command addCommand = new AddCommand(_index, commandArguments);
                // return addCommand;
                return new AddCommand(_index, commandArguments);

            case "search": 
                return new SearchCommand(_index, commandArguments);
            
            case "load": 
                return new LoadCommand(_index, commandArguments);
            
            case "save":
                return new SaveCommand(_index, commandArguments);

            case "read_json":
                return new ReadJsonCommand(_index, commandArguments);

            case "write_json":
                return new WriteJsonCommand(_index, commandArguments);
            
            case "help":
                return new HelpCommand(_index, commandArguments, _commands);
            
            case "exit":
                return new ExitCommand(_index, commandArguments);
            
            //TODO
            
            default:
                throw new CommandNotFoundException($"Command {commandName} is not supported");
        }
    }
}