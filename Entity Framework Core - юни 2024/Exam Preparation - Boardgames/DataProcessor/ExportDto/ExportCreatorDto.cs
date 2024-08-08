using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorDto
    {
        [XmlElement(nameof(CreatorName))]
        public string CreatorName { get; set; } = null!;

        [XmlAttribute(nameof(BoardgamesCount))]
        public int BoardgamesCount { get; set; }


        [XmlArray(nameof(Boardgames))]
        public ExportBoardgameDto[] Boardgames { get; set; } = null!;

    }
}
