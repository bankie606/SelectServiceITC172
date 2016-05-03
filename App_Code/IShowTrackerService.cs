using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShowTrackerService" in both code and config file together.
[ServiceContract]
public interface IShowTrackerService
{
    [OperationContract]
    List<string> GetArtists();

    [OperationContract]
    List<string> GetVenues();

    [OperationContract]
    List<string> GetShows();

    [OperationContract]

    List<ShowInfoVenue> GetShowInfoVenue(string VenueName);

    [OperationContract]

    List<ShowInfoArtist> GetShowInfoArtist(string ArtistName);
}

[DataContract]
public class ShowInfoVenue
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowTime { set; get; }
 
}

[DataContract]
public class ShowInfoArtist
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowTime { set; get; }
    [DataMember]
    public string VenueName { set; get; }

}
