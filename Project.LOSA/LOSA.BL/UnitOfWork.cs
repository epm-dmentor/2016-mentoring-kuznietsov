using System;
using LOSA.DBL;
using LOSA.Model;
using LOSA.Model.Entities;

namespace LOSA.BL
{
    public class UnitOfWork : IDisposable
    {
        private readonly LOSAContext _context = new LOSAContext();
        private IRepository<FlightObservation> _observationsRepository;
        private IRepository<Flight> _flightsRepository;
        private IRepository<FlightError> _errorsRepository;
        private IRepository<FlightThreat> _threatsRepository;
        private IRepository<Airport> _airportsRepository;
        private IRepository<Observer> _observersRepository;
        private IRepository<Plane> _planesRepository;
        private IRepository<ThreatType> _threatTypesRepository;
        private IRepository<ErrorType> _errorTypesRepository; 
        private IRepository<EvaluationLanding> _landingEvaluationsRepository;
        private IRepository<EvaluationPredeparture> _predepartureEvaluationsRepository;
        private IRepository<EvaluationTakeOff> _takeOffEvaluationsRepository;
        private IRepository<CrewMember> _crewMembersRepository;
        private IRepository<Position> _crewPositionsRepository;



        public IRepository<FlightObservation> ObservationsRepository
        {
            get
            {
                if (_observationsRepository == null)
                {
                    _observationsRepository = new Repository<FlightObservation>(_context);
                }
                return _observationsRepository;
            }
        }

        public IRepository<Flight> FlightsRepository
        {
            get
            {
                if (_observationsRepository == null)
                {
                    _flightsRepository = new Repository<Flight>(_context);
                }
                return _flightsRepository;
            }
        }

        public IRepository<FlightError> ErrorsRepository
        {
            get
            {
                if (_observationsRepository == null)
                {
                    _errorsRepository = new Repository<FlightError>(_context);
                }
                return _errorsRepository;
            }
        }

        public IRepository<FlightThreat> ThreatsRepository
        {
            get
            {
                if (_threatsRepository == null)
                {
                    _threatsRepository = new Repository<FlightThreat>(_context);
                }
                return _threatsRepository;
            }
        }

        public IRepository<Airport> AirportsRepository
        {
            get
            {
                if (_airportsRepository == null)
                {
                    _airportsRepository = new Repository<Airport>(_context);
                }
                return _airportsRepository;
            }
        }

        public IRepository<Observer> ObserversRepository
        {
            get
            {
                if (_observersRepository == null)
                {
                    _observersRepository = new Repository<Observer>(_context);
                }
                return _observersRepository;
            }
        }

        public IRepository<Plane> PlanesRepository
        {
            get
            {
                if (_planesRepository == null)
                {
                    _planesRepository = new Repository<Plane>(_context);
                }
                return _planesRepository;
            }
        }

        public IRepository<ThreatType> ThreatTypesRepository
        {
            get
            {
                if (_threatTypesRepository == null)
                {
                    _threatTypesRepository = new Repository<ThreatType>(_context);
                }
                return _threatTypesRepository;
            }
        }

        public IRepository<ErrorType> ErrorTypesRepository
        {
            get
            {
                if (_errorTypesRepository == null)
                {
                    _errorTypesRepository = new Repository<ErrorType>(_context);
                }
                return _errorTypesRepository;
            }
        }

        public IRepository<EvaluationLanding> EvaluationLandingsRepository
        {
            get
            {
                if (_landingEvaluationsRepository == null)
                {
                    _landingEvaluationsRepository = new Repository<EvaluationLanding>(_context);
                }
                return _landingEvaluationsRepository;
            }
        }

        public IRepository<EvaluationPredeparture> EvaluationPredeparturesRepository
        {
            get
            {
                if (_predepartureEvaluationsRepository == null)
                {
                    _predepartureEvaluationsRepository = new Repository<EvaluationPredeparture>(_context);
                }
                return _predepartureEvaluationsRepository;
            }
        }

        public IRepository<EvaluationTakeOff> EvaluationTakeoffsRepository
        {
            get
            {
                if (_takeOffEvaluationsRepository == null)
                {
                    _takeOffEvaluationsRepository = new Repository<EvaluationTakeOff>(_context);
                }
                return _takeOffEvaluationsRepository;
            }
        }

        public IRepository<CrewMember> CrewMembersRepository
        {
            get
            {
                if (_crewMembersRepository == null)
                {
                    _crewMembersRepository = new Repository<CrewMember>(_context);
                }
                return _crewMembersRepository;
            }
        }

        public IRepository<Position> PositionsRepository
        {
            get
            {
                if (_crewPositionsRepository == null)
                {
                    _crewPositionsRepository = new Repository<Position>(_context);
                }
                return _crewPositionsRepository;
            }
        } 


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
