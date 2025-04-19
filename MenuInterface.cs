using System;

using JSONManager;

public class MenuInterface
{
    private JsonManager jsonManager;
    private string input = string.Empty;
   

    // Constructor to initialize the JsonManager    
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
        input = Console.ReadLine()?.Trim() ?? string.Empty;
        HandleStartUpInput(input);
    }

    public void HandleStartUpInput(string input)
    {
        switch (input)
        {
            case "1":
                string existingFilePath = LoadExistingFileInterface();
                if (!string.IsNullOrEmpty(existingFilePath) && jsonManager.LoadJsonFile(existingFilePath))
                {
                    Console.WriteLine("File loaded successfully.");
                    DisplayMainMenu();
                }
                else
                {
                    Console.WriteLine("Failed to load the file. Returning to the startup menu.");
                    DisplayStartupMenu();
                }
                break;
            case "2":
                var (fileName, newFilePath) = CreateNewFileInterface();
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(newFilePath) &&
                    jsonManager.CreateNewJsonFile(fileName, newFilePath))
                {
                    Console.WriteLine("New file created successfully.");
                    DisplayMainMenu();
                }
                else
                {
                    Console.WriteLine("Failed to create the file. Returning to the startup menu.");
                    DisplayStartupMenu();
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

    public string? LoadExistingFileInterface()
    {
        Console.WriteLine("Enter the path to the existing JSON file:");
        string filePath = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("Invalid file path. Please try again.");
            return null;
        }

        return filePath;
    }

    public (string fileName, string filePath) CreateNewFileInterface()
    {
        Console.WriteLine("Enter the name of the new JSON file:");
        string fileName = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("Invalid file name. Please try again.");
            return (string.Empty, string.Empty);
        }

        Console.WriteLine("Enter the path where you want to save the new JSON file:");
        string filePath = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("Invalid file path. Please try again.");
            return (string.Empty, string.Empty);
        }

        return (fileName, filePath);
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Edit JSON data");
        Console.WriteLine("2. View JSON data");
        Console.WriteLine("3. Search JSON data");
        Console.WriteLine("4. Save JSON data");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine()?.Trim() ?? string.Empty;
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
                string key = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrEmpty(key))
                {
                    jsonManager.SearchJsonData(key);
                }
                else
                {
                    Console.WriteLine("Invalid key. Please try again.");
                }
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
        Console.WriteLine("\nEditing Menu:");
        Console.WriteLine("1. Add new data");
        Console.WriteLine("2. Edit existing data");
        Console.WriteLine("3. Delete data");
        Console.WriteLine("4. Back to Main Menu");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine()?.Trim() ?? string.Empty;
        HandleEditingMenuInput(input);
    }

    public void HandleEditingMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter the key:");
                string addKey = Console.ReadLine()?.Trim() ?? string.Empty;
                Console.WriteLine("Enter the value:");
                string addValue = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!string.IsNullOrEmpty(addKey) && !string.IsNullOrEmpty(addValue))
                {
                    jsonManager.AddData(addKey, addValue);
                }
                else
                {
                    Console.WriteLine("Invalid key or value. Please try again.");
                }
                DisplayEditingMenu();
                break;
            case "2":
                Console.WriteLine("Enter the key to edit:");
                string editKey = Console.ReadLine()?.Trim() ?? string.Empty;
                Console.WriteLine("Enter the new value:");
                string editValue = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!string.IsNullOrEmpty(editKey) && !string.IsNullOrEmpty(editValue))
                {
                    jsonManager.EditData(editKey, editValue);
                }
                else
                {
                    Console.WriteLine("Invalid key or value. Please try again.");
                }
                DisplayEditingMenu();
                break;
            case "3":
                Console.WriteLine("Enter the key to delete:");
                string deleteKey = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!string.IsNullOrEmpty(deleteKey))
                {
                    jsonManager.DeleteData(deleteKey);
                }
                else
                {
                    Console.WriteLine("Invalid key. Please try again.");
                }
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