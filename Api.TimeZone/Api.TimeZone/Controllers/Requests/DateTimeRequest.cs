using System;
using System.ComponentModel.DataAnnotations;

namespace Api.TimeZone.Controllers.Requests;

/// <summary>
/// Date Time Request.
/// </summary>
public class DateTimeRequest
{
    /// <summary>
    /// Date Time.
    /// </summary>
    [Required]
    public virtual DateTimeOffset DateTime { get; set; }
}