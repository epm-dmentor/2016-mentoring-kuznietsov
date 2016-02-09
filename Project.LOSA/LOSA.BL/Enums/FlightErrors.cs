// ReSharper disable once CheckNamespace

namespace LOSA.BL
{
    public enum FlightErrors
    {
        TechnicalError = 1,
        HumanError = 2,
        OnBoardDeviceError = 3,
        FlightProtocolViolation = 4,
        SafetyProtocolViolation = 5
    }

    public enum FlightErrorOutcome
    {
        Incident = 1,
        UAS = 2,
        Error = 3
    }
}
