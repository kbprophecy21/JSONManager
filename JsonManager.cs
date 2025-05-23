using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace JSONManager
{
    public class JsonManager
    {
        private string currentFilePath = string.Empty;
        private Dictionary<string, object> jsonData;

        public JsonManager()
        {
            jsonData = new Dictionary<string, object>();
        }

        // Load an existing JSON file
        public bool LoadJsonFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found.");
                    return false;
                }

                string jsonContent = File.ReadAllText(filePath) ?? string.Empty;
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    Console.WriteLine("The file is empty. Initializing with an empty JSON object.");
                    jsonData = new Dictionary<string, object>();
                }
                else
                {
                    jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent) ?? new Dictionary<string, object>();
                }

                currentFilePath = filePath;
                Console.WriteLine("JSON file loaded successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                return false;
            }
        }

        // Create a new JSON file
        public bool CreateNewJsonFile(string fileName, string filePath)
        {
            try
            {
                currentFilePath = Path.Combine(filePath, fileName);

                if (File.Exists(currentFilePath))
                {
                    Console.WriteLine("File already exists.");
                    return false;
                }

                jsonData.Clear();
                SaveJsonFile();

                Console.WriteLine("New JSON file created successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating JSON file: {ex.Message}");
                return false;
            }
        }

        // Add new data to the JSON
        public void AddData(string key, string value)
        {
            if (jsonData.ContainsKey(key))
            {
                Console.WriteLine("Key already exists. Use a different key.");
                return;
            }

            jsonData[key] = value;
            Console.WriteLine("Data added successfully.");
        }

        // Edit existing data in the JSON
        public void EditData(string key, string newValue)
        {
            if (!jsonData.ContainsKey(key))
            {
                Console.WriteLine("Key not found.");
                return;
            }

            if (newValue == null)
            {
                Console.WriteLine("Invalid value. Please provide a valid value.");
                return;
            }

            jsonData[key] = newValue;
            Console.WriteLine("Data updated successfully.");
        }

        // Delete data from the JSON
        public void DeleteData(string key)
        {
            if (!jsonData.ContainsKey(key))
            {
                Console.WriteLine("Key not found.");
                return;
            }

            jsonData.Remove(key);
            Console.WriteLine("Data deleted successfully.");
        }

        // Save the JSON file
        public void SaveJsonFile()
        {
            try
            {
                if (string.IsNullOrEmpty(currentFilePath))
                {
                    Console.WriteLine("No file path specified. Cannot save.");
                    return;
                }

                string directory = Path.GetDirectoryName(currentFilePath) ?? string.Empty;
                if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
                {
                    Console.WriteLine("The directory does not exist or is invalid. Cannot save the file.");
                    return;
                }

                string jsonContent = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(currentFilePath, jsonContent);

                Console.WriteLine("JSON file saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON file: {ex.Message}");
            }
        }

        // View the JSON data
        public void ViewJsonData()
        {
            if (jsonData.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            Console.WriteLine("Current JSON Data:");
            foreach (var kvp in jsonData)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        // Search for a key in the JSON data
        public void SearchJsonData(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Invalid key. Please provide a valid key.");
                return;
            }

            if (jsonData.ContainsKey(key))
            {
                Console.WriteLine($"Key: {key}, Value: {jsonData[key]}");
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
        }
    }
}