using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightInfoStatusStruct
    {
        [DataMember(Name="actual_arrival_time")]
        public Timestamp ActualArrivalTime { get; set; }

        [DataMember(Name="actual_blockin_time")]
        public Timestamp ActualBlockinTime { get; set; }

        [DataMember(Name="actual_blockout_time")]
        public Timestamp ActualBlockoutTime { get; set; }

        [DataMember(Name="actual_departure_time")]
        public Timestamp ActualDepartureTime { get; set; }

        [DataMember(Name="adhoc")]
        public Boolean? Adhoc { get; set; }
        
        [DataMember(Name="aircrafttype")]
        public string AircraftType { get; set; }

        [DataMember(Name="airline")]
        public string Airline { get; set; }

        [DataMember(Name="airline_iata")]
        public string AirlineIATA { get; set; }

        [DataMember(Name="arrival_delay")]
        public int ArrivalDelay { get; set; }

        [DataMember(Name="atc_ident")]
        public string AtcIdent { get; set; }

        [DataMember(Name="bag_claim")]
        public string BaggageClaim { get; set; }

        [DataMember(Name="blocked")]
        public bool Blocked { get; set; }

        [DataMember(Name="cancelled")]
        public bool Cancelled { get; set; }

        [DataMember(Name="codeshares")]
        public IEnumerable<string> CodeShares { get; set; }

        [DataMember(Name="datalink")]
        public Boolean? DataLink { get; set; }

        [DataMember(Name="departure_delay")]
        public int? DepartureDelay { get; set; }

        [DataMember(Name="destination")]
        public AirportDisplayStruct Destination { get; set; }

        [DataMember(Name="display_aircrafttype")]
        public string DisplayAircraftType { get; set;}

        [DataMember(Name="display_filed_altitude")]
        public string DisplayFiledAltitude { get; set; }

        [DataMember(Name="distance_filed")]
        public int? FiledDistance { get; set; }

        [DataMember(Name="diverted")]
        public bool Diverted { get; set; }

        [DataMember(Name="estimated_arrival_time")]
        public Timestamp EstimatedArrivalTime { get; set; }
        [DataMember(Name="estimated_blockin_time")]

        public Timestamp EstimatedBlockinTime { get; set; }

        [DataMember(Name="estimated_blockout_time")]
        public Timestamp EstimatedBlockoutTime { get; set; }

        [DataMember(Name="estimated_departure_time")]
        public Timestamp EstimatedDepartureTime { get; set; }

        [DataMember(Name="faFlightID")]
        public string FlightAwareFlightId { get; set; }

        [DataMember(Name="filed_airspeed_kts")]
        public int? FiledAirspeedKnots { get; set; }

        [DataMember(Name="filed_airspeed_mach")]
        public int? FiledAirspeedMach { get; set; }

        [DataMember(Name="filed_altitude")]
        public int? FiledAltitude { get; set; }

        [DataMember(Name="filed_arrival_time")]
        public Timestamp FiledArrivalTime { get; set; }

        [DataMember(Name="filed_blockin_time")]
        public Timestamp FiledBlockinTime { get; set; }

        [DataMember(Name="filed_blockout_time")]
        public Timestamp FiledBlockoutTime { get; set; }

        [DataMember(Name="filed_departure_time")]
        public Timestamp FiledDepartureTime { get; set; }
        
        [DataMember(Name="filed_ete")]
        public int? FiledDuration { get; set; }
        
        [DataMember(Name="flightnumber")]
        public string FlightNumber { get; set; }

        [DataMember(Name="full_aircrafttype")]
        public string FullAircraftType { get; set; }

        [DataMember(Name="gate_dest")]
        public string ArrivalGate { get; set; }

        [DataMember(Name="gate_orig")]
        public string DepartureGate { get; set; }

        [DataMember(Name="ident")]
        public string Ident { get; set; }

        [DataMember(Name="inbound_faFlightID")]
        public string InboundFlightAwareFlightId { get; set; }

        [DataMember(Name="origin")]
        public AirportDisplayStruct Origin { get; set; }
        
        [DataMember(Name="seats_cabin_business")]
        public int? SeatsCabinBusiness { get; set; }

        [DataMember(Name="seats_cabin_coach")]
        public int? SeatsCabinCoach { get; set; }

        [DataMember(Name="seats_cabin_first")]
        public int? SeatsCabinFirst { get; set; }

        [DataMember(Name="status")]
        public string Status { get; set; }

        [DataMember(Name="tailnumber")]
        public string TailNumber { get; set; }

        [DataMember(Name="terminal_dest")]
        public string ArrivalTerminal { get; set; }

        [DataMember(Name="terminal_orig")]
        public string DepartureTerminal { get; set; }

        [DataMember(Name="type")]
        public string Type { get; set; }
    }
}