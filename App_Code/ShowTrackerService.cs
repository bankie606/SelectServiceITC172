using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShowTrackerService" in code, svc and config file together.
public class ShowTrackerService : IShowTrackerService
{
    ShowTrackerEntities db = new ShowTrackerEntities();


    public List<string> GetArtists()
    {
        var artist = from a in db.Artists
                     orderby a.ArtistName
                     select new { a.ArtistName };

        List<string> artistsName = new List<string>();
        foreach (var a in artist)
        {
            artistsName.Add(a.ArtistName.ToString());
        }
        return artistsName;
    }

    public List<string> GetShows()
    {
        var shows = from s in db.Shows
                    orderby s.ShowName
                    select new { s.ShowName };
        List<string> showName = new List<string>();
        foreach (var s in shows)
        {
            showName.Add(s.ShowName.ToString());
        }
        return showName;
    }
    public List<ShowInfoVenue>  GetShowInfoVenue(string venueName)
    {
        var ven = from s in db.Shows
                  where s.Venue.VenueName.Equals(venueName)
                  select new
                                      
                   {
                       s.ShowName,
                       s.ShowDate,
                       s.ShowTime,
                     s.Venue
                   };
        List<ShowInfoVenue> info = new List<ShowInfoVenue>();
        foreach (var le in ven)
        {
            ShowInfoVenue si = new ShowInfoVenue();
            si.ShowDate = le.ShowDate.ToShortDateString();
            si.ShowName = le.ShowName;
            si.ShowTime = le.ShowTime.ToString();
            info.Add(si);
        }
        return info;
    }


    public List<ShowInfoArtist> GetShowInfoArtist(string artistName)
    {
        var art = from a in db.Shows
                  from sd in a.ShowDetails
                  where sd.Artist.ArtistName.Equals(artistName)
                  
                  select new

                  {
                      a.ShowName,
                      a.ShowDate,
                      a.ShowTime,
                     a.Venue.VenueName
                  };
        List<ShowInfoArtist> info = new List<ShowInfoArtist>();
        foreach (var le in art)
        {
            ShowInfoArtist si = new ShowInfoArtist();
            si.ShowDate = le.ShowDate.ToShortDateString();
            si.ShowName = le.ShowName;
            si.ShowTime = le.ShowTime.ToString();
            si.VenueName = le.VenueName.ToString();
            info.Add(si);
        }
        return info;
    }




    public List<string> GetVenues()
    {
        var venue = from v in db.Venues
                    orderby v.VenueName
                    select new { v.VenueName };
        List<string> venueName = new List<string>();
        foreach (var v in venue)
        {
            venueName.Add(v.VenueName.ToString());
        }
        return venueName;
    }

 

}
