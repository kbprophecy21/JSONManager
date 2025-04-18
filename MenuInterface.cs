using System;

public class MenuInterface
{
    private JsonManager jsonManager;
    private string input = "";

    public MenuInterface()
    {
        jsonManager = new JsonManager();
    }

    public void DisplayStartupMenu()
    {
        Console.WriteLine("Booting up....!");
        Console.WriteLine("Starting JSON MANAGER...\n");

        Console.WriteLine("1. Load existing file");
        Console.WriteLine("2. Create New file");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
        HandleStartUpInput(input);
    }

    public void HandleStartUpInput(string input)
    {
        switch (input)
        {
            case "1":
                string filePath = LoadExistingFileInterface();
                if (jsonManager.LoadJsonFile(filePath))
                {
                    Console.WriteLine("File loaded successfully.");
                    DisplayMainMenu();
                }
                break;
            case "2":
                var (fileName, filePath) = CreateNewFileInterface();
                if (jsonManager.CreateNewJsonFile(fileName, filePath))
                {
                    Console.WriteLine("New file created successfully.");
                    DisplayMainMenu();
                }
                break;
            case "3":
                closeProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                DisplayStartupMenu();
                break;
        }
    }

    public string LoadExistingFileInterface()
    {
        Console.WriteLine("Enter the path to the existing JSON file:");
        return Console.ReadLine();
    }

    public (string fileName, string filePath) CreateNewFileInterface()
    {
        Console.WriteLine("Enter the name of the new JSON file:");
        string fileName = Console.ReadLine();

        Console.WriteLine("Enter the path where you want to save the new JSON file:");
        string filePath = Console.ReadLine();

        return (fileName, filePath);
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("1. Edit JSON data");
        Console.WriteLine("2. View JSON data");
        Console.WriteLine("3. Search JSON data");
        Console.WriteLine("4. Save JSON data");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
        HandleMainMenuInput(input);
    }

    public void HandleMainMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                DisplayEditingMenu();
                break;
            case "2":
                jsonManager.ViewJsonData();
                DisplayMainMenu();
                break;
            case "3":
                Console.WriteLine("Enter the key to search:");
                string key = Console.ReadLine();
                jsonManager.SearchJsonData(key);
                DisplayMainMenu();
                break;
            case "4":
                jsonManager.SaveJsonFile();
                DisplayMainMenu();
                break;
            case "5":
                closeProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                DisplayMainMenu();
                break;
        }
    }

    public void DisplayEditingMenu()
    {
        Console.WriteLine("1. Add new data");
        Console.WriteLine("2. Edit existing data");
        Console.WriteLine("3. Delete data");
        Console.WriteLine("4. Back to Main Menu");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
        HandleEditingMenuInput(input);
    }

    public void HandleEditingMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter the key:");
                string addKey = Console.ReadLine();
                Console.WriteLine("Enter the value:");
                string addValue = Console.ReadLine();
                jsonManager.AddData(addKey, addValue);
                DisplayEditingMenu();
                break;
            case "2":
                Console.WriteLine("Enter the key to edit:");
                string editKey = Console.ReadLine();
                Console.WriteLine("Enter the new value:");
                string editValue = Console.ReadLine();
                jsonManager.EditData(editKey, editValue);
                DisplayEditingMenu();
                break;
            case "3":
                Console.WriteLine("Enter the key to delete:");
                string deleteKey = Console.ReadLine();
                jsonManager.DeleteData(deleteKey);
                DisplayEditingMenu();
                break;
            case "4":
                DisplayMainMenu();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                DisplayEditingMenu();
                break;
        }
    }

    public void closeProgram()
    {
        Console.WriteLine("Exiting the program...");
        Environment.Exit(0);
    }
}