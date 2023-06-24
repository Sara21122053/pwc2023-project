using System;
using System.Collections.Generic;
using System.IO;

public class GoTemple : Activity
{
    private const int _pointsPerRegister = 1000;
    private const string _templeFile = "Temple.txt";

    public GoTemple()
    {
        _level = 1;
        _pointsNeccesaryByLevel = 0;
    }

    public override void RegisterActivity()
    {
        _points += _pointsPerRegister;
        SaveRegisterTemple();
        Console.WriteLine("You have earned points fot going to the Temple!");
    }

    private void SaveRegisterTemple()
    {
        Console.WriteLine("Enter a description of how you prepared to go the Temple:");
        string preparation = Console.ReadLine();

        Console.WriteLine("Enter a description of your experience at the Temple:");
        string experience = Console.ReadLine();

        Console.WriteLine("Enter the complete photographic route of your trip to the Temple:");
        string photoRoute = Console.ReadLine();
        
        if (File.Exists(photoRoute))
        {
            Console.WriteLine("Enter the file name of the photo in your application:");
            string nameFilePhoto = Console.ReadLine();

            string folderPhotos = "PhotosTemple";
            Directory.CreateDirectory(folderPhotos);

            string destinationRoute = Path.Combine(folderPhotos, nameFilePhoto);
            File.Copy(photoRoute, destinationRoute, true);

            string register = $"{DateTime.Now}: Temple - Preparation: {preparation} - Experience: {experience} - Photo: {destinationRoute}";
            using (StreamWriter sw = File.AppendText(_templeFile))
            {
                sw.WriteLine(register);
            }
            
            Console.WriteLine("Photograph and register saved correctly.");
        }
        else
        {
            Console.WriteLine("The specific photo path is invalid");
        }
    }
}