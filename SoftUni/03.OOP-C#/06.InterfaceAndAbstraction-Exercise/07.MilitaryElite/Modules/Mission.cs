using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State 
        { 
            get
            {
                return state;
            }
            private set
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new Exception();
                }
                this.state = value;
            } 
        }

        public void CompleteMission()
        {
            if (this.State == "inProgress")
            {
                this.State = "Finished";
            }
            else
            {
                throw new ArgumentException("Mission already finished!");
            }
        }
        //private void ParseState(string stateString)
        //{
        //    State state;
        //    bool parsed = Enum.TryParse(stateString, out state);
        //    if (parsed)
        //    {
        //        this.State = state;
        //    }
        //}
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
