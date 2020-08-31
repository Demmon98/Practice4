using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Kernel : MarshalByRefObject
    {
        Model model = new Model();

        public string AddNewLine()
        {
            model.UndergroundLines.Add(new UndergroundLine("newItem", new List<Station>() { new Station() }, 1));
            model.SaveChanges();

            //return "New line added!";

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            return "New line added!";
        }

        public string RemoveLastLine()
        {
            if (model.UndergroundLines.Count() > 0)
            {
                var index = model.UndergroundLines.Count() - 1;
                var remItem = model.UndergroundLines.ToList()[index];

                foreach (var item in model.Stations)
                {
                    model.Stations.Remove(item);
                }

                model.UndergroundLines.Remove(remItem);

                model.SaveChanges();

                return $"Last line deleted!";
            }
            else
                return $"Lines empty!";
        }

        public string AddNewStation()
        {
            model.Stations.Add(new Station("newItem", 1, 1));
            model.SaveChanges();

            return $"New station added!";
        }

        public string RemoveLastStation()
        {
            if (model.Stations.Count() > 0)
            {
                var index = model.Stations.Count() - 1;
                var remItem = model.Stations.ToList()[index];

                model.Stations.Remove(remItem);

                model.SaveChanges();

                return $"Last station deleted!";
            }
            else
                return $"Stations empty!";
        }

        public string ChangeLastStation()
        {
            if (model.Stations.Count() > 0)
            {
                var index = model.Stations.Count() - 1;
                var lastStation = model.Stations.ToList()[index];

                lastStation.Name = "changedName";
                lastStation.SomeProp1 = 2;
                lastStation.SomeProp2 = 2;

                model.SaveChanges();

                return $"Last station changed!";
            }
            else
                return $"Stations empty!";
        }

        public string SearchStationOnName(string name)
        {
            if (model.Stations.Count() > 0)
            {
                var station = model.Stations.First(x => x.Name == name);

                return station.ToString();
            }
            else
                return $"Stations empty!";
        }

        public string GetCountOfStationOnLastLine()
        {
            if (model.UndergroundLines.Count() > 0)
            {
                model.Stations.Load();

                var index = model.UndergroundLines.Count() - 1;
                var line = model.UndergroundLines.ToList()[index];

                return line.Stations.Count.ToString();
            }
            else
                return $"Lines empty!";
        }

        public string GetListOfStationOnLastLine()
        {
            if (model.UndergroundLines.Count() > 0)
            {
                var index = model.UndergroundLines.Count() - 1;
                var line = model.UndergroundLines.ToList()[index];

                string stations = null;

                foreach (var item in line.Stations)
                {
                    stations += item.ToString();
                }

                return stations;
            }
            else
                return $"Lines empty!";
        }

        public string GetFullListOfLine()
        {
            if (model.UndergroundLines.Count() > 0)
            {
                string lines = null;

                foreach (var item in model.UndergroundLines)
                {
                    lines += item.ToString();
                }

                return lines;
            }
            else
                return $"Lines empty!";
        }
    }
}
