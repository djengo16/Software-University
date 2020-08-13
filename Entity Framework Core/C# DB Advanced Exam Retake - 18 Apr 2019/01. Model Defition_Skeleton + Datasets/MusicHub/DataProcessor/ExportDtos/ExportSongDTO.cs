using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ExportDtos
{
    [XmlType("Song")]
    public class ExportSongDTO
    {        
        public string SongName { get; set; }

        public string Writer { get; set; }

        public string Performer { get; set; }

        public string AlbumProducer { get; set; }

        public string Duration { get; set; }
    }
    //<Song>
    //<SongName>Away</SongName>
    //<Writer>Norina Renihan</Writer>
    //<Performer>Lula Zuan</Performer>
    //<AlbumProducer>Georgi Milkov</AlbumProducer>
    //<Duration>00:05:35</Duration>

}
