using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MilitaryElite
{
    public class Engine
    {
        private List<ISoldier> allSoldiers;

        public Engine()
        {
            this.allSoldiers = new List<ISoldier>();
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string rank = inputArgs[0];
                string id = inputArgs[1];
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                if (rank == "Private")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    ISoldier newPrivate = new Private(id, firstName, lastName, salary);
                    this.allSoldiers.Add(newPrivate);
                }
                else if (rank == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    LieutenantGeneral newLieutenant = new LieutenantGeneral(id, firstName, lastName, salary);    

                    for (int i = 5; i < inputArgs.Length; i++)
                    {
                        string idToCompare = inputArgs[i];

                        foreach (var soldier in allSoldiers)
                        {
                            if (soldier.Id == idToCompare)
                            {
                                newLieutenant.AddPrivate(soldier);
                            }
                        }
                    }
                    this.allSoldiers.Add(newLieutenant);
                }
                else if (rank == "Engineer")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    try
                    {
                        string corps = inputArgs[5];
                        Engineer newEngineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairs = inputArgs.Skip(6).ToArray();

                        for (int i = 0; i < repairs.Length; i+= 2)
                        {
                            string repairPart = repairs[i];
                            int workedHours = int.Parse(repairs[i + 1]);
                            IRepair repair = new Repair(repairPart, workedHours);
                            newEngineer.AddRepair(repair);
                        }
                        this.allSoldiers.Add(newEngineer);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                else if (rank == "Commando")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    try
                    {
                        string corps = inputArgs[5];
                        Commando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionInfo = inputArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionInfo.Length; i+= 2)
                        {
                            string missionName = missionInfo[i];
                            string state = missionInfo[i + 1];
                            IMission mission;
                            try
                            {
                                mission = new Mission(missionName, state);
                            }
                            catch (Exception)
                            {

                                continue;
                            }
                            commando.AddMission(mission);
                        }
                        this.allSoldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                else if (rank == "Spy")
                {
                    int codeName = int.Parse(inputArgs[4]);
                    ISoldier newSpy = new Spy(id, firstName, lastName, codeName);
                    this.allSoldiers.Add(newSpy);
                }
            }

            foreach (var soldier in allSoldiers)
            {
                Type type = soldier.GetType();
                var currentSoldier = Convert.ChangeType(soldier, type);
                Console.WriteLine(currentSoldier);
            }
        }
    }
}
