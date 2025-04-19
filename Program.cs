using System;

using JSONManager; // Assuming this is the namespace where JsonManager is defined

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the JSON Manager!");
        
        // Create an instance of MenuInterface
        MenuInterface menuInterface = new MenuInterface();
        
        // Start the program by displaying the startup menu
        menuInterface.DisplayStartupMenu();
    }
}