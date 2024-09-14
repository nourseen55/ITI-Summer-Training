namespace day8iti
{
    public delegate void deltemp(int t);
    public class Heater
    {
        private int _temp;
        public int tempheater { get { return _temp; } set {_temp=value; } }
        public void headerhandler(int t) {
            if (t<_temp)
            {
                Console.WriteLine("Heater ..... ON");
            }
            else
            {
                Console.WriteLine("Heater ..... OFF");

            }
        }

    }
    public class Cooler
    {
        private int _temp;
        public int tempcooler{ get { return _temp; } set { _temp = value; } }
        public void coolerhandler(int t)
        {
            if (t > _temp)
            {
                Console.WriteLine("Cooler ..... ON");
            }
            else
            {
                Console.WriteLine("Cooler ..... OFF");

            }
        }
    }
    public class termostat
    {
        private int _temp;
        public event deltemp ontempchange;
        public int currentTemp { get { return _temp; } set {
                if (_temp != value)
                {
                    _temp = value;
                    if (ontempchange != null)
                    {
                        ontempchange(_temp);                     
                    }
                }
               
            } }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            termostat termostat = new termostat();
            Cooler cooler = new Cooler();
            Heater heater = new Heater();
            cooler.tempcooler = 80;
            heater.tempheater = 20;
            termostat.ontempchange += cooler.coolerhandler;
            termostat.ontempchange += heater.headerhandler;
            Console.WriteLine("--------------30-----------");
            termostat.currentTemp = 30; 
            Console.WriteLine("--------------90-----------");
            termostat.currentTemp = 90;
        }
    }
}
