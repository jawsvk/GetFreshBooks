namespace GetFreshBooks.Models
{
    using GetFreshBooks.Helpers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int MessageID { get; set; }

        [Required]
        [StringLength(120)]
        public string CustomerName { get; set; }

        [Required]
        [EmailValidator(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(4000, MinimumLength = 20)]
        public string MessageBody { get; set; }

        public DateTime MessageDateTime { get; set; }
    }
}
