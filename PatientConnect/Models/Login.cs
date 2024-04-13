﻿// Purpose: This file contains the Login model class, which represents a login in the database.
// The Login model contains the following properties:

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Login
{
    // LoginID is a unique identifier for the login
    [Column(TypeName = "char")]
    [StringLength(8)]

    // LoginID is required
    public string LoginID { get; set; }

    // UserID is a foreign key to the User table
    public int UserID { get; set; }

    // User is a navigation property to the User table
    public virtual User User { get; set; }

    // PasswordHash is a hash of the user's password
    [Column(TypeName = "char")]
    [Required, StringLength(94)]
    public string PasswordHash { get; set; }
}
