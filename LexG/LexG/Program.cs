using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace LexG
{
    
    class caracter
    {

        public string nm;
        public int hp;
        public int ap;
        public caracter(string name, int helth, int strength)
        {
            nm = name;
            hp = helth;
            ap = strength;

        }
        
    }
    class battle 
    {
        public string nm;
        public int ap;
        public int hp;
        public string onm;
        public int oap;
        public int ohp;
        public int bID;
        public int di;
        public int odi;

        public battle(string nm, int ap, int hp, string onm, int oap, int ohp, int di, int odi,int bID)
        {
            this.nm = nm;
            this.ap = ap;
            this.hp = hp;
            this.onm = onm;
            this.oap = oap;
            this.ohp = ohp;
            this.di = di;
            this.odi = odi;
            this.bID = bID;

        }
    }
    class round
    {
        
        public int strength;
        public int health;
        
        public int ostrength;
        public int ohealth;

        public int dice;
        public int odice;
        Random rand=new Random();

        public round(int hp, int ap, int ohp, int oap)
        {
            

            strength = ap;
            health = hp;
            
            ostrength = oap;
            ohealth = ohp;

        }

        public int fight()
        {
           
            odice = rand.Next(1, 7);
            dice = rand.Next(1, 7);

            ohealth = ohealth - strength * dice;
            health = health - ostrength * odice;

            return health;

        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {

            game();

        }
        static void game()
        {
            var r = new Random();
            string quit = "yes";

            int battleID= 1;
            
            List<battle> bat = new List<battle>();
            
            Console.WriteLine("Write youre name");
            string name = Console.ReadLine();

            caracter carac = new caracter(name, r.Next(1, 5000), r.Next(1, 50));
            
            
            int health = carac.hp;
            

            while (health > 0 && quit!="no")
            {
                
                caracter oponant = new caracter("enemy", r.Next(1,5000), r.Next(1, 50));
                
                Console.WriteLine("youre health: "+health + " oponants health: " + oponant.hp);
                Console.WriteLine("youre strength: "+carac.ap + " oponants strength: " + oponant.ap);

                round roll = new round(health, carac.ap, oponant.hp, oponant.ap);

                while (roll.ohealth > 0 && health >0)
                {
                         
                    health = roll.fight();
                    
                    
                    Console.WriteLine("you rolled: "+roll.dice + " oponant rolled: " + roll.odice);
                    Console.WriteLine(health + " " + roll.ohealth);
                    
                    bat.Add(new battle(name, carac.ap, health, oponant.nm, oponant.ap, roll.ohealth, roll.dice, roll.odice, battleID));

                }
                battleID++;

                Console.WriteLine("whrite 'no' to retire");
                quit=Console.ReadLine();
            }
            
            foreach(var battle in bat)
            {
                Console.WriteLine(battle.bID +" name:"+battle.nm+" round hp:"+battle.hp+" rolle:"+ battle.di+" enemy roll"+ battle.odi+" enemy hp:"+ battle.ohp);
               
            }
            game();
            

        }
        
    }
}