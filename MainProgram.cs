using System;

public class MainProgram
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