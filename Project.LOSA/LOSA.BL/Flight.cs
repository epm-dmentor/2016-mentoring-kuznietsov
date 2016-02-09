using System;
using System.Collections.Generic;
using System.Linq;

namespace LOSA.BL
{
    class Flight
    {
        //Properties
        public int Id { get; set; }
        public PlaneType PlaneType { get; set; }
        public Airports Departure { get; set; }
        public Airports Arriwal { get; set; }
        public DateTime TakeOffTimeStamp { get; set; }
        public DateTime LandingTimeStamp { get; set; }
        public FlightObservation CurrFlightObserver { get; set; }   
        public List<FlightStages> FlighStageList { get; set; }  
        private FlightStages _currentFLightStage;
        public FlightStages CurrentFLightStage
        {
            get { return _currentFLightStage; }
            set
            {
                _currentFLightStage = value;
                if (CurrentFLightStage == FlightStages.TakeOff)
                {
                    TakeOffTimeStamp = DateTime.Now;
                }
                if (CurrentFLightStage == FlightStages.Landing)
                {
                    LandingTimeStamp = DateTime.Now;
                }
            }
        }

        //Constructor
        public Flight()
        {
            FlighStageList = new List<FlightStages>();
            FlighStageList = Enum.GetValues(typeof (FlightStages)).Cast<FlightStages>().ToList();
            CurrentFLightStage = FlighStageList.First();
        }

        //Methods
        public void StartObservation(Observers watcher)
        {
            var observer = new FlightObservation();
            observer.CurrentFlightObserver = watcher;
            observer.ObservedFlight = this;
            CurrFlightObserver = observer;
        }

        public void NextFlightStage()
        {
            if (CurrentFLightStage != FlightStages.PostFlight)
            {
                var stageCode = FlighStageList.IndexOf(CurrentFLightStage);
                CurrentFLightStage = FlighStageList[stageCode + 1];
            }
        }
    }
}
