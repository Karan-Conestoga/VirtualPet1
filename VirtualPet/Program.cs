using System;

namespace VirtualPet
{
    class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Health { get; set; }

        public Pet(string name, string type)
        {
            Name = name;
            Type = type;
            Hunger = 5;
            Happiness = 5;
            Health = 5;
        }

        public void Feed()
        {
            Hunger = Math.Max(0, Hunger - 2);
            Health = Math.Min(10, Health + 1);
            Console.WriteLine($"{Name} has been fed. Hunger decreased, health increased.");
        }

        public void Play()
        {
            Happiness = Math.Min(10, Happiness + 2);
            Hunger = Math.Min(10, Hunger + 1);
            Console.WriteLine($"{Name} is playing. Happiness increased, hunger increased slightly.");
        }

        public void Rest()
        {
            Health = Math.Min(10, Health + 2);
            Happiness = Math.Max(0, Happiness - 1);
            Console.WriteLine($"{Name} is resting. Health increased, happiness decreased slightly.");
        }

        public void CheckStatus()
        {
            Console.WriteLine($"{Name}'s Stats:");
            Console.WriteLine($"Hunger of the pet is: {Hunger}/10");
            Console.WriteLine($"Happiness of the pet is: {Happiness}/10");
            Console.WriteLine($"Health of the pet is: {Health}/10");

            if (Hunger <= 2)
                Console.WriteLine("Warning: Hunger of the pet is critically low.");
            if (Happiness <= 2)
                Console.WriteLine("Warning: Happiness of the pet is critically low.");
            if (Health <= 2)
                Console.WriteLine("Warning: Health of the pet is critically low.");
        }

        public void PassTime()
        {
            Hunger++;
            Happiness--;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Pet!");
            Console.WriteLine("Please select a pet type (cat, dog, rabbit)");
            string type = Console.ReadLine();
            Console.WriteLine("Enter your pet's name:");
            string name = Console.ReadLine();

            Pet myPet = new Pet(name, type);
            Console.WriteLine($"Welcome, {myPet.Type} {myPet.Name}!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose the option which you want to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check Status");
                Console.WriteLine("5. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        myPet.Feed();
                        break;
                    case 2:
                        myPet.Play();
                        break;
                    case 3:
                        myPet.Rest();
                        break;
                    case 4:
                        myPet.CheckStatus();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input !");
                        break;
                }

                myPet.PassTime();
            }
        }
    }
}
