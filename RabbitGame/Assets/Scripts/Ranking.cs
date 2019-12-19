using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ranking
{
   public int order;
   public string name;
   public int score;
   public DateTime datetime;
    public Ranking() { }
    public Ranking(string o, string n, string s, string d)
    {
        order = int.Parse(o);
        name = n;
        score = int.Parse(s);
        datetime = DateTime.Parse(d);
    }
}