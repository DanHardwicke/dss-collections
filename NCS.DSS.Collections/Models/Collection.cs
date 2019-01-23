using DFC.Swagger.Standard.Annotations;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace NCS.DSS.Collections.Models
{
    public class Collection
    {
        [Display(Description = "Unique identifier of the collection record.")]
        [Example(Description = "b8592ff8-af97-49ad-9fb2-e5c3c717fd85")]
        [JsonProperty(PropertyName = "id")]
        public Guid CollectionId { get; set; }

        [Display(Description = "zip file containing summary report and payment details reports.")]
        [Example(Description = "http://url/path")]
        public Uri CollectionReports { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint submitting the collection.  This value will be taken from the HTTP method header and is not needed to be supplied as a parameter.")]
        [Example(Description = "0000000001")]
        public Guid TouchPointId { get; set; }

        [StringLength(8, MinimumLength = 8)]
        [Display(Description = "UK Provider Reference Number of the touchpoint.  This is needed by DC")]
        [Example(Description = "12345678")]
        public string UKPRN { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time of the last modification to the record.")]
        [Example(Description = "2018-06-20T13:45:00")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
