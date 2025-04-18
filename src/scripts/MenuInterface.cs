using System;



public class MenuInterface
{
    string input = "";

    public void DisplayStartupMenu()
    {
        Console.WriteLine("Booting up....!");
        Console.WriteLine("Starting JSON MANAGER...\n");
        
        Console.WriteLine("1. Load existing file");
        Console.WriteLine("2. Create New file");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
    }


   

    public void HandleStartUpInput(string input)
    {
        switch (input)
        {
            case "1":
                LoadExistingFileInterface();
                break;
            case "2":
                CreateNewFileInterface();
                break;
            case "3":
                closeProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                break;
        }
    }


    public void LoadExistingFileInterface()
    {
        Console.WriteLine("Enter the path to the existing JSON file:");
        string filePath = Console.ReadLine();

        return filePath;
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
        Console.WriteLine("4. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
    }
    public void HandleMainMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                DisplayEditingMenu();
                break;
            case "2":
                Console.WriteLine("Viewing JSON data...");
                break;
            case "3":
                Console.WriteLine("Searching JSON data...");
                break;
            case "4":
                closeProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                break;
        }
    }
    public void HandleEditingMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                Console.WriteLine("Adding new data...");
                break;
            case "2":
                Console.WriteLine("Editing existing data...");
                break;
            case "3":
                Console.WriteLine("Deleting data...");
                break;
            case "4":
                Console.WriteLine("Saving changes...");
                break;
            case "5":
                closeProgram();
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                break;
        }
    }
    public void closeProgram()
    {
        Console.WriteLine("Exiting the program...");
        Environment.Exit(0);
    }
    public void DisplayEditingMenu()
    {
        Console.WriteLine("1. Add new data");
        Console.WriteLine("2. Edit existing data");
        Console.WriteLine("3. Delete data");
        Console.WriteLine("4. Save changes");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Select an option: ");
        input = Console.ReadLine();
    }

}