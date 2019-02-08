using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] field = GenerateField();
            int counter = 0;


            int playerNumber = 1;
            Character player1 = GetUserCharacter(23, playerNumber);
            playerNumber += 1;

            Character player2 = GetUserCharacter(28, playerNumber);

            if (player1.Priority < player2.Priority)
            {
                counter = 2;
            }
            else if (player1.Priority > player2.Priority)
            {
                counter = 3;
            }
            else
            {
                counter = 2;
            }

            Character[] characters = { player1, player2 };
            String[] playerNames = { "Player 1", "Player 2" };


            while(player1.Health >= 0 && player2.Health >= 0)
            {
                int index1 = counter % 2;
                int index2 = (counter + 1) % 2;
                CreateBattleField(player1.Position, player2.Position, field);
                PrintCharStatuses(characters[index1], characters[index2]);
                TakeTurn(playerNames[index1], characters[index1], characters[index2]);
                counter += 1;
                
                
                
            }
            if (player1.Health <= 0)
            {
                NotifyWinner("Player 1");
            }
            else if(player2.Health <= 0)
            {
                NotifyWinner("Player 2");
            }

        }//Main
        static Character GetUserCharacter(int charLocation, int playerNumber)
        {
            Console.WriteLine("Player " + playerNumber + " what class do you choose? m,w,a?");
            String userChoice = Console.ReadLine().ToLower();

            if (userChoice == "m")
            {
                Character userChar = new Mage(charLocation);
                Console.WriteLine("\nYou have chosen 'Mage'");
                return userChar;
            }
            else if (userChoice == "w")
            {
                Character userChar = new Warrior(charLocation);
                Console.WriteLine("\nYou have chosen 'Warrior'");
                return userChar;
            }
            else if (userChoice == "a")
            {
                Character userChar = new Mage(charLocation);
                Console.WriteLine("\nYou have chosen 'Archer'");
                return userChar;
            }
            return null;
        }//getUserCharacter method

        static void CheckIfNull(Character character)
        {
            if (character == null)
            {
                Console.WriteLine("Error, invalid choice!");
                Console.WriteLine("Please choose a valid choice next time!");
                Environment.Exit(0);
            }
        }//checkIfNull method

        static void CreateBattleField(int player1Pot, int player2Pot,
            String[] battlefield)
        {
            battlefield[player1Pot] = "1";
            battlefield[player2Pot] = "2";
            Console.WriteLine("");
            Console.WriteLine(string.Join("", battlefield));
            battlefield[player1Pot] = "-";
            battlefield[player2Pot] = "-";
        }

        static String[] GenerateField()
        {
            string[] field = new string[50];
            for(int i = 0; i< 50; i++)
            {
                field[i] = "-";
            }
            return field;
        }
        static void PrintAttackAndSpecial(Character player)
        {
          Console.WriteLine(player.GetMovementAttackDescription());
          Console.WriteLine(player.GetSpecialDescription());
        }
        static void TakeTurn(String playerName, Character player, Character opponent)
        {
            Boolean inputValid = true;
            while(inputValid)
            {
                Console.WriteLine(playerName + " what do you choose to do?");
                PrintAttackAndSpecial(player);
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {

                    MoveUnit(player);
                    Console.WriteLine("Would you like to attack? y/n");
                    String userChoice = Console.ReadLine().ToLower();
                    if (userChoice == "y")
                    {
                        Console.WriteLine("You have opted to attack");
                        Console.WriteLine(player.Attack(opponent));
                    }
                    else if (userChoice == "n")
                    {
                        Console.WriteLine("You have opted to not attack");
                    }
                    inputValid = false;
                }//if statement

                else if (userInput == 2)
                    {
                    Console.WriteLine("You have opted for your special attack.");
                    Console.WriteLine(player.Special(opponent));
                    inputValid = false;
                    }
                else
                {
                    Console.WriteLine("Input not an integer, please input 1 or 2");
                }

            }//while loop
            
        }//TakeTurn method

        static void NotifyWinner(String winner)
        {
            Console.WriteLine("Congratulations " + ", you've won!");
            Console.ReadKey();
        }

        static void MoveUnit (Character player)
        {
            bool movedSuccessfully = true;
            while (movedSuccessfully)
                {
                Console.WriteLine("How many units do you want to move?");
                int moveUnits = int.Parse(Console.ReadLine());
                if (Math.Abs(moveUnits) <= player.MoveSpeed)
                {
                    player.Position += moveUnits;
                    Console.WriteLine("You moved " + moveUnits + " units");
                    movedSuccessfully = false;
                }
                else
                {
                    Console.WriteLine("You can't move that far!");

                }
            }//while loop


        }//MoveUnit method

        static void PrintCharStatuses(Character player1, Character player2)
        {
            Console.WriteLine("Player 1 HP: " + player1.Health +
                " - Player 2 HP: " + player2.Health);
        }
    }//Program class

    public abstract class Character
        {
            public int MoveSpeed { get; set; }
            public int DamagePerAttack { get; set; }
            public int Health { get; set; }
            public int Position { get; set; }
            public int Priority { get; set; }
            public int AttackRange { get; set; }

            public Character()
            {

            }

            public void TakeDamage(int amount)
            {
                Health -= amount;
            }

            public string GetMovementAttackDescription()
            {
                return "1. Move and attack (Max movement = " + MoveSpeed +
                    ". Attack range = " + AttackRange + ". Damage = " +
                    DamagePerAttack;
            }

            public abstract string GetSpecialDescription();

            public string Attack(Character target)
            {
                if (AttackRange <= Math.Abs(Position - target.Position))
                {
                target.TakeDamage(DamagePerAttack);
                    return "Your hit has landed!";
                }
                else
                {
                    return "You are too far away to attack!";
                }
            }

            public abstract string Special(Character target);

        }//Character abstract class

        public class Mage : Character
        { 
            public Mage (int position)
            {
                this.MoveSpeed = 1;
                this.DamagePerAttack = 20;
                this.Health = 50;
                this.Position = position;
                this.Priority = 2;
                this.AttackRange = 6;
            }
            public override string GetSpecialDescription()
            {
                return "2. Special (3 range attack that knocks the opponent away" +
                    " 4 units and deals 10 damage)";
            }//GetSpecialDescription method

            public override string Special(Character target)
            {
                if (3 <Math.Abs(Position - target.Position))
                {
                    
                    return "Opponent out of range, unable to use special.";
                }
                else
                {
                    if (Position < target.Position)
                    {
                        target.Position += 4;
                    }
                    else
                    {
                        target.Position -= 4;
                    }
                    target.TakeDamage(10);
                    return "Successful knockback on opponent!";
                }
            }//Special method
        }//Mage class

        public class Warrior : Character
        {
            public Warrior(int position)
            {
                this.MoveSpeed = 2;
                this.DamagePerAttack = 20;
                this.Health = 75;
                this.Position = position;
                this.Priority = 3;
                this.AttackRange = 1;
            }
            public override string GetSpecialDescription()
            {
                return "2. Special (Leaps up to 8 units towards the target. If target is" +
                    "greater than 5 units away, but less than 9, deals 30 damage)";
            }//GetSpecialDescription method

            void MoveNextToOpponent(Character target)
            {
                if (Position < target.Position)
                {
                    Position = target.Position - 1;
                }
                else
                {
                    Position = target.Position + 1;
                }
            }//moveNextToOpponent method

            public override string Special(Character target)
            {
                int distance = Math.Abs(Position - target.Position);
                if (5 < distance && distance < 9)
                {
                    MoveNextToOpponent(target);
                    target.TakeDamage(30);
                    return "Oponent is greater than 5 units away, delt bonus damage!";
                }
                else if (distance <= 5)
                {
                    MoveNextToOpponent(target);
                    return "Opponent is within 8 units, moving to melee range";

                }
                else
                {
                    if (Position < target.Position)
                    {
                        Position += 8;
                    }
                    else
                    {
                        Position -= 8;
                    }
                    return "Opponent is more than 8 units away, moving closer by 8 untis.";
                }
            }//Special method
        }//Warrior class

        public class Archer : Character
        {
            public Archer(int position)
            {
                this.MoveSpeed = 3;
                this.DamagePerAttack = 15;
                this.Health = 65;
                this.Position = position;
                this.Priority = 1;
                this.AttackRange = 3;
            }
            public override string GetSpecialDescription()
            {
                return "2. Special (12 range attack that deals 10 damage)";
            }//GetSpecialDescription method

            public override string Special(Character target)
            {
                if (12 < Math.Abs(Position - target.Position))
                {

                    return "Opponent out of range, unable to use special.";
                }
                else
                { 
                    target.TakeDamage(10);
                    return "Opponent in range, dealt special damage!";
                }
            }//Special method
        }//Mage class




}
