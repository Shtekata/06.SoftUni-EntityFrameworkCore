using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class CustomerImportDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), minimum: "0.01", maximum: "10000000000000000000000")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketCustomerImportDto[] Tickets { get; set; }
    }
}
