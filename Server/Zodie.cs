using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Zodiac
    {
        private string zodie;
        private string inceputData;
        private string sfarsitData;

        public Zodiac(string beginDate = "", string endDate = "", string zodie = "")
        {
            this.inceputData = beginDate;
            this.sfarsitData = endDate;
            this.zodie = zodie;
        }

        public string getZodie()
        {
            return zodie;
        }

        public string getInceputDataZodie()
        {
            return inceputData;
        }

        public string getSfarsitDataZodie()
        {
            return sfarsitData;
        }
    }

    public class ListaZodii
    {
        private List<Zodiac> zodieList = new List<Zodiac>();

        public ListaZodii()
        {
            System.IO.StreamReader fileReader = new System.IO.StreamReader("Zodii.txt");
            for (int luna = 0; luna < 12; luna++)
            {
                String line = fileReader.ReadLine();
                string[] date = line.Split(' ');

                Zodiac s = new Zodiac(date[0], date[1], date[2]);
                zodieList.Add(s);
            }
        }

        public string FindSign(string date)
        {
            string[] dateList = date.Split('/');
            int luna = int.Parse(dateList[0]);
            int day = int.Parse(dateList[1]);
            foreach (Zodiac zodie in zodieList)
            {
                string[] begin = zodie.getInceputDataZodie().Split('/');
                string[] end = zodie.getSfarsitDataZodie().Split('/');
               
                if ((luna == int.Parse(begin[0]) && day >= int.Parse(begin[1])) || (luna == int.Parse(end[0]) && day <= int.Parse(end[1])))
                    return zodie.getZodie();
            }
            return string.Empty;
        }
    }
}
