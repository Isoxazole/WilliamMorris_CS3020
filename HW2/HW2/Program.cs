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
            String[] field = generateField();
            int[] charSpot = { 23, 28 };
            int userInput = 0;

            Console.WriteLine("Player 1 what class do you choose? m,w,a?");
            Char userChoice1 = Console.ReadKey().KeyChar;
            Character player1 = getUserCharacter(userChoice1, charSpot[0]);
            checkIfNull(player1);

            Console.WriteLine("Player 2 what class do you choose? m,w,a?");
            Char userChoice2 = Console.ReadKey().KeyChar;
            Character player2 = getUserCharacter(userChoice2, charSpot[1]);
            checkIfNull(player2);



            while(player1.Health >= 0 && player2.Health >= 0)
            {
                createBattleField(player1.Position, player2.Position, field);
                Console.WriteLine("Player 1, what do you choose to do?");
                printAttackAndSpecial(player1);
                userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    Console.WriteLine("How many units do you want to move?");
                    int moveUnits = int.Parse(Console.ReadLine());

                    
                }
                
                
                
            }

        }//Main
        static Character getUserCharacter(Char userChoice, int charLocation)
        {
            if (userChoice == 'm')
            {
                Character userChar = new Mage(charLocation);
                Console.WriteLine("\nYou have chosen 'Mage'");
                return userChar;
            }
            else if (userChoice == 'w')
            {
                Character userChar = new Warrior(charLocation);
                Console.WriteLine("\nYou have chosen 'Warrior'");
                return userChar;
            }
            else if (userChoice == 'a')
            {
                Character userChar = new Mage(charLocation);
                Console.WriteLine("\nYou have chosen 'Archer'");
                return userChar;
            }
            return null;
        }//getUserCharacter method

        static void checkIfNull(Character character)
        {
            if (character == null)
            {
                Console.WriteLine("Error, invalid choice!");
                Console.WriteLine("Please choose a valid choice next time!");
                Environment.Exit(0);
            }
        }//checkIfNull method

        static void createBattleField(int player1Pot, int player2Pot,
            String[] battlefield)
        {
            battlefield[player1Pot] = "1";
            battlefield[player2Pot] = "2";
            Console.WriteLine(string.Join("", battlefield));
        }

        static String[] generateField()
        {
            string[] field = new string[50];
            for(int i = 0; i< 50; i++)
            {
                field[i] = "-";
            }
            return field;
        }
        static void printAttackAndSpecial(Character player)
        {
          Console.WriteLine(player.GetMovementAttackDescription());
          Console.WriteLine(player.GetSpecialDescription());
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

            string Attack(Character target)
            {
                if (AttackRange <= Math.Abs(Position - target.Position))
                {
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

            void moveNextToOpponent(Character target)
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
                    moveNextToOpponent(target);
                    target.TakeDamage(30);
                    return "Oponent is greater than 5 units away, delt bonus damage!";
                }
                else if (distance < 5)
                {
                    moveNextToOpponent(target);
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
